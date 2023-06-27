using Newtonsoft.Json;

namespace Line.RichMenus
{
    public class SetRichMenuAliasDto
    {
        public SetRichMenuAliasDto()
        {
        }

        public SetRichMenuAliasDto(string richMenuId, string richMenuAliasId)
        {
            RichMenuId = richMenuId;
            RichMenuAliasId = richMenuAliasId;
        }

        [JsonProperty("richMenuAliasId")]
        public string RichMenuAliasId { get; set; }

        [JsonProperty("richMenuId")]
        public string RichMenuId { get; set; }
    }
}