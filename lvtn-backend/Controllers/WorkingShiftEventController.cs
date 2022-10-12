using AutoMapper;
using Models.DTO.Request;
using Models.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingShiftEventController : ControllerBase
    {
        private IWorkingShiftEventService _workingShiftEventService;
        private IMapper _mapper;
        public WorkingShiftEventController(IWorkingShiftEventService workingShiftEventService, IMapper mapper)
        {
            _workingShiftEventService = workingShiftEventService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add(WorkingShiftEventDTO dto)
        {
            try
            {
                _workingShiftEventService.Add(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, WorkingShiftEventDTO dto)
        {
            try
            {
                _workingShiftEventService.Update(id, dto);
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
                _workingShiftEventService.Delete(id);
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
                var shift = _workingShiftEventService.GetById(id);
                return Ok(_mapper.Map<WorkingShiftEventResponseDTO>(shift));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromQuery] int offset = 0,
            [FromQuery] int limit = 8,
            [FromQuery] string? query = "")
        {
            try
            {
                var shifts = _workingShiftEventService.GetAll(offset, limit, query);
                var shiftResponse = _mapper.Map<IEnumerable<WorkingShiftEventResponseDTO>>(shifts);
                var total = _workingShiftEventService.GetCount();
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

        [HttpGet("/workingshift/user/{userId}")]
        public IActionResult GetAllByUser(int userId, [FromQuery] int offset = 0,
            [FromQuery] int limit = 8,
            [FromQuery] string? query = "")
        {
            try
            {
                var shifts = _workingShiftEventService.GetByUser(userId, offset, limit, query);
                var shiftResponse = _mapper.Map<IEnumerable<WorkingShiftEventResponseDTO>>(shifts);
                foreach (var shift in shiftResponse)
                {
                    shift.isCheck = false;
                    foreach (var user in shift.Users)
                    {
                        if (user.Id == userId)
                        {
                            shift.isCheck = true;
                            break;
                        }
                    }
                }
                var total = _workingShiftEventService.GetCount();
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
    }
}
