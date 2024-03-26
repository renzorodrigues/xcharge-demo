using xcharge.Shared.Settings.HttpClientSettings;

namespace xcharge.Application.Interfaces.Services;

public interface IHttpClient
{
    Task<TOut> CreateClient<TIn, TOut>(HttpClientSettingsEnum httpClientEnum, TIn request);
}
