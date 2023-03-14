using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TravelList1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        IMemberBL iMemberBL;

        public MemberController(IMemberBL iMemberBL)
        {
            this.iMemberBL = iMemberBL;

        }

        [HttpGet("GetMembersById")]
        public IActionResult RetriveMembers(long ListId, string place)
        {
            try
            {
                var reg = this.iMemberBL.RetriveMembers(ListId, place);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Members Details", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to get Members details" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
