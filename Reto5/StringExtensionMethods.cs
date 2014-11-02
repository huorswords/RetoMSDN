using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace Reto5
{
    public static class StringExtensionMethods
    {
        unsafe public static void ToUpperNoCopy(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            fixed (char* p = value)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    p[i] = p[i].ToString().ToUpper()[0];
                }
            }
        }
    }
}
