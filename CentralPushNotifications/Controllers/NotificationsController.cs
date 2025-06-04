using CentralPushNotifications.Models;
using CentralPushNotifications.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentralPushNotifications.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly FcmService _fcmService;

    public NotificationsController(FcmService fcmService)
    {
        _fcmService = fcmService;
    }

    [HttpPost]
    public async Task<IActionResult> Send(NotificationRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Token))
        {
            return BadRequest("Token is required");
        }

        var id = await _fcmService.SendAsync(request.Title, request.Body, request.Token);
        return Ok(new { id });
    }
}
