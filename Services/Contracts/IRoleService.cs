using Models.DTO.Request;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IRoleService
    {
        Role GetRoleById(int id);
        List<Role> GetRoleList(int offset, int limit, string query, string queryType);
        void UpdateRole(int id, RoleDTO roleDTO);
        void DeleteRoleById(int id);
        void AddRole(RoleDTO roleDTO);
        int GetRoleCount();
    }
}
