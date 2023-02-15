using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL iUserRL;
        public UserBL(IUserRL iUserRL)
        {
            this.iUserRL = iUserRL;
        }

        public string Login(LoginModel userlogin)
        {
            
            try
            {
                return iUserRL.Login(userlogin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserEntity Registration(UserRegistrationModel user)
        {

            try
            {
                return iUserRL.Registration(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
