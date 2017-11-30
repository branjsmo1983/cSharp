using System.ComponentModel.DataAnnotations.Schema;

namespace WebMvcSuperheroes.Models
{
    public class Villain
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NemesisId { get; set; }

        //l'attributo serve se proprietà con l'oggetto e proprietà con l'Id
        //non coincidono
        //[ForeignKey(nameof(NemesisId))]
        public SuperHero Nemesis { get; set; }
    }
}