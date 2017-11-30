using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPlays
{
    static class DeferredExecution
    {
        public static void Play()
        {
            var list = new List<int> { 1, 2, 3, 4 };

            var oddNumbers = list.Where(x => x % 2 != 0);

            list.Add(5);

            foreach(var on in oddNumbers)
                Console.WriteLine(on);

            Console.WriteLine();

            list.Add(7);

            foreach (var on in oddNumbers)
                Console.WriteLine(on);

            var single = list
                .Where(x => x % 2 == 0)
                .Single(x => x < 3);
        }
    }
}
