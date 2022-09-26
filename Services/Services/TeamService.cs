﻿using AutoMapper;
using Models.DTO.Request;
using Models.Models;
using Models.Repositories;
using Models.Repositories.DataContext;
using Services.Contracts;

namespace Services.Services
{
    public class TeamService : ITeamService
    {
        private ITeamRepository _teamRepository;
        private IMapper _mapper;
        private EmsContext _context;

        public TeamService(ITeamRepository teamRepository,
            EmsContext context,
            IMapper mapper)
        {
            _teamRepository = teamRepository;
            _context = context;
            _mapper = mapper;
        }

        public void AddTeam(TeamDTO teamDTO)
        {
            var team = _mapper.Map<Team>(teamDTO);
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public void DeleteTeamById(int id)
        {
            var team = _context.Teams.Find(id);

            _context.Entry(team)
                .Collection(team => team.Members)
                .Load();
           
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }

        public Team GetTeamById(int id)
        {
            return _teamRepository.GetByID(id);
        }

        public int GetTeamCount()
        {
            return _context.Teams.Count();
        }

        public List<Team> GetTeamList(int offset, int limit, string query, string queryType = "name")
        {
            if (queryType == "name")
            {
                return _context.Teams.Where((team) =>
                    query.Contains(team.Name) || team.Name.Contains(query))
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
            else if (queryType == "no_department")
            {
                return _context.Teams.Where((team) =>
                    team.DepartmentId == null)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
            else
            {
                return _context.Teams.Where((team) =>
                    query.Contains(team.Name) || team.Name.Contains(query))
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public List<User> GetUserListOfTeam(int teamId)
        {
            var team = _context.Teams.Find(teamId);

            _context.Entry(team)
                .Collection(team => team.Members)
                .Load();

            return team.Members.ToList();
        }

        public void UpdateTeam(int id, TeamDTO teamDTO)
        {
            var member = _context.Users.Where(
                user => teamDTO.MemberIds.Contains(user.Id)).ToList();

            var team = _mapper.Map<Team>(teamDTO);

            team.Id = id;
            team.Members = member;

            _context.Teams.Update(team);
            _context.SaveChanges();
        }
    }
}
