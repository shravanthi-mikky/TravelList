using BusinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace TravelList1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        IListBL iListBL;

        public TravelController(IListBL iListBL)
        {
            this.iListBL = iListBL;

        }

        [HttpPost("AddList")]
        public IActionResult AddingList(ListModel listModel)
        {
            try
            {
                var reg = this.iListBL.AddList(listModel);
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = "List added Sucessfull", Response = reg });
                }
                else
                {

                    return this.BadRequest(new { Success = false, message = " Unsucessfull" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [HttpGet("AllLists")]
        public IEnumerable<ListEntity> GetAllEmp()
        {
            try
            {
                return iListBL.GetAllList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("RemoveList")]
        public IActionResult DeleteList(long empid)
        {
            try
            {
                if (iListBL.DeleteList(empid))
                {
                    return this.Ok(new { Success = true, message = "List Deleted Successfully" });
                }
                else
                {
                    return this.Ok(new { Success = false, message = "Unable delete to List" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [HttpDelete("UpdateList")]
        public IActionResult UpdateList(ListEntity list)
        {
            try
            {
                var reg = this.iListBL.UpdateList(list);
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = "List Updated Successfully" , data=reg});
                }
                else
                {
                    return this.Ok(new { Success = false, message = "Unable Update the List" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
