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
            TObject[] input = obj.ToArray();
            int swap;
            for (var top = input.Length - 1; top > 0; --top)
            {
                swap = generator.Next(top);
                Swap(ref input[top], ref input[swap]);
            }

            return new List<TObject>(input);
        }
        
        private static void Swap<TObject>(ref TObject first, ref TObject second)
        {
            TObject tmp = first;
            first = second;
            second = tmp;
        }
    }
}
