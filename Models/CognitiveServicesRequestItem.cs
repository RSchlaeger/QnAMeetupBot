using Newtonsoft.Json;

namespace BasicBot.Models
{
    public class CognitiveServicesRequestItem
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }

        [JsonProperty("domainEndpoint")]
        public string DomainEndpoint { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("imageBytes", NullValueHandling = NullValueHandling.Ignore)]
        public byte[] ImageBytes { get; set; }
    }
}
