using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SCFOWebsite.Models
{
    public class Ship
    {

        [Key]
        public int ShipId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Role { get; set; }
        public string ProductionState { get; set; }
        public int CargoCapacity { get; set; }
        public int MaxCrew { get; set; }
        public int MinCrew { get; set; }
        public int SCMSpeed { get; set; }
        public int ABSpeed { get; set; }

    }
}