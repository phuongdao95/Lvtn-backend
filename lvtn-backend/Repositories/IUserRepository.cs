using lvtn_backend.Models;

namespace lvtn_backend.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserById(int id);
    }
}
