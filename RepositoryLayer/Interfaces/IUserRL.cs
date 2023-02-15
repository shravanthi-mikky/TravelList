using CommonLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        public string Login(LoginModel userlogin);

        public UserEntity Registration(UserRegistrationModel user);
    }
}
