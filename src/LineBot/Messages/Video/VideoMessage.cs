using Line.Converters;
using Newtonsoft.Json;
using System;

namespace Line.Messages.Video
{
    public class VideoMessage : IMessage
    {
        public VideoMessage()
        {
        }

        public VideoMessage(string originalContentUrl, string previewImageUrl, string trackingId)
        {
            OriginalContentUrl = originalContentUrl;
            PreviewImageUrl = previewImageUrl;
            TrackingId = trackingId;
        }

        public VideoMessage(string originalContentUrl, string previewImageUrl) : this(originalContentUrl, previewImageUrl, Guid.NewGuid().ToString())
        {
        }

        public VideoMessage(Uri originalContentUrl, Uri previewImageUrl, string trackingId) : this(originalContentUrl.ToString(), previewImageUrl.ToString(), trackingId)
        {
        }

        public VideoMessage(Uri originalContentUrl, Uri previewImageUrl) : this(originalContentUrl, previewImageUrl, Guid.NewGuid().ToString())
        {
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<MessageType>), converterParameters: true)]
        MessageType IMessage.Type => MessageType.Video;

        private string _originalContentUrl, _previewImageUrl, _trackingId;

        /// <summary>
        /// 影音網址
        /// </summary>
        [JsonProperty("originalContentUrl")]
        public string OriginalContentUrl
        {
            get { return _originalContentUrl; }
            set { _originalContentUrl = value; }
        }

        /// <summary>
        /// 影片預覽圖片網址
        /// </summary>
        [JsonProperty("previewImageUrl")]
        public string PreviewImageUrl
        {
            get { return _previewImageUrl; }
            set { _previewImageUrl = value; }
        }

        /// <summary>
        /// 給Video一個ID，用來追蹤影片觀看狀況
        /// (也許可以考慮固定給一個UUID)
        /// </summary>
        [JsonProperty("trackingId")]
        public string TrackingId
        {
            get { return _trackingId; }
            set { _trackingId = value; }
        }
    }
}