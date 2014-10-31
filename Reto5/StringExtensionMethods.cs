using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reto5
{
    public static class StringExtensionMethods
    {
        public static void ToUpperNoCopy(this string original)
        {
            if (null == original)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
