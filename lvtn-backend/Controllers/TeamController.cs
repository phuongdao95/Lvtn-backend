using AutoMapper;
using lvtn_backend.DTO.Request;
using lvtn_backend.DTO.Response;
using lvtn_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace lvtn_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ITeamService _teamService;
        private IMapper _mapper;

        public TeamController(ITeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
        }


        [HttpPost("")]
        public IActionResult AddTeam(TeamDTO teamDTO)
        {
            try
            {
                _teamService.AddTeam(_mapper.Map<TeamDTO, Team>(teamDTO));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTeamById(int id)
        {
            try
            {
                return Ok(_teamService.GetTeamById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorDTO() { Error = true, Message = ex.Message });
            }
        }
    }
}
