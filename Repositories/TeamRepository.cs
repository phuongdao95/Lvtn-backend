using Models.Repositories.DataContext;
using Models.Models;
using Repositories;

namespace Models.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(EmsContext context) : base(context)
        {
        }
    }
}
