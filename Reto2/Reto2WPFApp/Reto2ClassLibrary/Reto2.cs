namespace Reto2ClassLibrary
{
    using System.Linq;

    public class Reto2 : IReto2
    {
        public event System.EventHandler EventFired;

        public void FireEvent()
        {
            if (EventFired != null)
            {
                var invocationCollection = EventFired.GetInvocationList()
                    .Where(x => x.Target.GetType().Equals(typeof(Item)))
                    .OrderBy(x => ((Item)x.Target).Index);

                foreach (var item in invocationCollection)
                {
                    item.DynamicInvoke(this, null);
                }
            }
        }
    }
}