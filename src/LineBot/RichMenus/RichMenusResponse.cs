using Newtonsoft.Json;
using System.Collections.Generic;

namespace Line.RichMenus
{
    public class RichMenusResponse
    {
        [JsonProperty("richmenus")]
        public IEnumerable<RichMenuResponse> RichMenus { get; set; }
    }
}