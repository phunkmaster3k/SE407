using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCFOWebsite.Models
{
    public class PlayerShips
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int playerShipId { get; set; }

        public int shipId { get; set; }
        public int playerId { get; set; }

    }
}