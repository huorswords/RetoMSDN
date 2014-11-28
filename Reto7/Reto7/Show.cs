namespace Reto7
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    internal class Images
    {
        [DataMember(Order = 1)]
        public string poster { get; set; }
        [DataMember(Order = 2)]
        public string fanart { get; set; }
        [DataMember(Order = 3)]
        public string banner { get; set; }
    }

    [DataContract]
    internal class Ratings
    {
        [DataMember(Order = 1)]
        public int percentage { get; set; }
        [DataMember(Order = 2)]
        public int votes { get; set; }
        [DataMember(Order = 3)]
        public int loved { get; set; }
        [DataMember(Order = 4)]
        public int hated { get; set; }
    }

    [DataContract]
    internal class Show
    {
        [DataMember(Order = 1)]
        public string title { get; set; }
        [DataMember(Order = 2)]
        public int year { get; set; }
        [DataMember(Order = 3)]
        public string url { get; set; }
        [DataMember(Order = 4)]
        public int first_aired { get; set; }
        [DataMember(Order = 5)]
        public string country { get; set; }
        [DataMember(Order = 6)]
        public string overview { get; set; }
        [DataMember(Order = 7)]
        public int runtime { get; set; }
        [DataMember(Order = 8)]
        public string status { get; set; }
        [DataMember(Order = 9)]
        public string network { get; set; }
        [DataMember(Order = 10)]
        public string air_day { get; set; }
        [DataMember(Order = 11)]
        public string air_time { get; set; }
        [DataMember(Order = 12)]
        public string certification { get; set; }
        [DataMember(Order = 13)]
        public string imdb_id { get; set; }
        [DataMember(Order = 14)]
        public string tvdb_id { get; set; }
        [DataMember(Order = 15)]
        public string tvrage_id { get; set; }
        [DataMember(Order = 16)]
        public string poster { get; set; }
        [DataMember(Order = 17)]
        public Images images { get; set; }
        [DataMember(Order = 18)]
        public int watchers { get; set; }
        [DataMember(Order = 19)]
        public Ratings ratings { get; set; }
        [DataMember(Order = 20)]
        public IList<string> genres { get; set; }
    }
}
