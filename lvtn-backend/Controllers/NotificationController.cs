using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lvtn_backend.Controllers
{

    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class NotificationController : ControllerBase
    {
        public NotificationController()
        {

        }

        [HttpGet]
        public IActionResult GetNotificationForUser(int userId)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult DeleteNotification()
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
