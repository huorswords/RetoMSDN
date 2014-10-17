using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shuffler
{
    public static class ListTExtensionMethods
    {
        static readonly Random generator = new Random();
        
        public static List<int> Shuffle(this List<int> obj)
        {
            var input = obj.ToArray();
            for (var top = input.Length - 1; top > 0; --top)
            {
                var swap =
                    generator.Next(0, top);
                while (swap == top)
                {
                    swap =
                        generator.Next(0, top);
                }
                
                input.Swap(top, swap);
            }

            return new List<int>(input);
        }

        public static int[] Swap(this int[] list, int indexA, int indexB)
        {
            int tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }
    }
}
