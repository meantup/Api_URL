using Api_URL.Repository;
using Api_URL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_URL.Controllers
{
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IRepository _repost;
        public DefaultController(IRepository repost)
        {
            _repost = repost;
        }
        [HttpPost("account")]
        public async Task<IActionResult> checkUserAccount([FromBody] AccountModel model)
        {
            Response<List<acceptUserAccount>> retval = new Response<List<acceptUserAccount>>();
            retval = await _repost.userAccount(model);
            if (retval.response == 200)
            {
                retval.Message = "Record Found";
            }
            else if (retval.response == 100)
            {
                retval.Message = "No Record Found";
            }
            else if (retval.response == 500)
            {
                retval.Message = "Internal Server Error";
                retval.isSuccess = false;
            }
            else if(retval.response == 400)
            {
                retval.Message = "Bad Request";
                retval.isSuccess = false;
            }
            return Ok(retval);
        }
        [HttpPost("userAccount")]
        public async Task<IActionResult> acceptUserAccount([FromBody] acceptUserAccount accnt)
        {
            var res = new Response<string>();
            if (ModelState.IsValid)
            {
                res = await _repost.userAcceptAccount(accnt);
            }
            res.isSuccess = false;
            return Ok(res);
        }
        [HttpGet("api/Inquiry/{startDate}/{endDate}")]
        public async Task<IActionResult> Inquiry(/*[FromBody] DateiNQUIRY dateInput*/string startDate, string endDate)
        {
            List<InquiryDetails> list = new List<InquiryDetails>();
            list = await _repost.getDATE(startDate, endDate);
            return Ok(list);
        }
        [HttpPost("api/Order")]
        public async Task<IActionResult> OrderDetails([FromBody] ItemOrderDetails itm)
        {
            var responsecode = new response<string>();
            responsecode = await _repost.postItem(itm);
            return Ok(responsecode);
        }
    }   
}
