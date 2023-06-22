using Line.Converters;
using Newtonsoft.Json;

namespace Line.Messages.Sticker
{
    public class StickerMessage : IMessage
    {
        public StickerMessage()
        {
        }

        public StickerMessage(string packageId, string stickerId)
        {
            PackageId = packageId;
            StickerId = stickerId;
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<MessageType>), converterParameters: true)]
        MessageType IMessage.Type => MessageType.Sticker;

        private string _packageId;

        [JsonProperty("packageId")]
        public string PackageId
        {
            get { return _packageId; }
            set { _packageId = value; }
        }

        private string _stickerId;

        [JsonProperty("stickerId")]
        public string StickerId
        {
            get { return _stickerId; }
            set { _stickerId = value; }
        }
    }
}