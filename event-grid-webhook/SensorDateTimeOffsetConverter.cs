using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EventGridWebhook
{
    public class SensorDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var raw = reader.GetString();
            //2019/11/16T03:47:54z
            return DateTimeOffset.ParseExact(raw, "yyyy/MM/ddTHH:mm:ss\\z", CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy/mm/ddTHH:MM:ss\\z"));
        }
    }
}