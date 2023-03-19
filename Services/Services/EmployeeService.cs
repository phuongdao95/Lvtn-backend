
using Models.Models;
using Models.Repositories;
using Models.Repositories.DataContext;
using Services.Contracts;
using Models.DTO.Request;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing.Template;

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

            var group = _context.Groups
                .Include(group => group.Users)
                .Where(group => group.Id == 1)
                .FirstOrDefault();

            if (group == null || group.Users == null)
            {
                throw new Exception("Cannot find default group");
            }

            var team = _context.Teams
                .Include(team => team.Members)
                .Where(team => team.Id == 1)
                .FirstOrDefault();

            if (team == null || team.Members == null)
            {
                throw new Exception("Cannot find default team");
            }

            group.Users.Add(user);

            if (userDTO.TeamId == null)
            {
                team.Members.Add(user);
            }

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User is null");
            }

            _context.Entry(user).Reference(u => u.Role).Load();
            _context.Entry(user).Reference(u => u.Team).Load();

            return user;
        }

        public void UpdateUser(int id, UserDTO userDTO)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User is null");
            }

            if (userDTO.TeamId > 0)
            {
                user.TeamId = userDTO.TeamId;
            }

            if (userDTO.RoleId > 0)
            {
                user.RoleId = userDTO.RoleId;
            }

            user.Address = userDTO.Address;
            user.Birthday = userDTO.Birthday;

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUserById(int id)
        {
            var user = _context.Users
                .Include(user => user.Timekeepings)
                .Include(user => user.Payslips)
                .Include(user => user.BankInfo)
                .Include(user => user.WorkingShiftRegistrationUsers)
                .Where(user => user.Id == id)
                .Single();

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public List<User> GetUserList(int offset, int limit, string query, string queryType)
        {

            if (queryType == "username")
            {
                return _context.Users.Where((user) => query.Contains(user.Username) || user.Username.Contains(query))
                    .Include(user => user.Team)
                    .Include(user => user.DepartmentManage)
                    .Include(user => user.Role)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
            else
            {
                return _context.Users.Where((user) => query.Contains(user.Name) || user.Name.Contains(query))
                    .Include(user => user.Team)
                    .Include(user => user.DepartmentManage)
                    .Include(user => user.Role)
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
