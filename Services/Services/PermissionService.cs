using AutoMapper;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;

namespace Services.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly EmsContext _context;

        private readonly IMapper _mapper;
        public PermissionService(EmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int GetAllPermissionCount()
        {
            return _context.Permissions.Count();
        }

        public List<Permission> GetAllPermissions()
        {
            var permissions = _context.Permissions.Where(x => true).ToList();
            return permissions;
        }

        public Permission GetPermissionById(int permissionId)
        {
            var permission = _context.Permissions.Find(permissionId);
            if (permission == null)
            {
                throw new Exception("Permisison not found");
            }

            return permission;
        }

        public List<Permission> GetPermissionsOfRole(int? roleId)
        {
            var role = _context.Roles.Find(roleId);
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            _context.Entry(role)
                .Collection((r) => r.Permissions)
                .Load();

            return role.Permissions ?? new List<Permission>();
        }

        public int GetPermissionsOfRoleCount(int roleId)
        {
            var role = _context.Roles.Find(roleId);
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            _context.Entry(role)
                .Collection((r) => r.Permissions)
                .Load();

            return role.Permissions?.Count() ?? 0;
        }

        public List<Permission> GetPermissionsOfUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return GetPermissionsOfRole(user.RoleId);
        }

        public int GetPermissionsOfUserCount(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var permissions = GetPermissionsOfRole(user.Role.Id);

            return permissions?.Count() ?? 0;
        }
    }
}
