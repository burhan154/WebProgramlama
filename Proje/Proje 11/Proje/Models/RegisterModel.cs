using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Models
{
    public class RegisterModel
    {

        [Required]
        [StringLength(20, ErrorMessage = "Your First Name can contain only 20 characters")]
        [UIHint("name")]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Your Last Name can contain only 20 characters")]
        [Display(Name = "Last Name")]
        [UIHint("lastname")]
        public string LastName { get; set; }

        //[Required]
        //[StringLength(20, ErrorMessage = "Your User Name can contain only 20 characters")]
        //[UIHint("username")]
        //[Display(Name = "User Name")]
        //public string UserName { get; set; }

        [Required]
        [UIHint("email")]
        public string Email { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        [Required]
        [UIHint("password")]
        [Compare("Password",ErrorMessage ="Pasword and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


    }
}
