namespace HttpClientDelegatingHandlers;

public interface IWeatherService
{
    public Task<CurrentResponse?> GetCurrent(string city);
}