using Line.Converters;
using Newtonsoft.Json;

namespace Line.Actions
{
    public class MessageAction : IAction
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<ActionType>))]
        public ActionType Type => ActionType.Message;

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}