using Microsoft.AspNetCore.Mvc;
using Projecttttttttt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projecttttttttt.Classess;
using Newtonsoft.Json;
using Projecttttttttt.Repository;

namespace Projecttttttttt.Controllers
{
    public class AccountController : Controller
    {
        URL url = new URL();
        private readonly IActionRepository _action;

        public AccountController(IActionRepository action)
        {
            _action = action;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Account()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Account(AccountModel account)
        {
            var res = new response<string>();
            try
            {
                res = await _action.InsertData(account);
                if(res.Result == "500")
                {
                   
                }
                else if(res.Result == "200")
                {
                   
                }
                else
                {
                    return RedirectToAction("", "");
                }
            }
            catch (Exception ee)
            {
                res.Message = ee.Message;
            }
            return Ok(new { res = res});
        }
        [HttpGet]
        public IActionResult AccountLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AccountLogin(AccountModel Login)
        {
            var res = new response<string>();
            try
            {
                res = await _action.LoginCredentials(Login);
                if (res.Result == "1")
                {

                }
                else if (res.Result == "500")
                {

                }
                else
                {

                }
            }
            catch (Exception ee)
            {
                res.Message = ee.Message;
            }
            return Ok(res);
        }
    }
}
