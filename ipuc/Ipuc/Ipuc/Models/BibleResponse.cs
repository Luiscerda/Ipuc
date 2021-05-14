namespace Ipuc.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    public class BibleResponse
    {
        [JsonProperty("error_level")]
        public long ErrorLevel { get; set; }

        [JsonProperty("results")]
        public Dictionary<string, Bible> Bibles { get; set; }
    }
}
