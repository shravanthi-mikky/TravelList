using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
                string dPass = user.Password;
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

    }


}
