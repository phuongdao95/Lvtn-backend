using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Services.Contracts;
using Services.Services;

namespace lvtn_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckInConfigController : ControllerBase
    {
        private readonly CheckInConfig _checkInConfig;
        private readonly IMapper _mapper;
        public CheckInConfigController(CheckInConfig checkInConfig, IMapper mapper)
        {
            _checkInConfig = checkInConfig;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetRuleCheckInMinutes()
        {
            try
            {
                return Ok(_checkInConfig.ruleBeforeCheckinMinute);
            } 
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateRuleCheckInMinutes(int minutes)
        {
            try
            {
                _checkInConfig.ruleBeforeCheckinMinute = minutes;
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
