using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fantastical.Models
{
    public class Creature
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Lore { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string ImagePath { get; set; }
    }
}
