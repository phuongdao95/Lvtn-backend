using lvtn_backend.Models;

namespace lvtn_backend.Repositories
{
    public interface ITeamRepository
    {
        void AddTeam(Team team);
        Team GetTeamById(int id);
    }
}
