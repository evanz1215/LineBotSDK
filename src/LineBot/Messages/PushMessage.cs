using Newtonsoft.Json;
using System.Collections.Generic;

namespace Line.Messages
{
    public class PushMessage
    {
        public PushMessage(string to, IEnumerable<IMessage> messages)
        {
            To = to;
            Messages = messages;
        }

        public PushMessage(string to, IMessage message)
        {
            To = to;
            Messages = new List<IMessage> { message };
        }

        [JsonProperty("to")]
        public string To { get; }

        [JsonProperty("messages")]
        public IEnumerable<IMessage> Messages { get; }
    }
}