using System.Net;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;

namespace Wizards.LogsSender.RestApiClient;

public static class LogCollectorApiConfiguration
{
    public const string LogCollectorApiHttpClientName = "TestApiClient";

    public static HttpClient CreateLogCollectorHttpClient(this IHttpClientFactory httpClientFactory) =>
        httpClientFactory.CreateClient(LogCollectorApiHttpClientName);

    public static readonly IAsyncPolicy<HttpResponseMessage> TimeoutPolicy =
        Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromMilliseconds(250));

    public static readonly IAsyncPolicy<HttpResponseMessage> RetryPolicy = HttpPolicyExtensions
        .HandleTransientHttpError()
        .Or<TimeoutRejectedException>()
        .OrResult(result => result.StatusCode != HttpStatusCode.OK)
        .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromMilliseconds(100 * retryAttempt));
}