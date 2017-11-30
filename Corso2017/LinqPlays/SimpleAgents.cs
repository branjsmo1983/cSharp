using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPlays
{
    static class SimpleAgents
    {
        public static void Play()
        {
            var agents = SimpleAgent.Create();

            Console.WriteLine("Select dopo aver creato una classe DistrictIncome per lo scopo");

            var districtIncomes = agents
                .GroupBy(x => x.District)
                .Select(x => new DistrictIncome
                    {
                        District = x.Key,
                        TotalIncome = x.Sum(a => a.TotalIncome)
                    });

            foreach(var di in districtIncomes)
                Console.WriteLine($"La provincia {di.District} ha raggiunto {di.TotalIncome} di guadagno");

            Console.WriteLine();

            var anonymousDistrictIncomes = agents
                .GroupBy(x => x.District)
                .Select(x => new
                    {
                        District = x.Key,
                        TotalIncome = x.Sum(a => a.TotalIncome)
                    });

            foreach (var di in anonymousDistrictIncomes)
                Console.WriteLine($"La provincia {di.District.ToUpper()} ha raggiunto {di.TotalIncome} di guadagno");
        }
    }

    class SimpleAgent
    {
        public static List<SimpleAgent> Create()
        {
            return new List<SimpleAgent>
            {
                Create("Bob Martin", "UD", 30000),
                Create("Phil Collins", "TS", 25000),
                Create("Matthew Core", "UD", 45000),
                Create("Mark Zuck", "PD", 47000),
                Create("Eric Evans", "TS", 18000)
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

    class DistrictIncome
    {
        public string District { get; set; }
        public int TotalIncome { get; set; }
    }
}
