namespace Reto_6
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [DebuggerDisplay("Count = {Count}, ActiveCount = {ActiveCount}")]
    [DebuggerTypeProxy(typeof(CacheDebugView))]
    public class Cache
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Dictionary<int, WeakReference> inner = new Dictionary<int, WeakReference>();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public object this[int key]
        {
            get
            {
                return this.inner[key].Target;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IEnumerable<int>Keys
        {
            get
            {
                return this.inner.Keys;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int Count
        {
            get
            {
                return this.inner.Count;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int ActiveCount
        {
            get
            {
                int count = 0;

                foreach (var current in this.inner.Values)
                {
                    if (current.IsAlive)
                    {
                        count++;
                    }
                }
                
                return count;
            }
        }

        public void Add(int key, object value)
        {
            this.inner.Add(key, new WeakReference(value));
        }

        [DebuggerDisplay("Key = {key}, Value = {value}", Name = "{key}")]
        internal class KeyValuePairs
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private Cache dictionary;

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private object key;

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private object value;

            public KeyValuePairs(Cache dictionary, object key, object value)
            {
                this.value = value;
                this.key = key;
                this.dictionary = dictionary;
            }
        }


        internal class CacheDebugView
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private readonly Cache cache;

            public CacheDebugView(Cache cache)
            {
                this.cache = cache;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public KeyValuePairs[] Keys
            {
                get
                {
                    KeyValuePairs[] keys = new KeyValuePairs[cache.inner.Count];

                    int i = 0;
                    foreach (int key in cache.Keys)
                    {
                        keys[i] = new KeyValuePairs(cache, key, cache[key]);
                        i++;
                    }
                    return keys;
                }
            }
        }
    }
}
