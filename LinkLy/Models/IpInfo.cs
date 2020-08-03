using Newtonsoft.Json;

namespace LinkLy.Models
{
    /// <summary>
    /// Map model for ip info retrieved from external ipinfo website
    /// </summary>
    public class IpInfo
    {
        [JsonProperty("ip")]
        public string IpNumber { get; set; }

        [JsonProperty("hostname")]
        public string HostName { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("loc")]
        public string Location { get; set; }

        [JsonProperty("org")]
        public string Organisation { get; set; }

        [JsonProperty("postal")]
        public string Postal { get; set; }
    }
}
