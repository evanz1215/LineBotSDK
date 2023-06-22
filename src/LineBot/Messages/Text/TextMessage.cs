using Line.Converters;
using Newtonsoft.Json;

namespace Line.Messages.Text
{
    public class TextMessage : IMessage
    {
        public TextMessage()
        {
        }

        public TextMessage(string text)
        {
            Text = text;
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<MessageType>), converterParameters: true)]
        MessageType IMessage.Type => MessageType.Text;

        private string _text;

        [JsonProperty("text")]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}