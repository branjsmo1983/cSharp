using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvcPrimoTentativo.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^([\w ])+$")]
        [MinLength(3)]
        [MaxLength(32)]
        public string Name { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
