using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCFOWebsite.ViewModels.Home
{
    public class RegisterViewModel : Models.User
    {
        [Display(Name = "Retype password")]
        [Compare("pwd", ErrorMessage = "Password doesn't match, Type again !")]
        [NotMapped]
        public string retype { get; set; }
    }
}