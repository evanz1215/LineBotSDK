using Newtonsoft.Json;

namespace Line.RichMenus
{
    public class RichMenuResponse : RichMenu
    {
        [JsonProperty("richMenuId")]
        public string Id { get; set; }
    }
}