using Line.Converters;
using Newtonsoft.Json;

namespace Line.Actions
{
    public class CameraAction : IAction
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<ActionType>))]
        public ActionType Type => ActionType.Camera;

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}