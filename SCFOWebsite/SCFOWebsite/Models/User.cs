using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace SCFOWebsite.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public int orgId { get; set; }
        public string username { get; set; }
        public string handle { get; set; }
        public string email { get; set; }
        public string pwd { get; set; }
    }
}