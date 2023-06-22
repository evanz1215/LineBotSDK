using Newtonsoft.Json;
using System.Collections.Generic;

namespace Line.Messages
{
    public class BroadcastMessage
    {
        public BroadcastMessage(IEnumerable<IMessage> messages)
        {
            Messages = messages;
        }

        public BroadcastMessage(IMessage message)
        {
            Messages = new List<IMessage> { message };
        }

        [JsonProperty("messages")]
        public IEnumerable<IMessage> Messages { get; }
    }
}