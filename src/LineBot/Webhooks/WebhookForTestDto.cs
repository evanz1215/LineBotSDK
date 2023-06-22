using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Line.Webhooks
{
    public class WebhookForTestDto
    {
        public WebhookForTestDto()
        {
        }

        public WebhookForTestDto(string endpoint)
        {
            Endpoint = endpoint;
        }

        public WebhookForTestDto(Uri endpoint)
        {
            Endpoint = endpoint.ToString();
        }

        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }
    }
}
