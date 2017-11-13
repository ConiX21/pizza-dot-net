using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetPizza.Models.AccountViewModels
{
    public class RegisterViewModel
    {

     
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
       

        [Display(Name = "Postal Code")]
        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        [Display(Name = "Sexe")]
        [Range(0,1, ErrorMessage = "Veuillez choisir un sexe")]
        public int Gender { get; set; }

    }
}
