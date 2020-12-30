using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebServiceMethod.Model
{
    public class User_Details
    {
        public string username { get; set; }
        public string password { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string civilstatus { get; set; }
        public int age { get; set; }
        public DateTime bdate { get; set; }
        public string religion { get; set; }
        public string bplace { get; set; }

    }
}