using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvcSuperheroes.Models
{
    public class SuperHero
    {
        public int Id { get; set; }

        public string HeroName { get; set; }

        public string SecretName { get; set; }

        public string City { get; set; }

        public int Power { get; set; }

        public bool CanFly { get; set; }

        public DateTime Birth { get; set; }

        public ICollection<Villain> Villains { get; set; }
    }
}
