using AutoMapper;
using Models.DTO.Request;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;

namespace Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly EmsContext _context;
        private readonly IMapper _mapper;

        public RoleService(EmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddRole(RoleDTO roleDTO)
        {
            var permissions = _context.Permissions
                .Where((permission) => roleDTO.PermissionIds.Contains(permission.Id))
                .ToList();

            var role = _mapper.Map<Role>(roleDTO);

            role.Permissions = permissions;

            _context.Roles.Add(role);
            _context.SaveChanges();

        }

        public void DeleteRoleById(int id)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == id, null);
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();
        }

        public Role GetRoleById(int id)
        {
            var role = _context.Roles.FirstOrDefault((x) => x.Id == id, null);
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            return role;
        }

        public int GetRoleCount()
        {
            return _context.Roles.Count();
        }

        public List<Role> GetRoleList(int offset, int limit, string query, string queryType = "name")
        {
            return _context.Roles.Where((role) => role.Name.Contains(query) || query.Contains(role.Name))
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        public void UpdateRole(int id, RoleDTO roleDTO)
        {
            var permissions = _context.Permissions
                .Where((permission) => roleDTO.PermissionIds.Contains(permission.Id))
                .ToList();

            var role = _mapper.Map<Role>(roleDTO);

            role.Id = id;
            role.Permissions = permissions;

            _context.Roles.Update( role);
            _context.SaveChanges();
        }
    }
}
