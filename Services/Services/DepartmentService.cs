using AutoMapper;
using Models.DTO.Request;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;

namespace Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private EmsContext _context;
        private IMapper _mapper;
        public DepartmentService(EmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddDepartment(DepartmentDTO departmentDTO)
        {
            var teams = _context.Teams.Where(
                (team) => departmentDTO.TeamIds.Contains(team.Id)).ToList();

            var manager = _context.Users.FirstOrDefault((user) => user.Id ==
                departmentDTO.ManagerId, null);

            var parentDepartment = _context.Departments
                .FirstOrDefault((department) => department.Id == departmentDTO.ParentDepartmentId, null);

            var department = _mapper.Map<Department>(departmentDTO);

            department.Teams = teams;
            department.ParentDepartment = parentDepartment;
            department.Manager = manager;

            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void DeleteDepartmentById(int id)
        {
            var department = _context.Departments.Find(id);
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }

        public Department GetDepartmentById(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                throw new Exception("department is null");
            }

            return department;
        }

        public int GetDepartmentCount()
        {
            return _context.Departments.Count();
        }

        public List<Department> GetDepartmentList(int offset, int limit, string query, string queryType = "name")
        {
            if (queryType == "")
            {
                return _context.Departments
                    .Where((department) => department.Name.Contains(query) || query.Contains(department.Name))
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
            else
            {
                return _context.Departments
                    .Where((department) => department.Name.Contains(query) || query.Contains(department.Name))
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public void UpdateDepartment(int id, DepartmentDTO departmentDTO)
        {
            var teams = _context.Teams.Where(
           (team) => departmentDTO.TeamIds.Contains(team.Id)).ToList();

            var manager = _context.Users.FirstOrDefault((user) => user.Id ==
                departmentDTO.ManagerId, null);

            var parentDepartment = _context.Departments
                .FirstOrDefault((department) => department.Id == departmentDTO.ParentDepartmentId, null);

            var department = _mapper.Map<Department>(departmentDTO);

            department.Id = id;
            department.Teams = teams;
            department.ParentDepartment = parentDepartment;
            department.Manager = manager;

            _context.Departments.Update(department);
            _context.SaveChanges();
        }
    }
}
