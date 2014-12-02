namespace Reto7
{
    using Newtonsoft.Json;
    using System.Linq;

    public class JsonSplitter
    {
        public static JsonResult SplitShowsByGenre(string jsonString, string genre)
        {
            var groups = JsonConvert.DeserializeObject<Show[]>(jsonString)
                .ToLookup(x => x.genres.Contains(genre));

            return new JsonResult
            {
                Item1 = JsonConvert.SerializeObject(groups[true]),
                Item2 = JsonConvert.SerializeObject(groups[false]),
            };            
        }
    }
}
