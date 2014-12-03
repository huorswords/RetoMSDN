namespace Reto7
{
    using fastJSON;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public static class JsonSplitter
    {
        public static Tuple<string, string> SplitShowsByGenre(string json, string genre)
        {
            var genreList = new ArrayList();
            var otherList = new ArrayList();

            foreach (Dictionary<string, object> item in (object[])JSON.ToObject(json))
            {
                if (((List<object>)item["genres"]).Contains(genre))
                {
                    genreList.Add(item);
                    continue;
                }

                otherList.Add(item);
            }

            JSONParameters param = new JSONParameters { UseEscapedUnicode = false };
            return new Tuple<string, string>(
                JSON.ToJSON(genreList, param), 
                JSON.ToJSON(otherList, param));
        }
    }
}
