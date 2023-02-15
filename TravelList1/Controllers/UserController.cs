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
    }
}
