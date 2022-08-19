using Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using AutoMapper;
using lvtn_backend.DTO.Request;
using lvtn_backend.DTO.Response;

namespace lvtn_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IEmployeeService _employeeService;
        private IMapper _mapper;

        public UserController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpPost("")]
        public IActionResult AddUser(UserDTO userDTO)
        {
            try
            {
                _employeeService.AddUser(_mapper.Map<UserDTO, User>(userDTO));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                return Ok(_employeeService.GetUserById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("")]
        public IActionResult GetListUsers()
        {
            try
            {
                var users = _employeeService.GetAllUsers();
                return Ok(_mapper.Map<IEnumerable<User>, IEnumerable<UserInfoDTO>>(users));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("assign-user-to-team/{userId}/{teamId}")]
        public IActionResult AssignUserToTeam(int userId, int teamId)
        {
            try
            {
                _employeeService.AssignUserToTeam(userId, teamId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorDTO() { Error = true, Message = ex.Message });
            }
        }
    }
}
