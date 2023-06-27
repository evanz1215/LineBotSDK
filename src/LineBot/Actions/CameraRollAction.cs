using Line.Converters;
using Newtonsoft.Json;

namespace Line.Actions
{
    public class CameraRollAction : IAction
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<ActionType>))]
        public ActionType Type => ActionType.CameraRoll;

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}