using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using RepositoryLayer.TravelContext;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        private readonly TravelsContext context;
        private readonly IConfiguration Iconfiguration;
        NpgsqlConnection sqlConnection;
        string ConnString = "Server=localhost;Port=5432;Database=TravelListDB;Username=postgres; Password=Mickey@27;Integrated Security=True;";
        public UserRL(TravelsContext context, IConfiguration Iconfiguration)
        {
            this.context = context;
            this.Iconfiguration = Iconfiguration;
        }

        //REgister Method

        public UserEntity Registration(UserRegistrationModel user)
        {
            try
            {
                UserEntity users = new UserEntity();
                users.FirstName = user.FirstName;
                users.LastName = user.LastName;
                users.Email = user.Email;
                users.Password = user.Password;
                this.context.UsersTable.Add(users);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return users;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string GenerateSecurityToken(string Email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Iconfiguration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Email,Email)
            };
            var token = new JwtSecurityToken(Iconfiguration["Jwt:Key"],
            Iconfiguration["Jwt:Key"],
            claims,
            expires: DateTime.Now.AddMinutes(360),
            signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //Login Method

        public string Login(LoginModel userlogin)
        {
            try
            {
                UserEntity user = new UserEntity();
                user = this.context.UsersTable.FirstOrDefault(x => x.Email == userlogin.Email);
                string dPass = userlogin.Password;
                var id = user.UserId;
                if (dPass == userlogin.Password && user != null)
                {
                    var token = this.GenerateSecurityToken(userlogin.Email);
                    return token;
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }


        // Payment retrival
        public bool Payment(PaymentModel payModel)
        {
            using (sqlConnection = new NpgsqlConnection(ConnString))
                try
                {
                    string query = "select PaymentId from PayTable where cardHolder='" + payModel.cardHolder + "' and cardNumber='" + payModel.cardNumber + "' and ExpiryDate='" + payModel.ExpiryDate + "' and CVV='" + payModel.CVV + "';";
                    NpgsqlCommand sqlCommand = new NpgsqlCommand(query, sqlConnection);

                    sqlConnection.Open();


                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                       
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
                finally { sqlConnection.Close(); }

        }

        // retrive paid details

        public List<PayButtonModel> RetrivePayButtonValues()
        {
            List<PayButtonModel> employ = new List<PayButtonModel>();
            NpgsqlConnection conn = new NpgsqlConnection(ConnString);
            using (conn)
            {
                try
                {

                    string query = "select * from PayButton;";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    conn.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employ.Add(new PayButtonModel
                            {
                                listId = Convert.ToInt32(reader["ListId"]),
                                result = reader["result"].ToString(),
                                
                            });
                        }
                        return employ;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Retrive single element 

        public List<PayButtonModel> RetrivePayButtonVal(int listId)
        {
            List<PayButtonModel> employ = new List<PayButtonModel>();
            NpgsqlConnection conn = new NpgsqlConnection(ConnString);
            using (conn)
            {
                try
                {

                    string query = "select * from PayButton where listId = '"+ listId +"';";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    conn.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employ.Add(new PayButtonModel
                            {
                                listId = Convert.ToInt32(reader["ListId"]),
                                result = reader["result"].ToString(),

                            });
                        }
                        return employ;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public PayButtonModel UpdatePay(PayButtonModel employ)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(ConnString);
                using (conn)
                {
                    string query = "Update PayButton set result = '" + employ.result + "' where ListId = '" + employ.listId + "';";
                    NpgsqlCommand com = new NpgsqlCommand(query, conn);

                    conn.Open();
                    int i = com.ExecuteNonQuery();
                    conn.Close();
                    if (i != null)
                    {
                        return employ;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }


}
