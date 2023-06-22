using Newtonsoft.Json;
using System;
using System.Reflection;

namespace Line.Converters
{
    /// <summary>
    /// 將Enum轉換為字串
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    public class EnumConverter<TEnum> : JsonConverter where TEnum : struct, Enum
    {
        private bool _lowercase;

        public EnumConverter() : this(true)
        {
        }

        public EnumConverter(bool lowercase)
        {
            _lowercase = lowercase;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.GetTypeInfo().IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                string value = reader.Value.ToString();
                if (Enum.TryParse<TEnum>(value, true, out var enumValue))
                {
                    return enumValue;
                }
            }
            throw new JsonSerializationException($"Unable to convert value '{reader.Value}' to {typeof(TEnum).Name}.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string stringValue = value.ToString();
            if (_lowercase)
            {
                stringValue = stringValue.ToLowerInvariant();
            }

            writer.WriteValue(stringValue);
        }
    }
}