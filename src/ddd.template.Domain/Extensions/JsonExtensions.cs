using System.Text.Json;

namespace ddd.template.Domain.Extensions
{
public static class JsonExtensions
{
    public static bool IsValid(string json)
    {
        try
        {
            JsonDocument.Parse(json);
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}
}
