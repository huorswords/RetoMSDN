namespace Reto2ClassLibrary
{
    using System;
    using System.Linq;

    public class Reto2 : IReto2
    {
        private event EventHandler privateEventFired;

        public event EventHandler EventFired
        {
            add
            {
                // Only allow to register 'Item' objects.
                if (value != null && value.Target.GetType().IsAssignableFrom(typeof(Item)))
                {
                    privateEventFired += value;
                }
            }
            remove
            {
                privateEventFired -= value;
            }
        }
        

        public void FireEvent()
        {
            if (privateEventFired != null)
            {
                var invocationCollection = privateEventFired.GetInvocationList()
                    .OrderBy(x => ((Item)x.Target).Index);

                foreach (var item in invocationCollection)
                {
                    item.DynamicInvoke(this, null);
                }
            }
        }
    }
}