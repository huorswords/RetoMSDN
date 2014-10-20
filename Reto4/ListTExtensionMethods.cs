using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shuffler
{
    public static class ListTExtensionMethods
    {
        static readonly Random generator = new Random();

        public static List<TObject> Shuffle<TObject>(this List<TObject> obj)
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

            return new List<TObject>(input);
        }

        public static TObject[] Swap<TObject>(this TObject[] list, int indexA, int indexB)
        {
            var tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }
    }
}
