using Line.Converters;
using Newtonsoft.Json;

namespace Line.Actions
{
    public class LocationAction : IAction
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<ActionType>))]
        public ActionType Type => ActionType.Location;

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}