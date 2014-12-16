using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Reto8
{
    public class AlphabeticalOrder
    {
        public static string GetShortestConcatString(string value)
        {
            return GetShortestConcatString(new string[] { value }).First();
        }

        public static IEnumerable<string> GetShortestConcatString(IEnumerable<string> collection)
        {
            return GetShortestConcatString(collection.ToArray());
        }

        public static IEnumerable<string> GetShortestConcatString(params string[] array)
        {
            // In order to execute it correctly, download and install:
            // *    https://visualstudiogallery.msdn.microsoft.com/1ec7db13-3363-46c9-851f-1ce455f66970
            Contract.Requires<ArgumentNullException>(null != array && !array.Contains(null));

            foreach (var item in array)
            {
                yield return item
                    .Split(' ')
                    .OrderBy(s => s.ToLower())
                    .Aggregate((current, next) => current + next);
            }
        }
    }
}
