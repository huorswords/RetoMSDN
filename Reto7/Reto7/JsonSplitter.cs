namespace Reto7
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Json;
    using System.Text;

    public class JsonSplitter
    {
        public static JsonResult SplitShowsByGenre(string inputShows, string genre)
        {
            Show[] jsonDeserialized = null;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Show[]));
            using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(inputShows)))
            {
                jsonDeserialized = (Show[])serializer.ReadObject(stream);
                stream.Flush();
                stream.Close();
            }

            return new JsonResult
            {
                Item1 = JsonSplitter.GetJsonFrom(serializer, jsonDeserialized.Where(x => x.genres.Contains(genre))).ToString(),
                Item2 = JsonSplitter.GetJsonFrom(serializer, jsonDeserialized.Where(x => !x.genres.Contains(genre))).ToString(),
            };
        }

        private static string GetJsonFrom(DataContractJsonSerializer serializer, IEnumerable<Show> collection)
        {
            string jsonText = string.Empty;

            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, collection.ToArray());
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                    reader.Close();
                }

                stream.Flush();
                stream.Close();
            }

            return jsonText.Replace(@"\/", @"/");
        }
    }
}
