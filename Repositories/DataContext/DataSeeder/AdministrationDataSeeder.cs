using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Helpers;
using Models.Models;

namespace Repositories.DataContext.DataSeeder
{
    public class AdministrationDataSeeder : DataSeeder
    {
        public static readonly string ADMIN_ROLE = "ADMIN_USER";
        public static readonly string MANAGER_ROLE = "MANAGER_USER";
        public static readonly string EMPLOYEE_ROLE = "EMPLOYEE_ROLE";

        public static readonly string ADMIN_USER = "ADMIN_USER";
        public static readonly string MANAGER_USER = "MANAGER_USER";

        public static readonly string HEAD_DEPARTMENT = "HEAD_DEPARTMENT";

        public static readonly string A_TEAM = "A_TEAM";
        public static readonly string B_TEAM = "B_TEAM";
        public static readonly string C_TEAM = "C_TEAM";

        public static readonly string GROUP_A = "GROUP_A";
        public static readonly string GROUP_B = "GROUP_B";
        public static readonly string GROUP_C = "GROUP_C";

        public static readonly Dictionary<string, Role> DefaultRoleMap = new Dictionary<string, Role>
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

        public static readonly Dictionary<string, User> DefaultUserMap = new Dictionary<string, User>
        {
            {
                ADMIN_USER,
                new User()
                {
                    Id = 1,
                    Name = "Admin User",
                    Username = "admin",
                    Password = "admin",
                    RoleId = DefaultRoleMap[ADMIN_ROLE].Id,
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
                    RoleId = DefaultRoleMap[MANAGER_ROLE].Id,
                    CitizenId = "000002"
                }
            },
        };

        public static readonly Dictionary<string, Department> DefaultDepartmentMap = new Dictionary<string, Department>
        {
            {
                HEAD_DEPARTMENT, new Department()
                {
                    Id = 1,
                    ManagerId = DefaultUserMap[MANAGER_USER].Id,
                    ParentDepartmentId = null,
                    Name = "Head Department",
                    Detail = "Detail for Head Department",
                }
            }
        };

        public static readonly Dictionary<string, Team> DefaultTeamMap = new Dictionary<string, Team>
        {
            {
                A_TEAM,
                new Team()
                {
                    Id = 1,
                    DepartmentId = DefaultDepartmentMap[HEAD_DEPARTMENT].Id,
                    Name = "The A Team",
                    Detail = "The A Team",
                    LeaderId = DefaultUserMap[ADMIN_USER].Id,
                }
            },
            {
                B_TEAM,
                new Team()
                {
                    Id = 2,
                    DepartmentId = DefaultDepartmentMap[HEAD_DEPARTMENT].Id,
                    Name = "The B Team",
                    Detail = "The B Team",
                    LeaderId = DefaultUserMap[MANAGER_USER].Id,

                }
            },
            {
                C_TEAM,
                new Team()
                {
                    Id = 3,
                    DepartmentId = DefaultDepartmentMap[HEAD_DEPARTMENT].Id,
                    Name = "The C Team",
                    Detail = "The C Team",
                    LeaderId = null,
                }
            }
        };

        public static readonly Dictionary<string, Group> DefaultGroupMap = new Dictionary<string, Group>
        {
            {
                GROUP_A,
                new Group
                {
                    Id = 1,
                    Name = "Group A",
                    Description = "Group A",
                    FormulaName = "formula_1",
                }
            },
            {
                GROUP_B,
                new Group
                {
                    Id = 2,
                    Name = "Group B",
                    Description  = "Group B",
                    FormulaName = "formula_2",
                }
            },
            {
                GROUP_C,
                new Group
                {
                    Id = 3,
                    Name = "Group C",
                    Description = "Group C",
                    FormulaName = "formula_3"
                }
            }
        };

        private List<Permission> _permissions { get; set; }
        private List<Role> _roles { get; set; }
        private List<Dictionary<string, object>> _rolePermissions { get; set; }
        private List<Department> _departments { get; set; }
        private List<Team> _teams { get; set; }
        private List<User> _users { get; set; }
        private List<Group> _groups { get; set; }

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
            _groups = initializeGroups();
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
            var startIndex = DefaultRoleMap.Count() + 1;
            var result = new List<Role>() { };

            result.AddRange(DefaultRoleMap.Values.ToList());

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
            var startIndex = DefaultDepartmentMap.Values.Count() + 1;

            result.AddRange(DefaultDepartmentMap.Values);

            result.AddRange(Enumerable.Range(startIndex, 10).Select((index) => new Department()
            {
                Id = index,
                Name = $"Department {index}",
                ParentDepartmentId = DefaultDepartmentMap[HEAD_DEPARTMENT].Id,
                Detail = $"Detail for department Department {index}"
            }));

            return result;
        }

        private List<Team> initializeTeams()
        {
            var result = new List<Team>();
            var startIndex = DefaultTeamMap.Values.Count() + 1;

            result.AddRange(DefaultTeamMap.Values);

            result.AddRange(Enumerable.Range(startIndex + 1, 10).Select((index) => new Team()
            {
                Id = index,
                Name = $"Team {index}",
                Detail = $"Detail for department Team {index}",
                DepartmentId = DefaultDepartmentMap[HEAD_DEPARTMENT].Id,
            }));

            return result;
        }

        private List<User> initializeUsers()
        {
            var result = new List<User>();
            var startIndex = DefaultUserMap.Values.Count() + 1;

            result.AddRange(DefaultUserMap.Values);

            result.AddRange(Enumerable.Range(startIndex + 1, 240).Select((index) => new User()
            {
                Id = index,
                Name = $"User {index}",
                Username = $"user{index}",
                Password = $"password{index}",
                CitizenId = $"000000{index}",
                TeamId = index % 2 == 0 ? DefaultTeamMap[A_TEAM].Id : DefaultTeamMap[B_TEAM].Id
            }));

            return result;
        }

        private List<Group> initializeGroups()
        {
            var result = new List<Group>();
            var startIndex = DefaultGroupMap.Values.Count() + 1;

            result.AddRange(DefaultGroupMap.Values);

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

            _modelBuilder.Entity<Group>()
                .HasData(_groups);
        }
    }
}
