using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_URL.Model
{
    public class AccountModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class acceptUserAccount
    {
        public string username { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string userPassword { get; set; }
        public string userRePassword { get; set; }
        public string gender { get; set; }
    }
}
