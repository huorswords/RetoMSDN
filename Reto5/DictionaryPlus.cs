namespace Reto5
{
    using System.Collections.Generic;
    using System.Linq;

    public class DictionaryPlus<TKey, TValue>
        : Dictionary<TKey, TValue>
    {
        public IEnumerable<TValue> this[params TKey[] collection]
        {
            get
            {
                foreach (TKey item in collection)
                {
                    if (this.ContainsKey(item))
                    {
                        var value = this.Single(x => x.Key.Equals(item)).Value;
                        yield return value;
                    }
                    else
                    {
                        throw new KeyNotFoundException();
                    }
                }
            }
        }
    }
}
