using Models.DTO.Request;
using Models.Models;

namespace Services.Contracts
{
    public interface IEmployeeService
    {
        void AddUser(UserDTO user);
        void UpdateUser(int id, UserDTO user);
        void DeleteUserById(int id);

        User GetUserById(int id);
        List<User> GetUserList(int offset, int limit, string query, string queryType);
        int GetUserCount();
    }
}
