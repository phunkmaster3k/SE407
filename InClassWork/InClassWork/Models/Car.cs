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

        [Required(ErrorMessage = "Car Model is Required")]
        [RegularExpression("..+", ErrorMessage = "Needs to be 2 characters long")]
        public string Model { get; set; }

        [Range(10,9000)]
        public double MaxSpeed { get; set; }

        public string ImageName { get; set; }

        public int Manufacturer_Id { get; set; }

        public virtual Manufacturer manufacturer { get; set; }

    }
}