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
            var nameList = GetNamesByHand(studentList);
            Console.WriteLine("Lista dei nomi degli studenti");
            foreach (var n in nameList)
            {
                Console.WriteLine($"nome dello studente : { n}");
                
            }
            Console.WriteLine();
            var howMuch = GethowStudentsByHand(studentList);
                Console.WriteLine($"il numero degli studenti passati : { howMuch } ");
            var nameListLinq = studentList.Select(x => x.Name);
            foreach(var v in nameListLinq)
            {
                Console.WriteLine(v);
            }

            var passLinq = studentList.Count(student => student.Passed);
            Console.WriteLine($"sono passati : {passLinq}");

            var passListLinq = studentList.Where(x => x.Passed == true).Select(y => y.Name);

            var evenTo100 = Enumerable.Range(1, 100).Where(integer => integer % 2 == 0);

           

        }

        public class Square
        {
            public int Number { get; set; }
            public int SquareNumber { get; set; }
        }

        static IEnumerable<string> GetNamesByHand(IEnumerable<Student> students)
        {
            var nameList = new List<string>();
            foreach(var s in students)
            {
                nameList.Add(s.Name);
            }
            return nameList;
            
        }

        static int GethowStudentsByHand(IEnumerable<Student> students)
        {
            int howMany = 0;
            foreach(var s in students)
            {
                if (s.Passed)
                {
                    howMany++;
                }
            }
            return howMany;
        }
        
    }

    class Student
    {
        public static IEnumerable<Student> CreateList()
        {
            return new List<Student>
            {
                Create(1, "Massimo Boldi",4),
                Create(2, "Christian de sica", 6),
                Create(3, "Renato Pozzetto", 5),
                Create(4, "Paolo Villaggio", 9),
                Create(5, "Lino Banfi", 8)
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
