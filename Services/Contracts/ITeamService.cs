using lvtn_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ITeamService
    {
        void AddTeam(Team team);

        Team GetTeamById(int id);
    }
}
