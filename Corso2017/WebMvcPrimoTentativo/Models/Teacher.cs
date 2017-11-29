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
        [RegularExpression(@"^([\w^])+$")]
        [MinLength(3,ErrorMessage = "Nome minimo di 3 caratteri")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Range(1,5,ErrorMessage = "devi scegliere un numero tra 1 e 5")]
        public int Rating { get; set; }
    }
}
