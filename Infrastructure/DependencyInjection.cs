using Application.Interfaces;
using Azure;
using Azure.AI.TextAnalytics;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var endpoint = config["CognitiveServicesEndpoint"];
        var apiKey = config["CognitiveServicesApiKey"];
        var credential = new AzureKeyCredential(apiKey!);

        services.AddSingleton(new TextAnalyticsClient(new Uri(endpoint!), credential));

        services.AddDbContext<ChatDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<ITextAnalyticsService, TextAnalyticsService>();

        return services;
    }
}