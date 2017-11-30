using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPlays
{
    public static class DeferredExecution
    {
        public static void Play()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };

            var oddNumbers = list.Where(x => x % 2 != 0);

            foreach(var dispari in oddNumbers)
            {
                Console.WriteLine(dispari);
            }
        }
    }
}
