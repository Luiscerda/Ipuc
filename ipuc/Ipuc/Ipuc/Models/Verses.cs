namespace Ipuc.Models
{
    using Newtonsoft.Json;
    public class Verses
    {
        [JsonProperty("kjv")]
        public Bible Kjv { get; set; }

        [JsonProperty("kjv_strongs")]
        public Bible KjvStrongs { get; set; }

        [JsonProperty("tyndale")]
        public Bible Tyndale { get; set; }

        [JsonProperty("coverdale")]
        public Bible Coverdale { get; set; }

        [JsonProperty("bishops")]
        public Bible Bishops { get; set; }

        [JsonProperty("geneva")]
        public Bible Geneva { get; set; }

        [JsonProperty("tr")]
        public Bible Tr { get; set; }

        [JsonProperty("trparsed")]
        public Bible Trparsed { get; set; }

        [JsonProperty("rv_1858")]
        public Bible Rv1858 { get; set; }

        [JsonProperty("rv_1909")]
        public Bible Rv1909 { get; set; }

        [JsonProperty("sagradas")]
        public Bible Sagradas { get; set; }

        [JsonProperty("rvg")]
        public Bible Rvg { get; set; }

        [JsonProperty("martin")]
        public Bible Martin { get; set; }

        [JsonProperty("epee")]
        public Bible Epee { get; set; }

        [JsonProperty("oster")]
        public Bible Oster { get; set; }

        [JsonProperty("afri")]
        public Bible Afri { get; set; }

        [JsonProperty("svd")]
        public Bible Svd { get; set; }

        [JsonProperty("bkr")]
        public Bible Bkr { get; set; }

        [JsonProperty("stve")]
        public Bible Stve { get; set; }

        [JsonProperty("finn")]
        public Bible Finn { get; set; }

        [JsonProperty("luther")]
        public Bible Luther { get; set; }

        [JsonProperty("diodati")]
        public Bible Diodati { get; set; }

        [JsonProperty("synodal")]
        public Bible Synodal { get; set; }

        [JsonProperty("karoli")]
        public Bible Karoli { get; set; }

        [JsonProperty("lith")]
        public Bible Lith { get; set; }

        [JsonProperty("maori")]
        public Bible Maori { get; set; }

        [JsonProperty("cornilescu")]
        public Bible Cornilescu { get; set; }

        [JsonProperty("thaikjv")]
        public Bible Thaikjv { get; set; }

        [JsonProperty("wlc")]
        public Bible Wlc { get; set; }
    }
}
