using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            var manager = _context.Users.Find(departmentDTO.ManagerId);

            var parentDepartment = _context.Departments.Find(departmentDTO.ParentDepartmentId);

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
            _context.Entry(department)
                .Collection(d => d.Teams)
                .Load();

            _context.Entry(department)
                .Collection(d => d.Departments)
                .Load();

            _context.Entry(department)
                .Reference(d => d.Manager)
                .Load();
            
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

            _context.Entry(department).Reference(d => d.Manager).Load();
            _context.Entry(department).Reference(d => d.ParentDepartment).Load();

            return department;
        }

        public List<Team> GetTeamsOfDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                throw new Exception("Department not found");
            }

            _context.Entry(department).Collection(d => d.Teams).Load();

            return department.Teams ?? new List<Team>();
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
                    .Include(dep => dep.ParentDepartment)
                    .Include(dep => dep.Manager)
                    .Where((department) => department.Name.Contains(query) || query.Contains(department.Name))
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
            else
            {
                return _context.Departments
                    .Include(dep => dep.ParentDepartment)
                    .Include(dep => dep.Manager)
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

            var manager = _context.Users.Find(departmentDTO.ManagerId);

            var parentDepartment = _context.Departments.Find(departmentDTO.ParentDepartmentId);

            var department = _mapper.Map<Department>(departmentDTO);

            department.Id = id;
            department.Teams = teams;
            department.ParentDepartmentId = departmentDTO.ParentDepartmentId > 0 ? departmentDTO.ParentDepartmentId : null;
            department.ManagerId = departmentDTO.ManagerId > 0 ? departmentDTO.ManagerId : null;

            _context.Departments.Update(department);
            _context.SaveChanges();
        }
    }
}
