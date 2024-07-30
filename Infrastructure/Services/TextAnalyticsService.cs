using Application.Interfaces;
using Azure.AI.TextAnalytics;

namespace Infrastructure.Services;

public class TextAnalyticsService : ITextAnalyticsService
{
    private readonly TextAnalyticsClient _client;

    public TextAnalyticsService(TextAnalyticsClient client)
    {
        _client = client;
    }

    public async Task<string> AnalyzeSentimentAsync(string text)
    {
        var sentimentResult = await _client.AnalyzeSentimentAsync(text);
        return sentimentResult.Value.Sentiment.ToString().ToLower();
    }
}