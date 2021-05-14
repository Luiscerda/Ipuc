namespace Ipuc.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    public class BookResponse
    {
        [JsonProperty("error_level")]
        public long ErrorLevel { get; set; }

        [JsonProperty("results")]
        public List<Book> Books { get; set; }
    }
}
