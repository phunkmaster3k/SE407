﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCFOWebsite.Models
{
    public class Org
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrgId { get; set; }

        [RegularExpression("...+", ErrorMessage = "Needs to be 3 characters long")]
        [Required(ErrorMessage = "Name is required!")]
        [Display(Name = "Organization Name")]
        public string Name { get; set; }
        public int Members { get; set; }

        [Required(ErrorMessage = "Focus is required!")]
        public string Focus { get; set; }

    }
}