using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvcSuperheroes.Models
{
    public class SuperHero
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Hero Name")]
        public string HeroName { get; set; }

        [MaxLength(50)]
        public string SecretName { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [Range(0, int.MaxValue)]
        public int Power { get; set; }

        public bool CanFly { get; set; }

        public DateTime? Birth { get; set; }

        public ICollection<Villain> Villains { get; set; }
    }
}
