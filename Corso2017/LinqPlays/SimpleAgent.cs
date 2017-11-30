using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPlays
{
    class SimpleAgent
    {
        public static void Play()
        {
            var egents = SimpleAgent.Create();
            var districts = egents.GroupBy(x => x.District).Select(x => new SimpleAgent
            {
                District = x.Key,
                TotalIncome = x.Sum(a => a.TotalIncome)
            });
            foreach(var di in districts)
            {
                Console.WriteLine($"la provincia {di.District} ha come totale {di.TotalIncome}  tollari di guadagno");
            }

            var enonymouSdistricts = egents.GroupBy(x => x.District).Select(x => new
            {
                District = x.Key,
                TotalIncome = x.Sum(a => a.TotalIncome)
            });
            foreach (var di in districts)
            {
                Console.WriteLine($"la provincia {di.District} ha come totale {di.TotalIncome}  tollari di guadagno");
            }
        }

        public static List<SimpleAgent> Create()
        {
            return new List<SimpleAgent>
            {
                Create("Willy wonka","Chicago", 156000),
                Create("Bob Marley","GiammaicagatoerCax",20),
                Create("Michael Jordan", "Chicago", 9000000),
                Create("Carmen Vargas","Medellin", 80000),
                Create("Pellegrinaggi Medjugorie","Medellin", 33941823)
            };
        }

        public static SimpleAgent Create(string name, string district, int totalIncome)
        {
            return new SimpleAgent
            {
                Name = name,
                District = district,
                TotalIncome = totalIncome
            };
        }

        public string Name { get; set; }
        public string District { get; set; }
        public int TotalIncome { get; set; }
    }
}
