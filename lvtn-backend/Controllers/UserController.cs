using Models.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using AutoMapper;
using Models.DTO.Request;
using Models.DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Services.Services;
using System.Net.Http.Headers;
using Models.Repositories.DataContext;
using System.Net;

namespace Models.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IEmployeeService _employeeService;
        private EmsContext _emsContext;
        private IMapper _mapper;

        public UserController(

            IEmployeeService employeeService,
            IMapper mapper,
            EmsContext emsContext)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _emsContext = emsContext;
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

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserDTO userDTO)
        {
            try
            {
                _employeeService.UpdateUser(id, userDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _employeeService.DeleteUserById(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _employeeService.GetUserById(id);

                return Ok(_mapper.Map<UserInfoDTO>(user));
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
                var user = _employeeService.GetUserList(offset, int.MaxValue, query, queryType);

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

        [AllowAnonymous]
        [HttpGet("/api/user/{id}/avatar")]
        public IActionResult GetAvatar(int id)
        {
            try
            {
                var employee = _employeeService.GetUserById(id);

                if (employee.Image is null)
                {
                    return NotFound();
                }

                return File(employee.Image, "image/jpeg");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost("/api/user/{id}/avatar")]
        public IActionResult UploadAvatar(int id, [FromForm] IFormFile file)
        {
            if (file.Length > 0)

            {
                var employee = _employeeService.GetUserById(id);

                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    employee.Image = memoryStream.ToArray();
                }

                _emsContext.Users.Update(employee);
                _emsContext.SaveChanges();
                return Ok($"File is uploaded Successfully");
            }
            else
            {
                return BadRequest("The File is not received.");
            }
        }

        [HttpGet("/api/user/validation/name")]
        public IActionResult CheckNameValid()
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

        [HttpGet("/api/user/validation/username")]
        public IActionResult CheckUserNameValid()
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
    }
}
