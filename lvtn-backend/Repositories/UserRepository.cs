using lvtn_backend.DataContext;
using lvtn_backend.Models;

namespace lvtn_backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private EmsContext _emsContext;
        public UserRepository(EmsContext emsContext)
        {
            _emsContext = emsContext;
        }

        public void AddUser(User user)
        {
            _emsContext.Users.Add(user);
            _emsContext.SaveChanges();
        }

        public User GetUserById(int id)
        {
            var user = _emsContext.Users.Find(id);
            if (user == null)
            {
                return new User();
            }
            return user;
        }
    }
}
