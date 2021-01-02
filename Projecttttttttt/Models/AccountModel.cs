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
        [Required(ErrorMessage = "Enter Your Username")]
        public string username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Your Password")]
        public string userPassword { get; set; }

        [Display(Name = "Confirmation Password")]
        [DataType(DataType.Password)]
        [Compare("userPassword", ErrorMessage = "The password and confirmation password doesn't match.")]
        [Required(ErrorMessage = "Re-Enter Your Password")]
        public string userRePassword { get; set; }

        [Display(Name = "FirstName")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Your First Name")]
        public string fname { get; set; }

        [Display(Name = "LastName")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Your Last Name")]
        public string lname { get; set; }

        [Display(Name = "CivilStatus")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Choose Your Civil Status")]
        public string civilStatus { get; set; }

        [Display(Name = "BirthDate")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Enter Your BirthDate")]
        public DateTime bdate { get; set; }

        [Display(Name = "Religion")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Your Religion")]
        public string religion { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Birth Place")]
        [Required(ErrorMessage = "Enter Your Birth Place")]
        public string bplace { get; set; }

    }
}
