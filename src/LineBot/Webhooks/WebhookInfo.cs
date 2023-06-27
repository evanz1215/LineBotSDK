using Newtonsoft.Json;

namespace Line.Webhooks
{
    public class WebhookInfo
    {
        [JsonProperty("endpoint")]
        public string Endpoint;

        [JsonProperty("active")]
        public bool Active;
    }
}