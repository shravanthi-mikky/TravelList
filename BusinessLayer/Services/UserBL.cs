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

        public bool Payment(PaymentModel payModel)
        {
            return iUserRL.Payment(payModel);
        }

        public List<PayButtonModel> RetrivePayButtonValues()
        {
            try
            {
                return iUserRL.RetrivePayButtonValues();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<PayButtonModel> RetrivePayButtonVal(int listId)
        {
            try
            {
                return iUserRL.RetrivePayButtonVal(listId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PayButtonModel UpdatePay(PayButtonModel employ)
        {
            try
            {
                return iUserRL.UpdatePay(employ);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
