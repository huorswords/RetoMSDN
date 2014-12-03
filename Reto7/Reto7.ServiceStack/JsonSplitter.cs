namespace Reto7
{
    using ServiceStack.Text;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public static class JsonSplitter
    {
        public static Tuple<string, string> SplitShowsByGenre(string json, string genre)
        {
            ICollection<Show> matches = new Collection<Show>();
            ICollection<Show> others = new Collection<Show>();

            JsConfig.IncludeNullValues = true;

            Show[] collection = JsonSerializer
                .DeserializeFromString<Show[]>(json);

            foreach (var item in collection)
            {
                if (item.genres.Contains(genre))
                {
                    matches.Add(item);
                    continue;
                }

                others.Add(item);
            }

            return new Tuple<string, string>(
                    JsonSerializer.SerializeToString(matches),
                    JsonSerializer.SerializeToString(others));
        }
    }
}
