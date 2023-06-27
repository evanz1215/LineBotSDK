using Newtonsoft.Json;
using System.Collections.Generic;

namespace Line.RichMenus
{
    public class RichMenu
    {
        [JsonProperty("size")]
        public RichMenuSize Size;

        [JsonProperty("selected")]
        public bool Selected;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("chatBarText")]
        public string ChatBarText;

        [JsonProperty("areas")]
        public IEnumerable<RichMenuArea> Areas;
    }
}