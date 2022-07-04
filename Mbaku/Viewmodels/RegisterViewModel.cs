using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mbaku.Viewmodels
{
    public class RegisterViewModel
    {
        [Required, MaxLength(256),EmailAddress,Display(Name ="Email Address")]
        public string EmailAddress { get; set; }
        [Required,MinLength(6),MaxLength(50),DataType(DataType.Password),Display(Name ="Password")]
        public string Password { get; set; }
        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Password"), Compare("Password",ErrorMessage ="This Passwords dont match!")]
        public string ConfirmPassword{ get; set; }
    }
}
