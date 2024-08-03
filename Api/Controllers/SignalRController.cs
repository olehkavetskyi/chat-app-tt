using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.SignalR.Management;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SignalRController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public SignalRController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet("token")]
    public IActionResult GetSignalRToken()
    {
        var endpoint = _serviceManager.GetClientEndpoint("chatHub");
        var token = _serviceManager.GenerateClientAccessToken("chatHub");

        return Ok(new { url = endpoint, token });
    }
}