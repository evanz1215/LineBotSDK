using Line.Converters;
using Newtonsoft.Json;
using System;

namespace Line.Messages.Image
{
    public class ImageMessage : IMessage
    {
        public ImageMessage()
        {
        }

        public ImageMessage(string originalContentUrl, string previewImageUrl)
        {
            OriginalContentUrl = originalContentUrl;
            PreviewImageUrl = previewImageUrl;
        }

        public ImageMessage(Uri originalContentUrl, Uri previewImageUrl)
        {
            OriginalContentUrl = originalContentUrl.ToString();
            PreviewImageUrl = previewImageUrl.ToString();
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<MessageType>))]
        MessageType IMessage.Type => MessageType.Image;

        private string _originalContentUrl;

        [JsonProperty("originalContentUrl")]
        public string OriginalContentUrl
        {
            get { return _originalContentUrl; }
            set { _originalContentUrl = value; }
        }

        private string _previewImageUrl;

        [JsonProperty("previewImageUrl")]
        public string PreviewImageUrl
        {
            get { return _previewImageUrl; }
            set { _previewImageUrl = value; }
        }
    }
}