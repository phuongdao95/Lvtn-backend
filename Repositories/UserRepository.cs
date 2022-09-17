using Models.Models;
using Models.Repositories.DataContext;
using Repositories;

namespace Models.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(EmsContext context) : base(context)
        {
        }
    }
}
