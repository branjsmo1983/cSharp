using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    static class ListExtension
    {
        public static int Max(this List<int> list)
        {
            int max = list[0];
            foreach(var i in list)
            {
                if(i > max)
                {
                    max = i;
                }
            }
            return max;
        }
    }
}
