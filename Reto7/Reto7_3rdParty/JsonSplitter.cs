namespace Reto7
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;

    public class JsonSplitter
    {
        public static Tuple<string, string> SplitShowsByGenre(string jsonString, string genre)
        {
            var groups = JsonConvert.DeserializeObject<Show[]>(jsonString)
                .ToLookup(x => x.genres.Contains(genre));

            return new Tuple<string, string>(
                JsonConvert.SerializeObject(groups[true]),
                JsonConvert.SerializeObject(groups[false]));
        }
    }
}
