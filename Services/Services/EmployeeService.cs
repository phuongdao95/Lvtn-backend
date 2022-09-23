using Models.Models;
using Models.Repositories;
using Models.Repositories.DataContext;
using Models.Exceptions;
using Services.Contracts;

namespace Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly EmsContext context;
        public EmployeeService(IUserRepository userRepository, EmsContext _emsContext, ITeamRepository teamRepository)
        {
            _userRepository = userRepository;
            context = _emsContext;
            _teamRepository = teamRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.Insert(user);
            context.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetByID(id);
        }

        public void AssignUserToTeam(int userId, int teamId)
        {
            var user = _userRepository.GetByID(userId);
            var team = _teamRepository.GetByID(teamId);

            if (user == null)
            {
                throw new ObjectNotExist("User");
            }
            if (team == null)
            {
                throw new ObjectNotExist("Team");
            }

            if (team.Members == null)
            {
                team.Members = new List<User>() { user };
            }
            else
            {
                team.Members.Add(user);
            }

            context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.Get(includeProperties: "TeamBelong");
        }
    }
}
