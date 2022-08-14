using lvtn_backend.Models;
using lvtn_backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lvtn_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("/")]
        public IActionResult AddUser(User user)
        {
            _userRepository.AddUser(user);
            return Ok();
        }

        [HttpGet("/{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userRepository.GetUserById(id));
        }
    }
}
