using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_URL.Model
{
    public class AccountModel
    {
        [Required]
        public string username { get; set; }
        [Required]
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
    public class InquiryDetails
    {
        public string Iname { get; set; }
        public string Idesc { get; set; }
        public string Icode { get; set; }
        public DateTime tdt { get; set; }
        public decimal amount { get; set; }
        public int quantity { get; set; }
    }
    public class DateiNQUIRY
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
    public class ItemOrderDetails
    {
        public string iname { get; set; }
        public string idesc { get; set; }
        public string icode { get; set; }
        public DateTime tdt { get; set; }
        public decimal amount { get; set; }
        public int quantity { get; set; }
    }
    public class response<T>
    {
        public string message { get; set; }
        public T retval {get; set;}
    }
}
