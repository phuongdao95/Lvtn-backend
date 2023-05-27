﻿using AutoMapper;
using Models.DTO.Request;
using Models.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Models.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;
using Services.Services;

namespace Models.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ITeamService _teamService;
        private readonly EmsContext _emsContext;
        private readonly IMapper _mapper;
        private readonly IdentityService _identityService;

        public TeamController(
            ITeamService teamService, 
            IMapper mapper,
            EmsContext emsContext)
        {
            _emsContext  = emsContext;
            _teamService = teamService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("/api/myteam/{userId}")]
        public ActionResult GetTeamInfo(int userId)
        {
            try
            {
                var map = new Dictionary<string, object>();

                var currentUser = _emsContext.Users.Where(user => user.Id == userId)
                    .SingleOrDefault();

                if (currentUser is null)
                {
                    throw new Exception("User is null");
                }

                var team = _emsContext.Teams.Where(team => team.Id == currentUser.Id)
                    .Include(team => team.Leader)
                    .Include(team => team.Members)
                    .SingleOrDefault();

                if (team is null)
                {
                    throw new Exception("team not found");
                }

                map["leader"] = _mapper.Map<UserInfoDTO>(team.Leader);
                map["members"] = _mapper.Map<IEnumerable<UserInfoDTO>>(team.Members);

                return Ok(map);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
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
