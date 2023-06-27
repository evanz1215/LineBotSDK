using Line.Actions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Reflection;

namespace Line.Converters
{
    public class ActionConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(IAction))
                return true;

            return objectType.GetTypeInfo().ImplementedInterfaces.Any(type => type == typeof(IAction));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            var type = obj.GetValue("type");

            var typeName = type.Value<string>();

            IAction action;

            switch (typeName.ToLowerInvariant())
            {
                case "camera":
                    action = new CameraAction();
                    break;

                case "cameraRoll":
                    action = new CameraRollAction();
                    break;

                case "datetimepicker":
                    action = new DateTimePickerAction();
                    break;

                case "location":
                    action = new LocationAction();
                    break;

                case "message":
                    action = new MessageAction();
                    break;

                case "postback":
                    action = new PostbackAction();
                    break;

                case "uri":
                    action = new UriAction();
                    break;

                case "richmenuswitch":
                    action = new RichMenuSwitchAction();
                    break;

                default:
                    throw new Exception();
            }

            serializer.Populate(obj.CreateReader(), action);

            return action;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }
}