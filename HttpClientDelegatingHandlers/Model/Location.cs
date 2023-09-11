using System.Text.Json.Serialization;

namespace HttpClientDelegatingHandlers;

public class Location
{
        /// <summary>
        /// Local area name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Local area region.
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Area latitude
        /// </summary>
        [JsonPropertyName("lat")]
        public double? Lat { get; set; }

        /// <summary>
        /// Area longitude
        /// </summary>
        [JsonPropertyName("lon")]
        public double? Lon { get; set; }
        

        /// <summary>
        /// Time zone
        /// </summary>
        [JsonPropertyName("tz_id")]
        public string TzId { get; set; }

        /// <summary>
        /// Local date and time in unix time
        /// </summary>
        [JsonPropertyName("localtime_epoch")]
        public int? LocaltimeEpoch { get; set; }

        /// <summary>
        /// Local date and time
        /// </summary>
        [JsonPropertyName("localtime")]
        public string Localtime { get; set; }
}