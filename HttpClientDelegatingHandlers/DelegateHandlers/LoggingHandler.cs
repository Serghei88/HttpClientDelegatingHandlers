namespace HttpClientDelegatingHandlers.DelegateHandlers;

public class LoggingHandler: DelegatingHandler
{
    private readonly ILogger<LoggingHandler> _logger;

    public LoggingHandler(ILogger<LoggingHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Before request");
        var result = await base.SendAsync(request, cancellationToken);
        _logger.LogInformation("After request");
        return result;
    }
}