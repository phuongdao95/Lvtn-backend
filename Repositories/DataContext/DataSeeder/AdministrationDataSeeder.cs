using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Helpers;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DataContext.DataSeeder
{
    public class AdministrationDataSeeder : DataSeeder
    {
        private static readonly string ADMIN_ROLE = "ADMIN_USER";
        private static readonly string MANAGER_ROLE = "MANAGER_USER";
        private static readonly string EMPLOYEE_ROLE = "EMPLOYEE_ROLE";

        private static readonly string ADMIN_USER = "ADMIN_USER";
        private static readonly string MANAGER_USER = "MANAGER_USER";

        private static readonly string HEAD_DEPARTMENT = "HEAD_DEPARTMENT";

        private static readonly string A_TEAM = "A_TEAM";
        private static readonly string B_TEAM = "B_TEAM";
        private static readonly string C_TEAM = "C_TEAM";

        private static readonly Dictionary<string, Role> _defaultRoleMap = new Dictionary<string, Role>
        {
            {
                ADMIN_ROLE,
                new Role() {
                    Id = 1,
                    Name = "Admin",
                    Description = "Admin Role",
                }
            },
            {
                MANAGER_ROLE,
                new Role()
                {
                    Id = 2,
                    Name = "Manager",
                    Description = "Manager Role",
                }
            },
            {
                EMPLOYEE_ROLE,
                new Role()
                {
                    Id = 3,
                    Name = "Employee",
                    Description = "Employee Role"
                }
            }
        };

        private static readonly Dictionary<string, User> _defaultUserMap = new Dictionary<string, User>
        {
            {
                ADMIN_USER,
                new User()
                {
                    Id = 1,
                    Name = "Admin User",
                    Username = "admin",
                    Password = "admin",
                    RoleId = _defaultRoleMap[ADMIN_ROLE].Id,
                    CitizenId = "000001"
                }
            },
            {
                MANAGER_USER,
                new User()
                {
                    Id = 2,
                    Name = "Manager User",
                    Username = "manager",
                    Password = "manager",
                    RoleId = _defaultRoleMap[MANAGER_ROLE].Id,
                    CitizenId = "000002"
                }
            },
        };

        private static readonly Dictionary<string, Department> _defaultDepartmentMap = new Dictionary<string, Department>
        {
            {
                HEAD_DEPARTMENT, new Department()
                {
                    Id = 1,
                    ManagerId = _defaultUserMap[MANAGER_USER].Id,
                    ParentDepartmentId = null,
                    Name = "Head Department",
                    Detail = "Detail for Head Department",
                }
            }
        };

        private static readonly Dictionary<string, Team> _defaultTeamMap = new Dictionary<string, Team>
        {
            {
                A_TEAM,
                new Team()
                {
                    Id = 1,
                    DepartmentId = _defaultDepartmentMap[HEAD_DEPARTMENT].Id,
                    Name = "The A Team",
                    Detail = "The A Team",
                    LeaderId = _defaultUserMap[ADMIN_USER].Id,
                }
            },
            {
                B_TEAM,
                new Team()
                {
                    Id = 2,
                    DepartmentId = _defaultDepartmentMap[HEAD_DEPARTMENT].Id,
                    Name = "The B Team",
                    Detail = "The B Team",
                    LeaderId = _defaultUserMap[MANAGER_USER].Id,

                }
            },
            {
                C_TEAM,
                new Team()
                {
                    Id = 3,
                    DepartmentId = _defaultDepartmentMap[HEAD_DEPARTMENT].Id,
                    Name = "The C Team",
                    Detail = "The C Team",
                    LeaderId = null,
                }
            }
        };



        private List<Permission> _permissions { get; set; }
        private List<Role> _roles { get; set; }
        private List<Dictionary<string, object>> _rolePermissions { get; set; }
        private List<Department> _departments { get; set; }
        private List<Team> _teams { get; set; }
        private List<User> _users { get; set; }

        private readonly ModelBuilder _modelBuilder;

        public AdministrationDataSeeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
            _permissions = initializePermissions();
            _roles = initializeRoles();
            _rolePermissions = initializeRolePermissions();
            _departments = initializeDepartments();
            _teams = initializeTeams();
            _users = initializeUsers();
        }

        private List<Permission> initializePermissions()
        {
            var index = 0;
            var permissionTextList = ClaimGenerator.GenerateClaims();

            var permissionList = permissionTextList.Select((permission) => new Permission()
            {
                Id = ++index,
                Name = permission,
                Description = permission
            }).ToList();

            return permissionList;
        }

        private List<Role> initializeRoles()
        {
            var startIndex = _defaultRoleMap.Count() + 1;
            var result = new List<Role>() { };

            result.AddRange(_defaultRoleMap.Values.ToList());

            result.AddRange(
                Enumerable.Range(startIndex + 1, result.Count()).Select((id) => new Role()
                {
                    Id = id,
                    Name = $"Role {id}",
                    Description = $"Description for role Role {id}",
                }).ToList());

            return result;
        }

        private List<Dictionary<string, object>> initializeRolePermissions()
        {
            var result = new List<Dictionary<string, object>>();
            _roles.ForEach((role) =>
            {
                _permissions.ForEach((permission) =>
                {
                    result.Add(new Dictionary<string, object>
                    {
                        ["RoleId"] = role.Id,
                        ["PermissionId"] = permission.Id,
                    });
                });
            });

            return result;
        }

        private List<Department> initializeDepartments()
        {
            var result = new List<Department>();
            var startIndex = _defaultDepartmentMap.Values.Count() + 1;

            result.AddRange(_defaultDepartmentMap.Values);

            result.AddRange(Enumerable.Range(startIndex, 10).Select((index) => new Department()
            {
                Id = index,
                Name = $"Department {index}",
                ParentDepartmentId = _defaultDepartmentMap[HEAD_DEPARTMENT].Id,
                Detail = $"Detail for department Department {index}"
            }));

            return result;
        }

        private List<Team> initializeTeams()
        {
            var result = new List<Team>();
            var startIndex = _defaultTeamMap.Values.Count() + 1;

            result.AddRange(_defaultTeamMap.Values);

            result.AddRange(Enumerable.Range(startIndex + 1, 10).Select((index) => new Team()
            {
                Id = index,
                Name = $"Team {index}",
                Detail = $"Detail for department Team {index}",
                DepartmentId = _defaultDepartmentMap[HEAD_DEPARTMENT].Id,
            }));

            return result;
        }

        private List<User> initializeUsers()
        {
            var result = new List<User>();
            var startIndex = _defaultUserMap.Values.Count() + 1;

            result.AddRange(_defaultUserMap.Values);

            result.AddRange(Enumerable.Range(startIndex + 1, 240).Select((index) => new User()
            {
                Id = index,
                Name = $"User {index}",
                Username = $"user{index}",
                Password = $"password{index}",
                CitizenId = $"000000{index}",
                TeamId = index % 2 == 0 ? _defaultTeamMap[A_TEAM].Id : _defaultTeamMap[B_TEAM].Id
            }));

            return result;
        }

        public void SeedData()
        {
            _modelBuilder.Entity<Permission>()
                .HasData(_permissions);

            _modelBuilder.Entity<Role>()
                .HasData(_roles);

            _modelBuilder.Entity("RolePermission")
                .HasData(_rolePermissions);

            _modelBuilder.Entity<Department>()
                .HasData(_departments);

            _modelBuilder.Entity<Team>()
                .HasData(_teams);

            _modelBuilder.Entity<User>()
                .HasData(_users);
        }
    }
}
