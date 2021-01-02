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
        [HttpGet("account")]
        public async Task<IActionResult> checkUserAccount([FromBody] AccountModel model)
        {
            var returns = new Response<string>();
            if(!string.IsNullOrEmpty(model.username) && !string.IsNullOrEmpty(model.Password))
            {
                returns = await _repost.userAccount(model);
            }
            else
            {
                returns.Message = "Empty Field";
                returns.isSuccess = false;
            }
            return Ok(returns);
        }
        [HttpPost("userAccount")]
        public async Task<IActionResult> acceptUserAccount([FromBody] acceptUserAccount accnt)
        {
            var res = new Response<string>();
            if  (!string.IsNullOrEmpty(accnt.username) && 
                !string.IsNullOrEmpty(accnt.password) && 
                !string.IsNullOrEmpty(accnt.firstname) && 
                !string.IsNullOrEmpty(accnt.lastname) && 
                !string.IsNullOrEmpty(accnt.CivilStatus) &&
                !string.IsNullOrEmpty(Convert.ToString(accnt.bdate).ToString()) &&
                !string.IsNullOrEmpty(accnt.religion) &&
                !string.IsNullOrEmpty(accnt.bplace))
            {
                res = await _repost.userAcceptAccount(accnt);
            }
            else
            {
                res.Message = "Some Fields is Empty";
                res.isSuccess = false;
            }
            return Ok(res);
        }
    }   
}
