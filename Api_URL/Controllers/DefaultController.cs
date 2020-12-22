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
        public async Task<IActionResult> userAccount([FromBody] AccountModel account)
        {
            var returns = new Response<string>();
            if(!string.IsNullOrEmpty(account.Username) && !string.IsNullOrEmpty(account.Password))
            {
                returns = await _repost.userAccount(account);
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
            if(!string.IsNullOrEmpty(accnt.username) && !string.IsNullOrEmpty(accnt.email) && !string.IsNullOrEmpty(accnt.userPassword) && !string.IsNullOrEmpty(accnt.userRePassword) && !string.IsNullOrEmpty(accnt.gender))
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
