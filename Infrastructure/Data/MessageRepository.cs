using Microsoft.EntityFrameworkCore;
using Domain.Enitities;
using Application.Interfaces;

namespace Infrastructure.Data;

public class MessageRepository : IMessageRepository
{
    private readonly ChatDbContext _context;

    public MessageRepository(ChatDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Message>> GetMessagesAsync()
    {
        return await _context.Messages.OrderBy(m => m.Timestamp).ToListAsync();
    }

    public async Task<int> GetTotalMessagesCountAsync()
    {
        return await _context.Messages.CountAsync();
    }

    public async Task AddMessageAsync(Message message)
    {
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }
}