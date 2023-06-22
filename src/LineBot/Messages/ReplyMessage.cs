using Newtonsoft.Json;
using System.Collections.Generic;

namespace Line.Messages
{
    public class ReplyMessage
    {
        public ReplyMessage(string replyToken, IEnumerable<IMessage> messages)
        {
            ReplyToken = replyToken;
            Messages = messages;
        }

        public ReplyMessage(string replyToken, IMessage message)
        {
            ReplyToken = replyToken;
            Messages = new List<IMessage> { message };
        }

        [JsonProperty("replyToken")]
        public string ReplyToken { get; set; }

        [JsonProperty("messages")]
        public IEnumerable<IMessage> Messages { get; }
    }
}