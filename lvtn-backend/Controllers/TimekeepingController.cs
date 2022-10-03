using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace lvtn_backend.Controllers
{
    [ApiController]
    public class TimekeepingController : ControllerBase
    {
        private readonly IMapper _mapper;
        public TimekeepingController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("/check-in")]
        public IActionResult CheckIn()
        {
            return Ok();
        }

        [HttpPost("/check-out")]
        public IActionResult CheckOut()
        {
            return Ok();
        }

        [HttpGet("api/user/{id}/timesheet")]
        public IActionResult GetCurrentTimeSheetOfUser(int userId)
        {
            return Ok();
        }

        [HttpPost("api/workingshift/register")]
        public IActionResult RegisterWorkingShift()
        {
            return Ok();
        }

        [HttpPost("api/workingshift/")]
        public IActionResult CreateWorkingShift()
        {
            return Ok();
        }
    }
}
