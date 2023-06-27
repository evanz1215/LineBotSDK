using Line.Converters;
using Newtonsoft.Json;
using System;

namespace Line.Actions
{
    public class DateTimePickerAction : IAction
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConverter<ActionType>))]
        public ActionType Type => ActionType.DateTimePicker;

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("mode")]
        [JsonConverter(typeof(EnumConverter<DateTimePickerMode>))]
        public DateTimePickerMode Mode { get; set; }

        [JsonProperty("initial")]
        public string Initial { get; set; }

        [JsonProperty("max")]
        public DateTime Max { get; set; }

        [JsonProperty("min")]
        public DateTime Min { get; set; }
    }
}