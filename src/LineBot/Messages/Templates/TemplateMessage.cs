using Line.Converters;
using Newtonsoft.Json;

namespace Line.Messages.Templates
{
    public class TemplateMessage : IMessage
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<MessageType>), converterParameters: true)]
        MessageType IMessage.Type => MessageType.Template;
    }
}