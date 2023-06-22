using Newtonsoft.Json;
using System;

namespace Line.Webhooks
{
    public class WebhookTestResponse
    {
        [JsonProperty("success")]
        public bool Success;

        [JsonProperty("timestamp")]
        public DateTime Timestamp;

        [JsonProperty("statusCode")]
        public int StatusCode;

        [JsonProperty("reason")]
        public string Reason;

        [JsonProperty("detail")]
        public string Detail;
    }
}