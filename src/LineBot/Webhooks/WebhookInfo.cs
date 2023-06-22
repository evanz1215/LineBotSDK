using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
