using System.Text.Json;
using System.Text.Json.Serialization;

namespace HelloNet6.JsonConverters;

public class DateTimeJsonConverter : JsonConverter<DateTime>
{
    private string DateFormatString { get; set; } = "yyyy-MM-dd HH:mm:ss";

    public DateTimeJsonConverter()
    {
    }

    public DateTimeJsonConverter(string dateFormatString)
    {
        DateFormatString = dateFormatString;
    }

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.Parse(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToUniversalTime().ToString(DateFormatString));
    }
}