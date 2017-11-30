﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 23, 1, 65, 24, -4, 12 };

            var max = list.MaxEnum();

           // max = ListExtension.Max(list); se nella dichiarazione del metodo Max non mettevo this potevo usarlo cosi

            Console.WriteLine("Il max è: " + max);

            Console.Read();
        }
    }

    static class ListExtension
    {
        public static int Max(this List<int> list)
        {
            int max = list[0];

            foreach (var i in list)
            {
                if (i > max)
                {
                    max = i;
                }
            }

            //for(int i = 1; i < list.Count; i++)
            //{
            //    if (list[i] > max)
            //    {
            //        max = list[i];
            //    }
            //}

            return max;
        }

        public static int MaxEnum(this IEnumerable<int> enumerable)
        {
            var max = int.MinValue;
            

            foreach (var i in enumerable)
            {
                if (i > max)
                {
                    max = i;
                }
            }
            return max;
        }
    }
}
