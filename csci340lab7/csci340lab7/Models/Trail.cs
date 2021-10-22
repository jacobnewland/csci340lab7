using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace csci340lab7.Models
{
    public class Trail
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }
        public decimal Length { get; set; }
    }
}
