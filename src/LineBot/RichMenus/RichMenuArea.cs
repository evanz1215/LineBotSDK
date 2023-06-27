using Line.Actions;
using Line.Converters;
using Newtonsoft.Json;

namespace Line.RichMenus
{
    public class RichMenuArea
    {
        [JsonProperty("action")]
        [JsonConverter(typeof(ActionConverter))]
        public IAction Action { get; set; }

        [JsonProperty("bounds")]
        public RichMenuBounds Bounds { get; set; }
    }
}