using lvtn_backend.Models;
using lvtn_backend.Repositories.DataContext;
using Repositories;

namespace lvtn_backend.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(EmsContext context) : base(context)
        {
        }
    }
}
