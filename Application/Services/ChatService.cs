using Application.Interfaces;
using Domain.Enitities;

namespace Application.Services;

public class ChatService : IChatService
{
    private readonly ITextAnalyticsService _textAnalyticsService;
    private readonly IMessageRepository _messageRepository;

    public ChatService(ITextAnalyticsService textAnalyticsService, IMessageRepository messageRepository)
    {
        _textAnalyticsService = textAnalyticsService;
        _messageRepository = messageRepository;
    }

    public async Task<IEnumerable<Message>> GetMessagesAsync()
    {
        return await _messageRepository.GetMessagesAsync();
    }

    public async Task<Message> ProcessMessageAsync(string content)
    {
        var sentiment = await _textAnalyticsService.AnalyzeSentimentAsync(content);
        var message = new Message
        {
            Content = content,
            Sentiment = sentiment,
            Timestamp = DateTime.UtcNow
        };
        await _messageRepository.AddMessageAsync(message);
        return message;
    }
}