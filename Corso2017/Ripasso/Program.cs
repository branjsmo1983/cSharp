using System;
using System.Collections.Generic;

namespace Ripasso
{
    class Program
    {
        static void Main(string[] args)
        {
            Mum leila = new Mum("Leila");
            Dad hanSolo = new Dad("Han Solo");

            Console.WriteLine("La mamma si chiama " + leila.Name);
            Console.WriteLine("Il papà si chiama " + hanSolo.Name);

            leila.MakeBaby("Kylo Ren", hanSolo);

            leila.MakeBaby("Darth Vader Junior", hanSolo);

            var kyloRen = leila.Children[0];

            kyloRen.BeginsToCry(2);
            kyloRen.BeginsToCry(5);
            kyloRen.BeginsToCry(8);

            var dvj = leila.Children[1];

            dvj.BeginsToCry(9);

            Console.Read();
        }
    }

    class Person
    {
        public Person(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            Name = name;
        }

        public string Name { get; }
    }

    class Parent : Person
    {
        public Parent(string name) : base(name)
        {
            Children = new List<Baby>();
        }

        public List<Baby> Children { get; private set; }
    }

    class Dad : Parent
    {
        public Dad(string name)
            : base(name)
        { }

        public void RecognizeChild(Baby child)
        {
            Console.WriteLine($"Papà {Name} riconosce figlio {child.Name}");
            Children.Add(child);
            child.Cries += ContinuesToSleep;
        }

        public void ContinuesToSleep(Baby cryer, int intensity)
        {
            Console.WriteLine($"Papà {Name} continua a dormire beatamente");
        }
    }

    class Mum : Parent
    {
        public Mum(string name)
            : base(name)
        { }

        public void MakeBaby(string name, Dad dad)
        {
            Console.WriteLine($"Mamma {Name} ha fatto un figlio con {dad.Name}");

            var newBaby = new Baby(name);

            Children.Add(newBaby);

            newBaby.Cries += ComfortsChild;

            dad.RecognizeChild(newBaby);
        }

        private void ComfortsChild(Baby cryer, int intensity)
        {
            if (intensity > 6)
                Console.WriteLine($"Mamma {Name} consola figlio {cryer.Name}");
            else
                Console.WriteLine($"Mamma {Name} continua a dormire");
        }
    }

    class Baby : Person
    {
        public Baby(string name) : base(name)
        { }

        public event BabyCries Cries;

        public void BeginsToCry(int intensity)
        {
            Console.WriteLine($"Bambino {Name} comincia a piangere con intensità {intensity}");

            Cries.Invoke(this, intensity);
        }
    }

    delegate void BabyCries(Baby cryer, int intensity);
}
