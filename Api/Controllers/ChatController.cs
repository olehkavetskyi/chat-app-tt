﻿using Application.Interfaces;
using Domain.Enitities;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetMessagesAsync()
    {
        var messages = await _chatService.GetMessagesAsync();
        return Ok(messages);
    }
}