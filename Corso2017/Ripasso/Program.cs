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
            //Baby kyloRen = new Baby("Kylo Ren");
           
            // m.setName("Leila");
            //Console.WriteLine("la mamma creata si chiama " + m.getName());

            
            //m.Age++;
            Console.WriteLine("la mamma creata si chiama " + leila.Name);
            Console.WriteLine("il papà creato si chiama " + hanSolo.Name);
            //hanSolo.RecognizeChild(kyloRen);
            leila.MakeBaby("Kylo Ren", hanSolo);
            leila.MakeBaby("Darth Vader Junior", hanSolo);
            var kyloRen = leila.Children[0]; //indice 0 della lista di bambini: primo elemento 

            kyloRen.BeginsToCry(2);
            kyloRen.BeginsToCry(5);
            kyloRen.BeginsToCry(8);

            var dvj = leila.Children[1];

            dvj.BeginsToCry(9);

            Console.Read();
        }

        class Person
        {
            public Person (string name)
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentNullException("name");
                Name = name;
            }


            //private string name;   //campo (variabile dichiarata)
            //public string getName()  //metodo
            //{
            //    return name;
            //}
            //public void setName(string value)  //metodo
            //{
            //    name = value;
            //}
            //public string Name
            //{
            //    get {    // ritorna il valore
            //        return name;
            //        }

            //    //set {   //come tipo di ritorno è void (quindi non cè)

            //    //    if (value == null || value == "")
            //    //        throw new ArgumentException("Name");
            //    //    name = value;
            //    //    }
            //}
            public string Name { get; }

            //public int Age { get; set; }    // proprietà



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
            //per evitare duplicazione di codice usiamo l'eredità
            public Dad (string name) : base(name)   // siccome in pesone c'è già il costruttore del basta aggiungere base con il parametro di ingresso che vuole la classe person
            {
            }

            public void RecognizeChild(Baby child)
            {
                Console.WriteLine($"Papa {Name} riconosce figlio {child.Name}");
                Children.Add(child);
                child.Cries += ContinueToSleep;
            }

            public void ContinueToSleep(Baby cryer, int intensity)
            {
                Console.WriteLine($"Papà {Name} continua a dormire profondamente");
            }
  
        }

        class Mum : Parent
        {
            //per evitare duplicazione di codice usiamo l'eredità
            public Mum(string name) : base(name)   // siccome in pesone c'è già il costruttore del basta aggiungere base con il parametro di ingresso che vuole la classe person
            {
            }

            public void MakeBaby (string name, Dad dad)
            {
                Console.WriteLine($"Mamma {Name} ha fatto un figlio con {dad.Name}");
                var newBaby = new Baby(name);
                Children.Add(newBaby);
                newBaby.Cries += ComfortsChild;
                dad.RecognizeChild(newBaby);
               
                  // Aggiunge all'evento .Cries il metodo ComfortsChild senza eseguirlo. il metodo verrà eseguito solo allo scatenarsi dell'evento
            }

            private void ComfortsChild(Baby cryer, int intensity)
            {
                if  (intensity > 6) 
                    Console.WriteLine($"Mamma {Name} consola figlio {cryer.Name}");
                else
                    Console.WriteLine($"Mamma {Name} continua a dormire");
            }
            
        }

        class Baby : Person
        {
            public Baby(string name) : base(name)
            {
            }

            public event BabyCries Cries;

            public void BeginsToCry(int intensity)
            {
                Console.WriteLine($"bambino {Name} comincia a piangere con intensità {intensity}");
                Cries.Invoke(this, intensity);
            }
        }
            delegate void BabyCries(Baby cryer, int intensity);

    }
}
