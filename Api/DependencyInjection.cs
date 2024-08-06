namespace Api;

using Microsoft.Azure.SignalR;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration config)
    {
        services.AddSignalR().AddAzureSignalR(config["SignalRConnectionString"]);

        return services;
    }
}