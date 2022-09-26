using AutoMapper;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Models.Controllers
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


        [Authorize(Policy = "team.create")]
        [HttpPost]
        public IActionResult AddTeam(TeamDTO teamDTO)
        {
            try
            {
                _teamService.AddTeam(teamDTO);
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
