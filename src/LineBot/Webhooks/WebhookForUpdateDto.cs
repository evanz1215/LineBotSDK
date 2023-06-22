using Newtonsoft.Json;
using System;

namespace Line.Webhooks
{
    public class WebhookForUpdateDto
    {
        public WebhookForUpdateDto()
        {
        }

        public WebhookForUpdateDto(string endpoint)
        {
            Endpoint = endpoint;
        }

        public WebhookForUpdateDto(Uri endpoint)
        {
            Endpoint = endpoint.ToString();
        }

        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }
    }
}