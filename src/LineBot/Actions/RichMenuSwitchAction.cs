using Line.Converters;
using Newtonsoft.Json;

namespace Line.Actions
{
    public class RichMenuSwitchAction : IAction
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<ActionType>))]
        public ActionType Type => ActionType.RichMenuSwitch;

        [JsonProperty("richMenuAliasId")]
        public string RichMenuAliasId { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}