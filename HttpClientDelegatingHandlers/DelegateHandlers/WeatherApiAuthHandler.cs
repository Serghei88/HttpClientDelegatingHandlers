using Microsoft.Extensions.Options;

namespace HttpClientDelegatingHandlers.DelegateHandlers;

public class WeatherApiAuthHandler: DelegatingHandler
{
    private readonly IOptionsMonitor<WeatherApiConfig> config;

    public WeatherApiAuthHandler(IOptionsMonitor<WeatherApiConfig> config)
    {
        this.config = config;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("key", config.CurrentValue.Key);
        return base.SendAsync(request, cancellationToken);
    }
    
}