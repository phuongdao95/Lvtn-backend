using AutoMapper;
using Models.DTO.Request;
using Models.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Services;
using System.Web;

namespace Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingShiftTimekeepingController : ControllerBase
    {
        private WorkingShiftTimekeepingService _workingShiftTimekeepingService;
        private IMapper _mapper;
        public WorkingShiftTimekeepingController(
            WorkingShiftTimekeepingService workingShiftTimekeepingService,
            IMapper mapper)
        {
            _workingShiftTimekeepingService = workingShiftTimekeepingService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add(WorkingShiftTimekeepingDTO dto)
        {
            try
            {
                _workingShiftTimekeepingService.Add(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, WorkingShiftTimekeepingDTO dto)
        {
            try
            {
                _workingShiftTimekeepingService.Update(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _workingShiftTimekeepingService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            try
            {
                var shift = _workingShiftTimekeepingService.GetById(id);
                return Ok(_mapper.Map<WorkingShiftTimekeepingInfoDTO>(shift));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
            int userId,
            DateTime currentDate,
            int eventId)
        {
            try
            {
                var shifts = _workingShiftTimekeepingService.GetAll(userId, currentDate, eventId);
                var shiftResponse = _mapper.Map<IEnumerable<WorkingShiftTimekeepingInfoDTO>>(shifts);
                return Ok(new Dictionary<string, object>
                {
                    {
                        "data", shiftResponse
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getAllByUser/{userId}")]
        public IActionResult GetAllByUserId(
            int userId,
            DateTime selectedDate)
        {
            try
            {
                var shifts = _workingShiftTimekeepingService.GetAllUserId(userId, selectedDate);
                return Ok(_mapper.Map<IEnumerable<WorkingShiftTimekeepingInfoDTO>>(shifts));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/workingshifttimekeeping/{id}/workingshiftimekeepinghistory")]
        public IActionResult GetTimekeepingHistory()
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

        [HttpGet("/api/user/{id}/workingshifttimekeeping/")]
        public IActionResult GetTimekeepingScheduleOfUser(int id,
            [FromQuery] string? query,
            [FromQuery] string? queryType)
        {
            try
            {
                var decodedQuery = HttpUtility.UrlDecode(query);
                var timekeeping = _workingShiftTimekeepingService
                    .GetWorkingShiftTimekeepingOfUser(id, decodedQuery, queryType);

                var data = _mapper.Map<IEnumerable<WorkingShiftTimekeepingInfoDTO>>(timekeeping);
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
    }
}

