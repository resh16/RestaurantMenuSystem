using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMenuSystem.Models
{
    public class SignUpUserModel
    {
        [Key]
        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Please entr a valid email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter a strong password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please confirm your pasword")]
        [Display(Name = "Confirm Pasword")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
