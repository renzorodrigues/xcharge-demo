using System.Text.Json;
using xcharge.Application.Interfaces.Services;
using xcharge.Shared.Helpers;
using xcharge.Shared.Settings.HttpClientSettings;

namespace xcharge.Infrastructure.Services.HttpClient;

public class HttpClientFactory(
    IHttpClientFactory httpClientFactory,
    HttpClientSettings httpClientSettings
) : IHttpClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly HttpClientSettings _httpClientSettings = httpClientSettings;

    public async Task<TOut> CreateClient<TIn, TOut>(
        HttpClientSettingsEnum httpClientEnum,
        TIn request
    )
    {
        var (baseAddress, requestUri) = this.GetSettings(httpClientEnum);

        try
        {
            var client = this._httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseAddress);

            var json = JsonSerializer.Serialize(request);
            var stringContent = new StringContent(
                json,
                null,
                ConstantStrings.Headers.ApplicationJson
            );

            var response = await client.PostAsync(requestUri, stringContent);
            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TOut>(content)!;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private (string baseAddress, string requestUri) GetSettings(
        HttpClientSettingsEnum httpClientEnum
    )
    {
        return httpClientEnum switch
        {
            HttpClientSettingsEnum.BankSlipIssue
                => (
                    this._httpClientSettings.BankSlipIssue.BaseAddress,
                    this._httpClientSettings.BankSlipIssue.RequestUri
                ),
            _ => new(),
        };
    }
}
