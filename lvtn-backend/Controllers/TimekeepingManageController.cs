using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.Repositories.DataContext;
using Services.Contracts;
using Services.Services;
using System.Web;

namespace lvtn_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimekeepingManageController : ControllerBase
    {
        private TimekeepingManageService _timekeepingManageService;
        private IMapper _mapper;
        public TimekeepingManageController(
            TimekeepingManageService timekeepingManageService,
            IMapper mapper)
        {
            _timekeepingManageService = timekeepingManageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetWorkingShifts(
            [FromQuery] int month = 10
            , [FromQuery] int year = 2022
            , [FromQuery] int workCount = 0)
        {
            try
            {
                List<TimeManageResponseDTO> lstData = _timekeepingManageService.getUsers(month, year, workCount);
                return Ok(
                        new Dictionary<string, object>
                        {
                            { "data", lstData },
                            { "count", lstData.Count() },
                        }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/manage")]
        public IActionResult GetIsHasFullTime(
            [FromQuery] int month = 10
            , [FromQuery] int year = 2022
            , [FromQuery] int id = 1
            , [FromQuery] int day = 1)
        {
            try
            {
                Boolean isFullTime = _timekeepingManageService.isUserCheckFullTime(day, month, year, id);
                return Ok(
                        new Dictionary<string, object>
                        {
                            { "data", isFullTime },
                        }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
