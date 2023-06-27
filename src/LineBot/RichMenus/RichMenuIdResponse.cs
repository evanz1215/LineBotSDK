using Newtonsoft.Json;

namespace Line.RichMenus
{
    public class RichMenuIdResponse
    {
        [JsonProperty("richMenuId")]
        public string RichMenuId { get; set; }
    }
}