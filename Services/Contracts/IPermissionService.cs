using Models.Models;

namespace Services.Contracts
{
    public interface IPermissionService
    {

        Permission GetPermissionById(int permissionId);

        List<Permission> GetAllPermissions();
        int GetAllPermissionCount();

        List<Permission> GetPermissionsOfRole(int roleId);
        int GetPermissionsOfRoleCount(int roleId);

        List<Permission> GetPermissionsOfUser(int userId);
        int GetPermissionsOfUserCount(int userId);
    }
}
