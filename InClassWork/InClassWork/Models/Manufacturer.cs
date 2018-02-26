using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InClassWork.Models
{
    public class Manufacturer
    {

        [Key]
        public int Manufacturer_Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression("..+", ErrorMessage = "2 spaces!")]
        public string make { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}