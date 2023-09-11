using System.Text.Json.Serialization;

namespace HttpClientDelegatingHandlers;

public class CurrentResponse
{
    [JsonPropertyName("location")]
    public Location Location { get; set; }
    [JsonPropertyName("current")]
    public Current Current { get; set; }
}