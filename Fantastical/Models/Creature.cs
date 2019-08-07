using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(Name = "Creature Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

    }
}
