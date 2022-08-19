using lvtn_backend.Repositories.DataContext;
using Models.Models;
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
