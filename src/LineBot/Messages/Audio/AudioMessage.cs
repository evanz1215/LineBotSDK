using Line.Converters;
using Newtonsoft.Json;
using System;

namespace Line.Messages.Audio
{
    public class AudioMessage : IMessage
    {
        public AudioMessage()
        {
        }

        public AudioMessage(string originalContentUrl, int duration)
        {
            OriginalContentUrl = originalContentUrl;
            Duration = duration;
        }

        public AudioMessage(Uri originalContentUrl, int duration) : this(originalContentUrl.ToString(), duration)
        {
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<MessageType>), converterParameters: true)]
        MessageType IMessage.Type => MessageType.Audio;

        private string _originalContentUrl;

        [JsonProperty("originalContentUrl")]
        public string OriginalContentUrl
        {
            get { return _originalContentUrl; }
            set { _originalContentUrl = value; }
        }

        private int _duration;

        [JsonProperty("duration")]
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
    }
}