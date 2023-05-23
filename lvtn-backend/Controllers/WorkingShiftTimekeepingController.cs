using AutoMapper;
using Models.DTO.Request;
using Models.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Services;
using System.Web;
using org.matheval.Common;

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

        [HttpGet("/api/user/{userId}/workingshifttimekeeping/")]
        public IActionResult GetAllByUserId(
            int userId)
        {
            try
            {
                var shifts = _workingShiftTimekeepingService.GetAllUserId(userId, DateTime.Now);
                var data = _mapper.Map<IEnumerable<WorkingShiftTimekeepingInfoDTO>>(shifts);
                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    {"count", count},
                    {"data", data },
                    {"total", total }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/workingshifttimekeeping/{id}/workingshifttimekeepinghistory")]
        public IActionResult GetTimekeepingHistory(int id)
        {
            try
            {
                var timekeepingHistories = _workingShiftTimekeepingService.GetWorkingShiftTimekeepingHistories(id);

                var data = _mapper.Map<IEnumerable<WorkingShiftTimekeepingHistoryInfoDTO>>(timekeepingHistories);
                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    ["data"] = data,
                    ["count"] = count,
                    ["total"] = count,
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/user/{id}/scheduler")]
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

        [HttpGet("/api/manager/{id}/scheduler")]
        public IActionResult GetTimekeepingScheduleOfUserForManager(int id,
            [FromQuery] string? query,
            [FromQuery] string? queryType)
        {
            try
            {
                var decodedQuery = HttpUtility.UrlDecode(query);
                var timekeeping = _workingShiftTimekeepingService
                    .GetWorkingShiftTimekeepingOfUserForManager(id, decodedQuery, queryType);

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

