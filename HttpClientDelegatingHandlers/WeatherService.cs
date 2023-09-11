namespace HttpClientDelegatingHandlers;

public class WeatherService: IWeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CurrentResponse?> GetCurrent(string city)
    {
        var response = await _httpClient.GetFromJsonAsync<CurrentResponse>($@"/v1/current.json?q={city}");
        return response;
    }
}