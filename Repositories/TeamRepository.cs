using lvtn_backend.Repositories.DataContext;
using lvtn_backend.Models;
using Repositories;

namespace lvtn_backend.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(EmsContext context) : base(context)
        {
        }
    }
}
