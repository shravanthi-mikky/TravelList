using BusinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TravelList1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL iUserBL;

        public UserController(IUserBL iUserBL)
        {
            this.iUserBL = iUserBL;

        }

        [HttpPost("Register")]
        public IActionResult Registration(UserRegistrationModel userRegistration)
        {
            try
            {
                var reg = this.iUserBL.Registration(userRegistration);
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = "Registration Sucessfull", data = reg });
                }
                else
                {

                    return this.BadRequest(new { Success = false, message = "Registration Unsucessfull" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginModel login)
        {
            try
            {
                string tokenString = iUserBL.Login(login);
                if (tokenString != null)
                {
                    return Ok(new { Success = true, message = "login Sucessfull", Data = tokenString });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "login Unsucessfull" });
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        [HttpPost("PayCheck")]
        public IActionResult Payment(PaymentModel payModel)
        {
            try
            {
                bool Value = iUserBL.Payment(payModel);
                if (Value != false)
                {
                    return Ok(new { Success = true, message = "Payment Sucessfull", Data = Value });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Payment Unsucessfull" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpGet("GetPayDetails")]
        public IActionResult RetrivePayButtonValues()
        {
            try
            {
                var reg = this.iUserBL.RetrivePayButtonValues();
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Pay Details", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to get Pay details" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }


        // Single button value

        [HttpGet("GetSingleValue")]
        public IActionResult RetrivePayButtonVal(int listId)
        {
            try
            {
                var reg = this.iUserBL.RetrivePayButtonVal(listId);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Pay Details", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to get Pay details" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [HttpPut("UpdatePay")]
        public IActionResult UpdatePay(PayButtonModel list)
        {
            try
            {
                var reg = this.iUserBL.UpdatePay(list);
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = "Pay Updated Successfully", data = reg });
                }
                else
                {
                    return this.Ok(new { Success = false, message = "Unable Update the Pay" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
