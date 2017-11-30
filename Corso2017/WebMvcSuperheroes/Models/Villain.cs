using System.ComponentModel.DataAnnotations.Schema;

namespace WebMvcSuperheroes.Models
{
    public class Villain
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NemesisId { get; set; }
        //attributo che serve se la propr
        //[ForeignKey(nameof(NemesisId))]
        public SuperHero Nemesis { get; set; }
    }
}