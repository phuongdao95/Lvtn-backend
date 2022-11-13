using AutoMapper;
using lvtn_backend.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Models.DTO.Response;
using Services.Services;

namespace lvtn_backend.Controllers
{

    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _notificationService;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IdentityService _identityService;
        private readonly IMapper _mapper;
        public NotificationController(
            NotificationService notificationService,
            IMapper mapper,
            IHubContext<NotificationHub> hubContext,
            IdentityService identityService)
        {
            _notificationService = notificationService;
            _mapper = mapper;
            _hubContext = hubContext;
            _identityService = identityService;
        }

        [HttpGet("/api/user/{id}/notification/")]
        public IActionResult GetNotificationForUser(int id)
        {
            try
            {
                var notifications = _notificationService.GetNotificationsForUser(id);
                var data = _mapper.Map<IEnumerable<NotificationInfoDTO>>(notifications);
                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    { "data", data },
                    { "count", count },
                    { "total", total }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("/api/notification/{id}")]
        public IActionResult DeleteNotification(int id)
        {
            try
            {
                _notificationService.RemoveNotification(id);
                _hubContext.Clients.Group(_identityService.GetCurrentUserId().ToString())
                    .SendAsync("receiveMessage", "refreshNotification");
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("/api/user/{id}/notification/isRead")]
        public IActionResult MarkNotificationAsRead(int id)
        {
            try
            {
                _notificationService.MarkAllNotifiicationsAsReadForUser(id);
                _hubContext.Clients.Group(id.ToString()).SendAsync("receiveMessage", "refreshNotification");
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpDelete("/api/user/{id}/notification")]
        public IActionResult DeleteAllNotification(int id)
        {
            try
            {
                _notificationService.DeleteAllNotificationOfUser(id);
                _hubContext.Clients.Group(id.ToString()).SendAsync("receiveMessage", "refreshNotification");
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
