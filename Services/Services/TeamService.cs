using Models.Models;
using lvtn_backend.Repositories;
using lvtn_backend.Repositories.DataContext;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TeamService : ITeamService
    {
        private ITeamRepository _teamRepository;
        private EmsContext _context;

        public TeamService(ITeamRepository teamRepository, EmsContext context)
        {
            _teamRepository = teamRepository;
            _context = context;
        }

        public void AddTeam(Team team)
        {
            _teamRepository.Insert(team);
            _context.SaveChanges();
        }

        public Team GetTeamById(int id)
        {
            return _teamRepository.GetByID(id);
        }
    }
}
