using AutoTrading.Client.Common;
using AutoTrading.Client.Models.AppSettings;

namespace AutoTrading.Client;

public static class DependencyInjection
{
    public static IServiceCollection AddClientWasm(this IServiceCollection services)
    {
        return services.AddAuthServices()
            .AddClientApiHttpClient()
            .AddBlazorServices()
            .AddServices();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }

    /// <summary>
    /// UI 관련 서비스 등록
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    private static IServiceCollection AddBlazorServices(this IServiceCollection services)
    {
        services.AddMudServices();

        return services;
    }
    
    /// <summary>
    /// 블레이저 세팅
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    private static IServiceCollection AddAuthServices(this IServiceCollection services)
    {
        services.AddBlazoredLocalStorage();
        services.AddOptions();
        services.AddAuthorizationCore();
        services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

        return services;
    }

    /// <summary>
    /// BackEnd API 통신을 위한 Base Address
    /// </summary>
    /// <returns></returns>
    private static IServiceCollection AddClientApiHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient<IRestClient, RestClient>((sp, client) =>
        {
            //var option = sp.GetRequiredService<ClientApiOption>();
            var baseAddress = "https://localhost:8200";
            client.BaseAddress = new Uri(baseAddress);
        }).ConfigurePrimaryHttpMessageHandler(() =>
        {
            var clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            return clientHandler;
        });

        return services;
    }
}