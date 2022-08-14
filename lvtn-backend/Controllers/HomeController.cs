using lvtn_backend.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lvtn_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost("news")]
        public IActionResult PostName(Test test)
        {
            return Ok();
        }
    }
}
