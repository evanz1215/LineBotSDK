using Newtonsoft.Json;
using System.Collections.Generic;

namespace Line.Messages
{
    public class MulticastMessage
    {
        public MulticastMessage(IEnumerable<string> to, IEnumerable<IMessage> messages)
        {
            To = to;
            Messages = messages;
        }

        public MulticastMessage(IEnumerable<string> to, IMessage messages)
        {
            To = to;
            Messages = new List<IMessage> { messages };
        }

        [JsonProperty("to")]
        public IEnumerable<string> To { get; set; }

        [JsonProperty("messages")]
        public IEnumerable<IMessage> Messages { get; }
    }
}