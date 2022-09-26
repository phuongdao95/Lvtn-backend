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

        [Authorize(Policy = "user.create")]
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

        [Authorize(Policy = "user.retrieve")]
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


    }
}
