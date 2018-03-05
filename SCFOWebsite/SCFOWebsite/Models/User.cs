using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCFOWebsite.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        [Display(Name = "Organization")]
        public int orgId { get; set; }

        [Display(Name = "User name")]
        [Required(ErrorMessage = "User Name is required!")]
        [RegularExpression("...+", ErrorMessage = "Needs to be 3 characters long")]
        public string username { get; set; }

        [Display(Name = "In game handle")]
        public string handle { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "Email is required!")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [RegularExpression(".........+", ErrorMessage = "Needs to be 8 characters long")]
        [Display(Name = "Password")]
        public string pwd { get; set; }

        public bool admin { get; set; }   
    }
}