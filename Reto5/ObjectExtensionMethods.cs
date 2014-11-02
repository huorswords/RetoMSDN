namespace Reto5
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public static class ObjectExtensionMethods
    {
        public static TType NotNull<TType>(this TType obj) where TType : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            return obj;
        }

        public static TType NotNull<TType>(this TType obj, string name) where TType : class
        {
            if (obj == null)
            { 
                StackFrame[] frames = new StackTrace().GetFrames();

                StackFrame lastFrame = frames.First(x => x.GetMethod().DeclaringType != MethodBase.GetCurrentMethod().DeclaringType);

                StringBuilder builder = new StringBuilder();

                builder.Append(lastFrame.GetMethod().Name);
                builder.Append(" was called with null parameter");

                throw new ArgumentNullException(name, builder.ToString());
            }

            return obj;
        }
    }
}
