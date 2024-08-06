using Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs;

public class ChatHub : Hub
{
    private readonly IChatService _chatService;

    public ChatHub(IChatService chatService)
    {
        _chatService = chatService;
    }

    public async Task SendMessage(string message)
    {
        var processedMessage = await _chatService.ProcessMessageAsync(message);
        await Clients.All.SendAsync("ReceiveMessage", message, processedMessage.Sentiment);
    }
}
