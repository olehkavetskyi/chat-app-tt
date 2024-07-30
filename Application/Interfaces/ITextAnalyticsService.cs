namespace Application.Interfaces;

public interface ITextAnalyticsService
{
    Task<string> AnalyzeSentimentAsync(string text);
}