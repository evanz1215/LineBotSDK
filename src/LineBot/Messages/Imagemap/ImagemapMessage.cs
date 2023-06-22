using Line.Converters;
using Newtonsoft.Json;

namespace Line.Messages.Imagemap
{
    public class ImagemapMessage : IMessage
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<MessageType>), converterParameters: true)]
        MessageType IMessage.Type => MessageType.Imagemap;
    }
}