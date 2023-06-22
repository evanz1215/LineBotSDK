using Newtonsoft.Json;

namespace Line.Bots
{
    public class BotInfo
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("basicId")]
        public string BasicId { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("chatMode")]
        public string ChatMode { get; set; }

        [JsonProperty("markAsReadMode")]
        public string MarkAsReadMode { get; set; }
    }
}