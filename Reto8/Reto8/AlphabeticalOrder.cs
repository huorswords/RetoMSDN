namespace Reto8
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    // In order to execute it correctly, download and install:
    // *    https://visualstudiogallery.msdn.microsoft.com/1ec7db13-3363-46c9-851f-1ce455f66970
    public class AlphabeticalOrder
    {
        public static string GetShortestConcatString(string value)
        {
            Contract.Requires<ArgumentNullException>(null != value);

            var permutationResults = new List<string>();
            var words = value.Split(' ').OrderBy(s => s).ToArray();

            do
            {
                permutationResults.Add(words.Aggregate((current, next) => current + next));
            }
            while (Permutator.NextPermutation(ref words));

            return permutationResults.OrderBy(s => s).First();
        }

        public static IEnumerable<string> GetShortestConcatString(IEnumerable<string> collection)
        {
            return GetShortestConcatString(collection.ToArray());
        }

        public static IEnumerable<string> GetShortestConcatString(params string[] array)
        {
            Contract.Requires<ArgumentNullException>(null != array && !array.Contains(null));

            foreach (var phrase in array)
            {
                yield return GetShortestConcatString(phrase);
            }
        }

        // Adapted solution from http://stackoverflow.com/a/11208543/982431 to perform permutations for string arrays.
        // Thank you @Sani-huttunen: http://stackoverflow.com/users/26742/sani-huttunen
        internal class Permutator
        {            
            public static bool NextPermutation(ref string[] wordList)
            {
                /*
                 Knuths
                 1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
                 2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
                 3. Swap a[j] with a[l].
                 4. Reverse the sequence from a[j + 1] up to and including the final element a[n].

                 */
                var largestIndex = -1;
                for (var i = wordList.Length - 2; i >= 0; i--)
                {
                    if (wordList[i].CompareTo(wordList[i + 1]) < 0)
                    {
                        largestIndex = i;
                        break;
                    }
                }

                if (largestIndex < 0)
                {
                    return false;
                }

                var largestIndex2 = -1;
                for (var i = wordList.Length - 1; i >= 0; i--)
                {
                    if (wordList[largestIndex].CompareTo(wordList[i]) < 0)
                    {
                        largestIndex2 = i;
                        break;
                    }
                }

                var tmp = wordList[largestIndex];
                wordList[largestIndex] = wordList[largestIndex2];
                wordList[largestIndex2] = tmp;

                for (int i = largestIndex + 1, j = wordList.Length - 1; i < j; i++, j--)
                {
                    tmp = wordList[i];
                    wordList[i] = wordList[j];
                    wordList[j] = tmp;
                }

                return true;
            }
        }
    }
}
