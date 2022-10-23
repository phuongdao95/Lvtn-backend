using Models.DTO.Request;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IDepartmentService
    {
        void AddDepartment(DepartmentDTO departmentDTO);
        void UpdateDepartment(int id, DepartmentDTO departmentDTO);
        void DeleteDepartmentById(int id);
        Department GetDepartmentById(int id);
        List<Department> GetDepartmentList(int offset, int limit, string query, string queryType);
        int GetDepartmentCount();
        public List<Team> GetTeamsOfDepartment(int id);

    }
}
