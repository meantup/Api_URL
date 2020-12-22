using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projecttttttttt.Models
{
    public class AccountModel
    {
        [Display(Name = "Username")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Your Username")]
        public string username { get; set; }

        [Display(Name = "Age")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Your Age")]
        public int age { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string userPassword { get; set; }

        [Display(Name = "Confirmation Password")]
        [DataType(DataType.Password)]
        [Compare("userPassword", ErrorMessage = "The password and confirmation password doesn't match.")]
        [Required(ErrorMessage = "Please Re-Enter Your Password")]
        public string userRePassword { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Enter Your Gender")]
        public string gender { get; set; }

    }
}
