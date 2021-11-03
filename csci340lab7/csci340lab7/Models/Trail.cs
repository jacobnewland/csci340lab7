using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csci340lab7.Models
{
    public class Trail
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Location { get; set; }

        [Display(Name = "Length in Miles")]
        [Required]
        public decimal Length { get; set; }

        [Display(Name = "1-10 Difficulty")]
        [Required]
        public decimal Difficulty { get; set; }
    }
}
