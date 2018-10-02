using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SampleServer.Domain.ApplicationConfiguration;

namespace SampleServer.Domain.Converters
{
    public class ReaderTypeConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IApplicationReader).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            if (objectType == null) throw new ArgumentNullException(nameof(objectType));
            if (serializer == null) throw new ArgumentNullException(nameof(serializer));
            
            if (reader.TokenType == JsonToken.Null)
            {
                throw new ArgumentOutOfRangeException(nameof(reader), "reader.TokenType can not be null");
            }

            var data = JObject.Load(reader);

            if (data.Type != JTokenType.Object)
            {
                throw new ArgumentOutOfRangeException(nameof(reader), "The object at the readers current position must be an object");
            }

            var typeString = (string)data["type"];
            if (typeString == null || typeString.Equals("Hardware.Reader", StringComparison.OrdinalIgnoreCase))
            {
                var hardwareReader = new ApplicationHardwareReader();
                serializer.Populate(data.CreateReader(), hardwareReader);
                return hardwareReader;
            }

            if (typeString.Equals("SmartIntego.Reader", StringComparison.OrdinalIgnoreCase))
            {
                var siReader = new ApplicationSiReader();
                serializer.Populate(data.CreateReader(), siReader);
                return siReader;
            }

            if (typeString.Equals("Osdp.Reader", StringComparison.OrdinalIgnoreCase))
            {
                var osdpReader = new ApplicationOsdpReader();
                serializer.Populate(data.CreateReader(), osdpReader);
                return osdpReader;
            }

            throw new ArgumentOutOfRangeException(nameof(reader), $"The The object at the readers current position is unknown {typeString}");

        }

        
    }
}
