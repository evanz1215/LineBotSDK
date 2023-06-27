using Line.Converters;
using Newtonsoft.Json;
using System;

namespace Line.Actions
{
    public class UriAction : IAction
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<ActionType>))]
        public ActionType Type => ActionType.Uri;

        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        // altUri

    }
}