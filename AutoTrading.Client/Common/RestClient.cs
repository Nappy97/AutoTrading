using System.Net.Http.Json;
using System.Text;
using System.Web;
using AutoTrading.Shared.Utilities;

namespace AutoTrading.Client.Common;

public interface IRestClient
{
    Task<RestResult> GetAsync(string uri, Dictionary<string, object>? queryParameters = null,
        CancellationToken cancellationToken = default);

    Task<RestResult<TResponse>> GetAsync<TResponse>(string uri, Dictionary<string, object>? queryParameters = null,
        CancellationToken cancellationToken = default) where TResponse : class;

    Task<RestResult<TResponse>> GetAsync<TRequest, TResponse>(string uri, TRequest queryParameters,
        CancellationToken cancellationToken = default)
        where TRequest : class
        where TResponse : class;

    Task<RestResult<TResponse>> PostAsync<TRequest, TResponse>(string uri, TRequest body,
        CancellationToken cancellationToken = default) where TRequest : class;

    Task<RestResult<TResponse>> PutAsync<TRequest, TResponse>(string uri, TRequest body,
        Dictionary<string, object>? queryParameters = null, CancellationToken cancellationToken = default)
        where TRequest : class;

    Task<RestResult<TResponse>> DeleteAsync<TResponse>(string uri, Dictionary<string, object>? queryParameters = null,
        CancellationToken cancellationToken = default);
}

public class RestClient : IRestClient
{
    private readonly HttpClient _httpClient;

    public RestClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<RestResult> GetAsync(string uri, Dictionary<string, object>? queryParameters = null,
        CancellationToken cancellationToken = default)
    {
        var response = await GetQueryAsync(uri, queryParameters, cancellationToken);
        return response.IsSuccessStatusCode
            ? RestResult.AsSuccess()
            : RestResult.AsFail(await response.Content.ReadAsStringAsync(cancellationToken));
    }

    public async Task<RestResult<TResponse>> GetAsync<TResponse>(string uri,
        Dictionary<string, object>? queryParameters = null, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        var response = await GetQueryAsync(uri, queryParameters, cancellationToken);

        if (!response.IsSuccessStatusCode)
            return RestResult<TResponse>.AsFail(await response.Content.ReadAsStringAsync(cancellationToken));

        TResponse content;
        try
        {
            var contentAsStr = await response.Content.ReadAsStringAsync(cancellationToken);
            content = (TResponse)Convert.ChangeType(contentAsStr, typeof(TResponse));
        }
        catch
        {
            content = NappyJsonSerializer.Deserialize<TResponse>(
                await response.Content.ReadAsStringAsync(cancellationToken));
        }

        return RestResult<TResponse>.AsSuccess(content);
    }

    public async Task<RestResult<TResponse>> GetAsync<TRequest, TResponse>(string uri, TRequest queryParameters,
        CancellationToken cancellationToken = default) where TRequest : class where TResponse : class
    {
        var queryString = HttpUtility.ParseQueryString(string.Empty);
        var properties = typeof(TRequest).GetProperties();

        foreach (var property in properties)
        {
            var encodedValue = Uri.EscapeDataString((string)property.GetValue(queryParameters)!);
            queryString.Add(property.Name, encodedValue);
        }


        var serviceUri = new StringBuilder(uri);
        if (queryString.Count > 0)
            serviceUri.Append($"?{queryString.ToString()}");

        var response = await _httpClient.GetAsync(serviceUri.ToString(), cancellationToken);

        if (!response.IsSuccessStatusCode)
            return RestResult<TResponse>.AsFail(await response.Content.ReadAsStringAsync(cancellationToken));

        TResponse content;
        try
        {
            var contentAsStr = await response.Content.ReadAsStringAsync(cancellationToken);
            content = (TResponse)Convert.ChangeType(contentAsStr, typeof(TResponse));
        }
        catch
        {
            content = NappyJsonSerializer.Deserialize<TResponse>(
                await response.Content.ReadAsStringAsync(cancellationToken));
        }

        return RestResult<TResponse>.AsSuccess(content);
    }

    public async Task<RestResult<TResponse>> PostAsync<T, TResponse>(string uri, T body,
        CancellationToken cancellationToken = default) where T : class
    {
        var response = await _httpClient.PostAsJsonAsync(uri, body, NappyJsonSerializer.DefaultSerializerOptions,
            cancellationToken);
        if (!response.IsSuccessStatusCode)
            return RestResult<TResponse>.AsFail(await response.Content.ReadAsStringAsync(cancellationToken));

        var contentAsString = await response.Content.ReadAsStringAsync(cancellationToken);
        var content = NappyJsonSerializer.Deserialize<TResponse>(contentAsString);

        return RestResult<TResponse>.AsSuccess(content);
    }

    public async Task<RestResult<TResponse>> PutAsync<TRequest, TResponse>(string uri, TRequest body,
        Dictionary<string, object>? queryParameters = null,
        CancellationToken cancellationToken = default) where TRequest : class
    {
        var serviceUri = GetQueryParametersToUri(uri, queryParameters);
        var response = await _httpClient.PutAsJsonAsync(serviceUri, body, NappyJsonSerializer.DefaultSerializerOptions,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
            return RestResult<TResponse>.AsFail(await response.Content.ReadAsStringAsync(cancellationToken));
        
        var contentAsString = await response.Content.ReadAsStringAsync(cancellationToken);
        var content = NappyJsonSerializer.Deserialize<TResponse>(contentAsString);

        return RestResult<TResponse>.AsSuccess(content);
    }

    public async Task<RestResult<TResponse>> DeleteAsync<TResponse>(string uri, Dictionary<string, object>? queryParameters = null,
        CancellationToken cancellationToken = default)
    {
        var serviceUri = GetQueryParametersToUri(uri, queryParameters);
        var response = await _httpClient.DeleteAsync(serviceUri, cancellationToken);

        if (!response.IsSuccessStatusCode)
            return RestResult<TResponse>.AsFail(await response.Content.ReadAsStringAsync(cancellationToken));
        
        var contentAsString = await response.Content.ReadAsStringAsync(cancellationToken);
        var content = NappyJsonSerializer.Deserialize<TResponse>(contentAsString);

        return RestResult<TResponse>.AsSuccess(content);
    }

    /// <summary>
    /// Get Method 공통 파트 분리
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="queryParameters"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task<HttpResponseMessage> GetQueryAsync(string uri,
        Dictionary<string, object>? queryParameters = null, CancellationToken cancellationToken = default)
    {
        var serviceUri = GetQueryParametersToUri(uri, queryParameters);
        return await _httpClient.GetAsync(serviceUri, cancellationToken);
    }

    /// <summary>
    /// Dictionary Query parameters To string servie uri
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="queryParameters"></param>
    /// <returns></returns>
    private string GetQueryParametersToUri(string uri, Dictionary<string, object>? queryParameters = null)
    {
        var queryString = HttpUtility.ParseQueryString(string.Empty);
        if (queryParameters is not null && queryParameters.Count > 0)
        {
            foreach (var key in queryParameters.Keys)
            {
                var encodedValue = Uri.EscapeDataString(queryParameters[key].ToString() ?? string.Empty);
                queryString.Add(key, encodedValue);
            }
        }

        var serviceUri = new StringBuilder(uri);
        if (queryString.Count > 0)
            serviceUri.Append($"?{queryString.ToString()}");

        return serviceUri.ToString();
    }
}