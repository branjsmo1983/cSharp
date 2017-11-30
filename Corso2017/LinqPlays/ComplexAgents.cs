using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPlays
{
    static class ComplexAgents
    {
        public static void Play()
        {
            var agents = ComplexAgent.Create();

            Console.WriteLine("Total income for every agent:");

            var agentsWithTotal = agents
                .Select(a => new
                {
                    Name = a.Name,
                    TotalIncome = a.Operations.Sum(o => o.Income)
                });

            foreach(var i in agentsWithTotal)
                Console.WriteLine($"L'agente {i.Name} ha totalizzato {i.TotalIncome} €");
        }
    }

    class ComplexAgent
    {
        public static List<ComplexAgent> Create()
        {
            return new List<ComplexAgent>
            {
                Create("Bob Martin", "UD", new List<Operation>
                {
                    Operation.Create(2017, 11, 29, 5000),
                    Operation.Create(2017, 11, 30, 7000),
                }),
                Create("Phil Collins", "TS", new List<Operation>
                {
                    Operation.Create(2017, 11, 28, 1000),
                    Operation.Create(2017, 11, 29, 2000),
                }),
                Create("Matthew Core", "UD", new List<Operation>()),
                Create("Mark Zuck", "PD", new List<Operation>
                {
                    Operation.Create(2017, 11, 28, 7000),
                    Operation.Create(2017, 11, 29, 9000),
                    Operation.Create(2017, 11, 30, 3000),
                }),
                Create("Eric Evans", "TS", new List<Operation>
                {
                    Operation.Create(2017, 11, 27, 2000),
                    Operation.Create(2017, 11, 28, 2000),
                    Operation.Create(2017, 11, 29, 2000),
                    Operation.Create(2017, 11, 30, 2000),
                })
            };
        }

        public static ComplexAgent Create(
            string name, string district, List<Operation> operations)
        {
            return new ComplexAgent
            {
                Name = name,
                District = district,
                Operations = operations
            };
        }

        public string Name { get; set; }
        public string District { get; set; }
        public List<Operation> Operations { get; set; }
    }

    class Operation
    {
        public static Operation Create(int year, int month, int day, int income)
        {
            return new Operation
            {
                Date = new DateTime(year, month, day),
                Income = income,
            };
        }

        public DateTime Date { get; set; }
        public int Income { get; set; }
    }

}
