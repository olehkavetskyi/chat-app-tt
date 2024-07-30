using Domain.Enitities;

namespace Application.Interfaces;

public interface IChatService
{
    Task<IEnumerable<Message>> GetMessagesAsync();
    Task<Message> ProcessMessageAsync(string content);
}
