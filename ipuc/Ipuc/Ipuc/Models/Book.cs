namespace Ipuc.Models
{
    using Newtonsoft.Json;
    public class Book
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortname")]
        public string ShortName { get; set; }
    }
}
