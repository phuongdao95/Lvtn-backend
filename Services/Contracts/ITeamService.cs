using Models.DTO.Request;
using Models.Models;

namespace Services.Contracts
{
    public interface ITeamService
    {
        void AddTeam(TeamDTO team);
        void UpdateTeam(int id, TeamDTO teamDTO);
        void DeleteTeamById(int id);
        List<Team> GetTeamList(int offset, int limit, string query, string queryType);
        List<User> GetUserListOfTeam(int teamId);
        int GetTeamCount();
        Team GetTeamById(int id);
    }
}
