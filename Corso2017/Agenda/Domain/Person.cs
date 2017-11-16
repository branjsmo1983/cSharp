using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain
{
    public class Person
    {
        public enum Nationalities { Italian, German, Spanish, French, English }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Nationalities Nationality { get; set; }
    }
}
