using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 23, 1, 65, 24, -4, 12 };
            var maxList = list.Max();
            //La riga precendente è esattamente equivalente a questa:
            //var maxList = ListExtension.Max(list);

            Console.WriteLine("Il max della List<int> è: " + maxList);

            var array = new[] { 23, 1, 65, 24, -4, 12  };
            var maxArray = array.Max();
            //La riga precendente è esattamente equivalente a questa:
            //var maxArray = ArrayExtension.Max(array);

            Console.WriteLine("Il max dell'array di int è: " + maxArray);

            Console.Read();

            ReadOnlyCollection<int> r;
        }
    }

    //static class ListExtension
    //{
    //    public static int Max(this List<int> list)
    //    {
    //        int max = list[0];

    //        foreach (var i in list)
    //            if (i > max)
    //                max = i;

    //        return max;
    //    }
    //}

    //static class ArrayExtension
    //{
    //    public static int Max(this int[] array)
    //    {
    //        int max = array[0];

    //        for (int i = 1; i < array.Length; i++)
    //            if (array[i] > max)
    //                max = array[i];

    //        return max;
    //    }
    //}

    public static class EnumerableExtension
    {
        public static int Max(this IEnumerable<int> enumerable)
        {
            int max = int.MinValue;

            foreach (var i in enumerable)
                if (i > max)
                    max = i;

            return max;
        }
    }
}
