using System.Text.Json.Serialization;

namespace HttpClientDelegatingHandlers;

public class Current
{
    /// <summary>
    /// Local time when the real time data was updated in unix time.
    /// </summary>
    [JsonPropertyName("last_updated_epoch")]
    public int? LastUpdatedEpoch { get; set; }

    /// <summary>
    /// Local time when the real time data was updated.
    /// </summary>
    [JsonPropertyName("last_updated")]
    public string LastUpdated { get; set; }

    /// <summary>
    /// Temperature in celsius
    /// </summary>
    [JsonPropertyName("temp_c")]
    public double? TempC { get; set; }

    /// <summary>
    /// Temperature in fahrenheit
    /// </summary>
    [JsonPropertyName("temp_f")]
    public double? TempF { get; set; }

    /// <summary>
    /// 1 = Yes 0 = No <br />Whether to show day condition icon or night icon
    /// </summary>
    [JsonPropertyName("is_day")]
    public int? IsDay { get; set; }

    /// <summary>
    /// TODO: Write general description for this method
    /// </summary>
    [JsonPropertyName("condition")]
    public Condition Condition { get; set; }

    /// <summary>
    /// Wind speed in miles per hour
    /// </summary>
    [JsonPropertyName("wind_mph")]
    public double? WindMph { get; set; }

    /// <summary>
    /// Wind speed in kilometer per hour
    /// </summary>
    [JsonPropertyName("wind_kph")]
    public double? WindKph { get; set; }

    /// <summary>
    /// Wind direction in degrees
    /// </summary>
    [JsonPropertyName("wind_degree")]
    public int? WindDegree { get; set; }

    /// <summary>
    /// Wind direction as 16 point compass. e.g.: NSW
    /// </summary>
    [JsonPropertyName("wind_dir")]
    public string WindDir { get; set; }

    /// <summary>
    /// Pressure in millibars
    /// </summary>
    [JsonPropertyName("pressure_mb")]
    public double? PressureMb { get; set; }

    /// <summary>
    /// Pressure in inches
    /// </summary>
    [JsonPropertyName("pressure_in")]
    public double? PressureIn { get; set; }

    /// <summary>
    /// Precipitation amount in millimeters
    /// </summary>
    [JsonPropertyName("precip_mm")]
    public double? PrecipMm { get; set; }

    /// <summary>
    /// Precipitation amount in inches
    /// </summary>
    [JsonPropertyName("precip_in")]
    public double? PrecipIn { get; set; }

    /// <summary>
    /// Humidity as percentage
    /// </summary>
    [JsonPropertyName("humidity")]
    public int? Humidity { get; set; }

    /// <summary>
    /// Cloud cover as percentage
    /// </summary>
    [JsonPropertyName("cloud")]
    public int? Cloud { get; set; }

    /// <summary>
    /// Feels like temperature as celcius
    /// </summary>
    [JsonPropertyName("feelslike_c")]
    public double? FeelslikeC { get; set; }

    /// <summary>
    /// Feels like temperature as fahrenheit
    /// </summary>
    [JsonPropertyName("feelslike_f")]
    public double? FeelslikeF { get; set; }

    /// <summary>
    /// TODO: Write general description for this method
    /// </summary>
    [JsonPropertyName("vis_km")]
    public double? VisKm { get; set; }

    /// <summary>
    /// TODO: Write general description for this method
    /// </summary>
    [JsonPropertyName("vis_miles")]
    public double? VisMiles { get; set; }

    /// <summary>
    /// UV Index
    /// </summary>
    [JsonPropertyName("uv")]
    public double? Uv { get; set; }

    /// <summary>
    /// Wind gust in miles per hour
    /// </summary>
    [JsonPropertyName("gust_mph")]
    public double? GustMph { get; set; }

    /// <summary>
    /// Wind gust in kilometer per hour
    /// </summary>
    [JsonPropertyName("gust_kph")]
    public double? GustKph { get; set; }
}