using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SCFOWebsite.Models
{
    public class Org
    {
        [Key]
        public int OrgId { get; set; }
        public string Name { get; set; }
        public int Members { get; set; }
        public string Focus { get; set; }

    }
}