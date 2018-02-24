using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCFOWebsite.Models
{
    public class Ship
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShipId { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "Role is required!")]
        public string Role { get; set; }

        public string ProductionState { get; set; }

        public int CargoCapacity { get; set; }

        [Range(1, 100, ErrorMessage = "Must be between 1 and 100")]
        public int MaxCrew { get; set; }

        [Range(1, 20, ErrorMessage = "Must be between 1 and 20")]
        public int MinCrew { get; set; }

        [Range(1, 1000, ErrorMessage = "Must be between 1 and 1000")]
        public int SCMSpeed { get; set; }

        [Range(500, 2000, ErrorMessage = "Must be between 500 and 2000")]
        public int ABSpeed { get; set; }

        public string ImageName { get; set; }

    }
}