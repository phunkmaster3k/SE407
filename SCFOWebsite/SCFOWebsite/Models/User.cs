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

        public int orgId { get; set; }

        [Required(ErrorMessage = "User Name is required!")]
        public string username { get; set; }
        public string handle { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        public string pwd { get; set; }
        public bool admin { get; set; }

        
    }
}