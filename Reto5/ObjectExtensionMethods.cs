namespace Reto5
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public static class ObjectExtensionMethods
    {
        public static object NotNull(this object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            return obj;
        }

        public static object NotNull(this object obj, string name)
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
