using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fantastical.Models.ViewModel
{
    public class CreatureCreateViewModel
    {
        public Creature Creature { get; set; }
        public IFormFile Image { get; set; }
    }
}
