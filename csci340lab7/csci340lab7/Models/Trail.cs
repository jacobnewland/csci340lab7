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
        public string Name { get; set; }

        public string Location { get; set; }

        [Display(Name = "Length in Miles")]
        public decimal Length { get; set; }
        public decimal Difficulty { get; set; }
    }
}
