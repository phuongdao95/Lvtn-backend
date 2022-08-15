using lvtn_backend.DataContext;
using lvtn_backend.Models;

namespace lvtn_backend.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private EmsContext _emsContext;
        public TeamRepository(EmsContext emsContext)
        {
            _emsContext = emsContext;
        }

        public void AddTeam(Team team)
        {
            _emsContext.Teams.Add(team);
        }

        public Team GetTeamById(int id)
        {
            var team = _emsContext.Teams.Find(id);
            if (team == null)
            {
                return new Team();
            }
            return team;
        }
    }
}
