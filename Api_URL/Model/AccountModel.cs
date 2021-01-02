using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_URL.Model
{
    public class AccountModel
    {
        public string username { get; set; }
        public string Password { get; set; }
    }
    public class acceptUserAccount
    {
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string CivilStatus { get; set; }
        public DateTime bdate { get; set; }
        public string religion { get; set; }
        public string bplace { get; set; }
    }
}
