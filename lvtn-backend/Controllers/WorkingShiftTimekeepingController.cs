using AutoMapper;
using Models.DTO.Request;
using Models.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingShiftTimekeepingController : ControllerBase
    {
        private IWorkingShiftTimekeepingService _workingShiftTimekeepingService;
        private IMapper _mapper;
        public WorkingShiftTimekeepingController(IWorkingShiftTimekeepingService workingShiftTimekeepingService, IMapper mapper)
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
                return Ok(_mapper.Map<WorkingShiftTimekeepingInfo>(shift));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(int userId, DateTime currentDate, int eventId)
        {
            try
            {
                var shifts = _workingShiftTimekeepingService.GetAll(userId, currentDate, eventId);
                var shiftResponse = _mapper.Map<IEnumerable<WorkingShiftTimekeepingInfo>>(shifts);
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
        public IActionResult GetAllByUserId(int userId, DateTime selectedDate)
        {
            try
            {
                var shifts = _workingShiftTimekeepingService.GetAllUserId(userId, selectedDate);
                return Ok(_mapper.Map<IEnumerable<WorkingShiftTimekeepingInfo>>(shifts));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

