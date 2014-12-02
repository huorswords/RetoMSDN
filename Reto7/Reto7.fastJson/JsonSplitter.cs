namespace Reto7
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public static class JsonSplitter
    {
        public static JsonResult SplitShowsByGenre(string json, string genre)
        {
            var result = new JsonResult();
            var genreList = new List<object>();
            var otherList = new List<object>();
            
            object[] collection = (object[])fastJSON.JSON.ToObject(json);
            foreach (Dictionary<string, object> item in collection)
            {
                var genres = ((List<object>)item["genres"]);
                if (genres.Contains(genre))
                {
                    genreList.Add(item);
                }
                else
                {
                    otherList.Add(item);
                }
            }

            fastJSON.JSONParameters param = new fastJSON.JSONParameters();
            param.UseEscapedUnicode = false;

            result.Item1 = fastJSON.JSON.ToJSON(genreList, param);
            result.Item2 = fastJSON.JSON.ToJSON(otherList, param);

            return result;
        }
    }
}
