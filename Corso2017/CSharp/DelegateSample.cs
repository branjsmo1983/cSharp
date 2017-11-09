using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class DelegateSample
    {
        

        public delegate int Calculate(int a, int b);

        public delegate void EndWork(Person p);

        int Add(int a, int b)
        {
            return a + b;
        }

        int Sub(int a, int b)
        {
            return a - b;
        }

        int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public void Run()
        {
            Calculate add = new Calculate(Add);
            Calculate sub = new Calculate(Sub);

            Console.WriteLine(DoCalculate(add));
            Console.WriteLine(DoCalculate(sub));

            //instanza delegate con lambda
            Calculate max = new Calculate((a, b) =>
            {
                return a > b ? a : b;
            });
            int result = DoCalculate(max);
            Console.WriteLine(result);

            //parametro diretto come puntatore alla funzione
            DoCalculate(Max);

            //parametro diretto come expr. lambda
            DoCalculate(( a, b) =>
            {
                return a * b;
            });

            //stessa cosa per Func<int, int, int>, che è sempre un delegate
            DoCalculateFunc(Max);
            DoCalculateFunc((a, b) => 
            {
                return a * b;
            });

            Person mario = new Person("Mario", "Rossi");
            
            EndWork callback = new EndWork(EndWorkCallback);

            Console.WriteLine(ManipulatePerson(mario, callback));
        }

        public void EndWorkCallback(Person p)
        {
            Console.WriteLine(p.NumeroMani);
        }

        public string ManipulatePerson(Person p, EndWork callback)
        {
            p.NumeroMani += 2;

            callback(p);

            return p.Cognome;
        }

        public int DoCalculate(Calculate calc)
        {
            int a = 2;
            int b = 3;

            int result = calc(a, b);

            return result * 2;
        }

        public int DoCalculateFunc(Func<int, int, int> calc)
        {
            int a = 2;
            int b = 3;

            int result = calc(a, b);

            return result * 2;
        }
    }
}
