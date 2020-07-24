using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Api.Global.Entities
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Stamina { get; set; }
        public int Intellect { get; set; }
        public int Charisma { get; set; }
    }
}
