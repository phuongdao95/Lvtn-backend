using Models.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using AutoMapper;
using Models.DTO.Request;
using Models.DTO.Response;
using Microsoft.AspNetCore.Authorization;

namespace Models.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IEmployeeService _employeeService;
        private IMapper _mapper;

        public UserController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddUser(UserDTO userDTO)
        {
            try
            {
                _employeeService.AddUser(userDTO);
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

        [HttpGet]
        public IActionResult GetUserList(
            [FromQuery] int offset = 0,
            [FromQuery] int limit = 8,
            [FromQuery] string? query = "",
            [FromQuery] string? queryType = "name")
        {
            try
            {
                var user = _employeeService.GetUserList(offset, limit, query, queryType);

                var userInfo = _mapper.Map<IEnumerable<UserInfoDTO>>(user);

                var userCount = _employeeService.GetUserCount();

                return Ok(new Dictionary<string, object>
                {
                    {
                        "data", userInfo
                    },
                    {
                        "count", userInfo.Count()
                    },
                    {
                        "total", userCount
                    }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
