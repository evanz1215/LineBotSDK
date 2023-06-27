using Line.Converters;
using Newtonsoft.Json;

namespace Line.Actions
{
    public class PostbackAction : IAction
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<ActionType>))]
        public ActionType Type => ActionType.Postback;

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        /// <summary>
        /// Line version 12.6.0 or later
        /// </summary>
        [JsonProperty("inputOption")]
        public string inputOption { get; set; }

        [JsonProperty("fillInText")]
        public string FillInText { get; set; }
    }
}