namespace Reto2ClassLibrary
{
    using System;
    using System.Collections;

    public class Reto2 : IReto2
    {
        private SortedList events = new SortedList();
        private event EventHandler MyPrivateEventFired;

        public event System.EventHandler EventFired
        {
            add
            {
                events.Add(((Item)value.Target).Index, value);
            }
            remove
            {
                events.Remove(((Item)value.Target).Index);
            }
        }

        public void FireEvent()
        {
            this.PerformActionOnEvents(RegisterEvent);

            if (MyPrivateEventFired != null)
            {
                MyPrivateEventFired(this, null);
            }

            this.PerformActionOnEvents(UnregisterEvent);
            this.events.Clear();
        }

        private void PerformActionOnEvents(Action<object> action)
        {
            for (int i = 0; i < events.Count; i++)
            {
                action((EventHandler)events.GetByIndex(i));
            }
        }

        private void RegisterEvent(object handler)
        {
            MyPrivateEventFired += (EventHandler)handler;
        }

        private void UnregisterEvent(object handler)
        {
            MyPrivateEventFired -= (EventHandler)handler;
        }
    }
}