using System.Net;
using System.Web;
using Microsoft.Extensions.Caching.Memory;

namespace HttpClientDelegatingHandlers.DelegateHandlers;

public class CachingHandler: DelegatingHandler
{
    private readonly IMemoryCache _cache;

    public CachingHandler(IMemoryCache cache)
    {
        _cache = cache;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var queryString = HttpUtility.ParseQueryString(request.RequestUri!.Query);
        var city = queryString["q"];
        if (city != null)
        {
            var cachedResponse = _cache.Get<string>(city);

            if (cachedResponse != null)
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(cachedResponse)
                };
            }
        }

        var response= await base.SendAsync(request, cancellationToken);
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        _cache.Set(city, content, TimeSpan.FromSeconds(30));
        return response;
    }
}