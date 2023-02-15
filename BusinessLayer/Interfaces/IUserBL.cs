using CommonLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        public string Login(LoginModel userlogin);
        public UserEntity Registration(UserRegistrationModel user);
    }
}
