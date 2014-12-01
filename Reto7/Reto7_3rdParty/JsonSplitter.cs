using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto7
{
    using Newtonsoft.Json;

    public class JsonSplitter
    {
        public static JsonResult SplitShowsByGenre(string jsonString, string genre)
        {
            Show[] collection = JsonConvert.DeserializeObject<Show[]>(jsonString);

            return new JsonResult
            {
                Item1 = JsonConvert.SerializeObject(collection.Where(x => x.genres.Contains(genre))),
                Item2 = JsonConvert.SerializeObject(collection.Where(x => !x.genres.Contains(genre))),
            };            
        }
    }
}
