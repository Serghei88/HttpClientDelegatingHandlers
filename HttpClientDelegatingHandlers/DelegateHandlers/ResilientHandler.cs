using Polly;
using Polly.Retry;

namespace HttpClientDelegatingHandlers.DelegateHandlers;

public class ResilientHandler : DelegatingHandler
{
    private readonly ILogger<ResilientHandler> _logger;

    private readonly AsyncRetryPolicy<HttpResponseMessage> _asyncRetryPolicy;

    public ResilientHandler(ILogger<ResilientHandler> logger)
    {
        _logger = logger;
        _asyncRetryPolicy =
            Policy<HttpResponseMessage>
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    onRetry: (ex, count, context) =>
                    {
                        _logger.LogError("Http request failed ...");
                    });
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var policyResult = await _asyncRetryPolicy.ExecuteAndCaptureAsync(() =>
            base.SendAsync(request, cancellationToken));
        if (policyResult.Outcome == OutcomeType.Failure)
        {
            throw new HttpRequestException("Something went wrong.", policyResult.FinalException);
        }

        return policyResult.Result;
    }
}