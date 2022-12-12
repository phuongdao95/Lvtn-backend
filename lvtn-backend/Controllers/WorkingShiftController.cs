using AutoMapper;
using Models.DTO.Request;
using Models.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System.Web;
using Models.Models;

namespace Models.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WorkingShiftController : ControllerBase
    {
        private WorkingShiftService _workingShiftEventService;
        private IMapper _mapper;
        public WorkingShiftController(
            WorkingShiftService workingShiftEventService,
            IMapper mapper)
        {
            _workingShiftEventService = workingShiftEventService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateWorkingShift(WorkingShiftEventDTO dto)
        {
            try
            {
                _workingShiftEventService.CreateWorkingShift(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWorkingShift(int id, WorkingShiftEventDTO dto)
        {
            try
            {
                _workingShiftEventService.UpdateWorkingShift(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveWorkingShift(int id)
        {
            try
            {
                _workingShiftEventService.RemoveWorkingShift(id);
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
                var shift = _workingShiftEventService.GetWokringShiftById(id);
                return Ok(_mapper.Map<WorkingShiftEventResponseDTO>(shift));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetWorkingShifts(
            [FromQuery] int offset = 0,
            [FromQuery] int limit = 8,
            [FromQuery] string? query = "01/2021",
            [FromQuery] string? queryType = "month")
        {
            try
            {
                var shifts = _workingShiftEventService
                    .GetWorkingShifts(offset, limit, HttpUtility.UrlDecode(query), queryType);
                var shiftResponse = _mapper.Map<IEnumerable<WorkingShiftEventResponseDTO>>(shifts);
                var total = shifts.Count();

                return Ok(new Dictionary<string, object>
                {
                    {
                        "data", shiftResponse
                    },
                    {
                        "count", shiftResponse.Count()
                    },
                    {
                        "total", total
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/user/{id}/workingshift")]
        public IActionResult GetAllByUser(
            int id,
            [FromQuery] int offset = 0,
            [FromQuery] int limit = 8,
            [FromQuery] string? query = "11/2022",
            [FromQuery] string? queryType ="month")
        {
            try
            {
                var decodedQuery = "11/2022";

                var shifts = _workingShiftEventService.GetWorkingShiftRegistrationUsersOfUser
                    (id, decodedQuery, queryType);

                var data = _mapper.Map<IEnumerable<WorkingShiftRegistrationUserInfoDTO>>(shifts);
                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    { "data", data },
                    { "count", count },
                    { "total", total }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/workingshift/user")]
        public IActionResult UpdateUserWorkingShift(int userId, List<int> shiftIds)
        {
            try
            {
                _workingShiftEventService.UpdateUserShift(userId, shiftIds);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/api/workingshiftregistration/{id}")]
        public IActionResult RemoveWorkingShiftRegistration(int id)
        {
            try
            {
                _workingShiftEventService
                    .DeleteWorkingShiftRegistration(id);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("/api/workingshiftregistration/")]
        public IActionResult CreateWorkingShiftRegistration(
            WorkingShiftRegistrationDTO registrationDTO)
        {
            try
            {
                _workingShiftEventService
                    .CreateWorkingShiftRegistration(registrationDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [HttpGet("/api/workingshiftregistration")]
        public IActionResult GetWorkingShiftRegistration(
            [FromQuery] string? query = "11/2022",
            [FromQuery] string? queryType="month")
        {
            try
            {
                query = HttpUtility.UrlDecode(query);
                var workingShiftUsers = _workingShiftEventService
                    .GetWorkingShiftRegistrations(query, queryType);

                var data = _mapper.Map<IEnumerable
                    <WorkingShiftRegistrationInfoDTO>>(workingShiftUsers);
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

        [HttpDelete("/api/user/{userId}/workingshiftregistration/{id}")]
        public IActionResult DeleteWorkingShiftRegistrationUser(
            int userId,
            int id)
        {
            try
            {
                _workingShiftEventService.DeleteWorkingShiftRegistrationUser(userId, id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/user/{id}/workingshiftregistration/")]
        public IActionResult GetRegistrationListOfUser(
            int id,
            [FromQuery] string? query,
            [FromQuery] string? queryType)
        {
            try
            {
                query = HttpUtility.UrlDecode(query);
                var registrationUsers = _workingShiftEventService
                    .GetWorkingShiftRegistrationUsersOfUser(id, query, queryType)
                    .Select(ru => ru.WorkingShiftRegistration)
                    .ToList();

                var data = _mapper.Map<IEnumerable<WorkingShiftRegistrationInfoDTO>>(registrationUsers);
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

        [HttpGet("/api/user/{id}/unregisteredworkingshift/")]
        public IActionResult GetUnregisteredWorkingShiftOfUser(
            int id, 
            [FromQuery] string query,
            [FromQuery] string queryType)
        {
            try
            {
                var decodedQuery = HttpUtility.UrlDecode(query);
                var workingSHiftRegistration = _workingShiftEventService
                    .GetUnregistredWorkingShift(id, decodedQuery, queryType);

                var data = _mapper.Map<IEnumerable<WorkingShiftRegistrationInfoDTO>>(workingSHiftRegistration);
                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    {"data", data },
                    {"count", count },
                    {"total", total }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/workingshiftdayconfig")]
        public IActionResult GetWorkingShiftDayConfig(
            [FromQuery] string? query,
            [FromQuery] string? queryType)
        {
            try
            {
                var decodedQuery = HttpUtility.UrlDecode(query);
                var workingShiftDayConfigs = _workingShiftEventService.GetWorkingShiftDayConfigs(decodedQuery, queryType);

                var data = _mapper.Map<IEnumerable<WorkingShiftDayConfigInfoDTO>>(workingShiftDayConfigs);
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

        [HttpPost("/api/workingshiftdayconfig")]
        public IActionResult CreateWorkingShiftDayConfig(
            [FromBody] WorkingShiftDayConfigDTO configDTO)
        {
            try
            {
                _workingShiftEventService.CreateWorkingShiftDayConfig(configDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("/api/workingshiftdayconfig/{id}")]
        public IActionResult UpdateWorkingShiftDayConfig(int id, WorkingShiftDayConfigDTO configDTO)
        {
            try
            {
                _workingShiftEventService.UpdateWorkingShiftDayConfigs(id, configDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("/api/workingshiftdayconfig/{id}")]
        public IActionResult DeleteWorkingShiftDayConfig(int id)
        {
            try
            {
                _workingShiftEventService.DeleteWorkingShiftDayConfig(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost("/api/workingshift/overtimeshift")]
        public IActionResult CreateOverTimeWorkingShift(
            [FromBody] CreateOrUpdateOverTimeShiftDTO createOverTimeShiftDTO)
        {
            try
            {
                _workingShiftEventService.CreateWorkingShiftOvertime(createOverTimeShiftDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("/api/workingshift/overtimeshift/{id}")]
        public IActionResult UpdateOverTimeWorkingShift(
            CreateOrUpdateOverTimeShiftDTO updateOverTimeShiftDTO)
        {
            try
            {
                _workingShiftEventService.CreateWorkingShiftOvertime(updateOverTimeShiftDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost("/api/workingshift/basicshift")]
        public IActionResult CreateBasicWorkingShift(
            CreateFixedShiftDTO fixedShiftDTO)
        {
            try
            {
                _workingShiftEventService.CreateWorkingShiftFixed(fixedShiftDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
