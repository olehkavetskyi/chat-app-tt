using Domain.Enitities;

namespace Application.Interfaces;

public interface IMessageRepository
{
    Task<IEnumerable<Message>> GetMessagesAsync();

    Task<int> GetTotalMessagesCountAsync();
    Task AddMessageAsync(Message message);
}