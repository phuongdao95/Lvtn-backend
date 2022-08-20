using Models.Models;

namespace Services.Contracts
{
    public interface IEmployeeService
    {
        void AddUser(User user);

        User GetUserById(int id);

        void AssignUserToTeam(int userId, int teamId);

        IEnumerable<User> GetAllUsers();
    }
}
