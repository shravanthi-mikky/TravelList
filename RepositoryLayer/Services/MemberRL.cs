using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using RepositoryLayer.Interfaces;
using RepositoryLayer.TravelContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RepositoryLayer.Services
{
    public class MemberRL:IMemberRL
    {
        private readonly TravelsContext context;
        private readonly IConfiguration Iconfiguration;
        public MemberRL(TravelsContext context, IConfiguration Iconfiguration)
        {
            this.context = context;
            this.Iconfiguration = Iconfiguration;
        }

        // Db Approach

        NpgsqlConnection sqlConnection;
        string ConnString = "Server=localhost;Port=5432;Database=TravelListDB;Username=postgres; Password=Mickey@27;Integrated Security=True;";

        public MemberModel RetriveMember(long ListId,string place)
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConnString);
            string query = "select * from MembersTable2 where ListId= '" + ListId + "' and Place= '" + place + "';";
            NpgsqlCommand com = new NpgsqlCommand(query, conn);
            com.CommandType = CommandType.Text;
            conn.Open();
            MemberModel member = new MemberModel();
            NpgsqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    member.FullName = reader["FullName"].ToString();
                    member.Residence = reader["Residence"].ToString();
                    member.Gender = reader["Gender"].ToString();
                    member.Place = reader["Place"].ToString();
                    member.Age = reader["Age"].ToString();
                }
                return member;
            }
            return null;
        }

        // Retrive list of same place

        public List<MemberModel> RetriveMembers(long ListId, string place)
        {
            List<MemberModel> employ = new List<MemberModel>();
            NpgsqlConnection conn = new NpgsqlConnection(ConnString);
            using (conn)
            {
                try
                {

                    string query = "select * from MembersTable2 where ListId= '" + ListId + "' and Place= '" + place + "';";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    conn.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employ.Add(new MemberModel
                            {
                                MemberId = Convert.ToInt32(reader["MemberId"]),
                                FullName = reader["FullName"].ToString(),
                                Residence = reader["Residence"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                Place = reader["Place"].ToString(),
                                Age = reader["Age"].ToString()
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



    }
}
