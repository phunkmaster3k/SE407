using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InClassWork.Models
{
    public class Car
    {
        [Key]
        public int Car_ID { get; set; }
        public string Model { get; set; }
        public double MaxSpeed { get; set; }

    }
}