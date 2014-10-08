

namespace ObjectDumper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ObjectDumper<TObject>
    {
        private Dictionary<Func<TObject, object>, Func<dynamic, string>> _templateMappings =
            new Dictionary<Func<TObject, object>, Func<dynamic, string>>();
        public IEnumerable<KeyValuePair<string, string>> Dump(TObject obj)
        {
            if (obj == null)
            {
                yield break;
            }

            var properties = obj.GetType()
                .GetProperties()
                .OrderBy(p => p.Name)
                .Where(p => p.CanRead);

            foreach (var propertyInfo in properties)
            {
                bool found = false;
                foreach (var mapping in _templateMappings)
                {
                    var propertyType = mapping.Key(obj).GetType();
                    if (propertyType == propertyInfo.PropertyType)
                    {
                        found = true;
                        yield return
                            new KeyValuePair<string, string>(propertyInfo.Name, mapping.Value(propertyInfo.GetValue(obj)));
                    }
                }

                if (!found)
                {
                    yield return
                        new KeyValuePair<string, string>(propertyInfo.Name, propertyInfo.GetValue(obj).ToString());
                }
            }
        }

        public void AddTemplateFor(Func<TObject, object> propertySelectorFunc, Func<dynamic, string> dumperFunc)
        {
            this._templateMappings.Add(propertySelectorFunc, dumperFunc);
        }
    }
}
