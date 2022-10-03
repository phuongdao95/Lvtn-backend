using AutoMapper;
using Models.DTO.Request;
using Models.DTO.Response;
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


        [HttpGet]
        public IActionResult GetTeamList(
            [FromQuery] int offset = 0,
            [FromQuery] int limit = 8,
            [FromQuery] string? query = "",
            [FromQuery] string? queryType = "name"
            )
        {
            try
            {
                var teamList = _teamService
                    .GetTeamList(offset, limit, query, queryType);

                var teamInfoList = _mapper.Map<IEnumerable<TeamInfoDTO>>(teamList);
                var teamCount = _teamService.GetTeamCount();
                return Ok(new Dictionary<string, object>
                {
                { "data", teamInfoList },
                    { "count", teamInfoList.Count() },
                    { "total", teamCount }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
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

        [Authorize(Policy = "team.update")]
        [HttpPut("{id}")]
        public IActionResult UpdateTeam(int id, TeamDTO teamDTO)
        {
            try
            {
                _teamService.UpdateTeam(id, teamDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize(Policy = "team.delete")]
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            try
            {
                _teamService.DeleteTeamById(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [Authorize(Policy = "team.retrieve")]
        [HttpGet("{id}")]
        public IActionResult GetTeamById(int id)
        {
            try
            {
                var team = _teamService.GetTeamById(id);
                var teamInfo = _mapper.Map<TeamInfoDTO>(team);

                return Ok(teamInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorDTO() { Error = true, Message = ex.Message });
            }
        }
    }
}
