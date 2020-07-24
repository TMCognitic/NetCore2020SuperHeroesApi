using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperHeroes.Api.Models
{
    public class HeroForm
    {
        [Required]        
        public string Name { get; set; }
        [Required]
        [Range(1, 20)]
        public int Strength { get; set; }
        [Required]
        [Range(1, 20)]
        public int Stamina { get; set; }
        [Required]
        [Range(1, 20)]
        public int Intellect { get; set; }
        [Required]
        [Range(1, 20)]
        public int Charisma { get; set; }
    }
}