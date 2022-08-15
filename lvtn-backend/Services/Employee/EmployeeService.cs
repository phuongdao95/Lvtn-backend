using lvtn_backend.Repositories;

namespace lvtn_backend.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUserRepository _userRepository;
        public EmployeeService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser()
        {
            throw new NotImplementedException();
        }
    }
}
