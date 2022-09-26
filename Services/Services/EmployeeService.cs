
using Models.Models;
using Models.Repositories;
using Models.Repositories.DataContext;
using Services.Contracts;
using Models.DTO.Request;
using AutoMapper;

namespace Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUserRepository _userRepository;
        private readonly EmsContext _context;
        private readonly IMapper _mapper;
        public EmployeeService(
            IUserRepository userRepository, 
            EmsContext _emsContext, 
            IMapper mapper)
        {
            _context = _emsContext;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public void AddUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetByID(id);
        }

        public void UpdateUser(int id, UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            user.Id = id;
            
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUserById(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public List<User> GetUserList(int offset, int limit, string query, string queryType)
        {

            if (queryType == "username")
            {
                return _context.Users.Where((user) => query.Contains(user.Username) || user.Username.Contains(query))
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
            else
            {
                return _context.Users.Where((user) => query.Contains(user.Name) || user.Name.Contains(query))
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public int GetUserCount()
        {
            return _context.Users.Count();
        }
    }
}
