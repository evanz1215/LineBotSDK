using Line.Converters;
using Newtonsoft.Json;

namespace Line.Messages.Location
{
    public class LocationMessage : IMessage
    {
        public LocationMessage()
        {
        }

        public LocationMessage(string title, string address, decimal latitude, decimal longitude)
        {
            Title = title;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<MessageType>), converterParameters: true)]
        MessageType IMessage.Type => MessageType.Location;

        private string _title;

        [JsonProperty("title")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _address;

        [JsonProperty("address")]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private decimal _latitude;

        [JsonProperty("latitude")]
        public decimal Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        private decimal _longitude;

        [JsonProperty("longitude")]
        public decimal Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
    }
}