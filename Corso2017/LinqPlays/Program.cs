using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPlays
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentList = Student.CreateList();

            Console.WriteLine("Lista dei nomi degli studenti recuperata a mano:");

            var nameList = GetNamesByHand(studentList);

            foreach (var n in nameList)
                Console.WriteLine(n);

            Console.WriteLine();

            var howManyPassedTheExam = GetHowManyPassedByHand(studentList);

            Console.Write($"Sono passati: {howManyPassedTheExam} studenti.");

            Console.WriteLine();

            var nameListWithLinq = studentList.Select(x => x.Name);

            foreach (var n in nameListWithLinq)
                Console.WriteLine(n);

            Console.WriteLine();

            var passedCountWithLinq = studentList.Count(x => x.Passed);

            Console.WriteLine($"Sono passati {passedCountWithLinq} studenti.");

            Console.WriteLine();

            var startsWithCCount = studentList.Count(x => x.Name.StartsWith("C"));

            Console.WriteLine($"{startsWithCCount} studenti hanno il nome che comincia per 'c'.");

            Console.WriteLine();

            var passedNameList = studentList
                .Where(x => x.Passed)
                .Select(x => x.Name);

            Console.WriteLine("Gli studenti promossi sono:");

            foreach(var name in passedNameList)
                Console.WriteLine(name);

            Console.WriteLine();

            var evenTo100 = Enumerable
                .Range(1, 100)
                .Where(i => i % 2 == 0);

            foreach (var i in evenTo100)
                Console.WriteLine(i);

            var squaresTo100 = Enumerable
                .Range(1, 100)
                .Select(i => i * i);

            Console.WriteLine();

            foreach (var i in squaresTo100)
                Console.WriteLine(i);

            Console.WriteLine();

            var squaresCompleteTo100 = Enumerable
                .Range(1, 100)
                .Select(i => new Square
                            {
                                Number = i,
                                ItsSquare = i * i
                            })
                .Where(s => s.ItsSquare > 50)
                .Skip(3)
                .Take(10);

            foreach(var s in squaresCompleteTo100)
                Console.WriteLine($"Il quadrato di {s.Number} è {s.ItsSquare}");

            Console.Read();
        }

        static IEnumerable<string> GetNamesByHand(IEnumerable<Student> students)
        {
            var nameList = new List<string>();

            foreach (var s in students)
                nameList.Add(s.Name);

            return nameList;
        }

        static int GetHowManyPassedByHand(IEnumerable<Student> students)
        {
            int howManyPassed = 0;

            foreach (var s in students)
                if (s.Passed)
                    howManyPassed++;

            return howManyPassed;
        }
    }

    class Square
    {
        public int Number { get; set; }
        public int ItsSquare { get; set; }
    }

    class Student
    {
        public static IEnumerable<Student> CreateList()
        {
            return new List<Student>
            {
                Create(1, "Massimo Boldi", 4),
                Create(2, "Christian De Sica", 6),
                Create(3, "Pippo Baudo", 8),
                Create(4, "Claudio Bisio", 9),
                Create(5, "Pippo Franco", 2)
            };
        }

        public static Student Create(int id, string name, int evaluation)
        {
            return new Student
            {
                Id = id,
                Name = name,
                Evaluation = evaluation
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Evaluation { get; set; }
        public bool Passed { get { return Evaluation >= 6; } }
    }
}
