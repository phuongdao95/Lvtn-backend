using Microsoft.EntityFrameworkCore;
using Models.Helpers;
using Models.Models;
using System.Security;

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

        public static readonly string TEAM_A = "TEAM_A";
        public static readonly string TEAM_B = "TEAM_B";
        public static readonly string TEAM_C = "TEAM_C";

        public static readonly string GROUP_DEFAULT = "GROUP_DEFAULT";
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
            },
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
                    CitizenId = "000001",
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
                    CitizenId = "000002",
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
                TEAM_A,
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
                TEAM_B,
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
                TEAM_C,
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
                }
            },
            {
                GROUP_B,
                new Group
                {
                    Id = 2,
                    Name = "Group B",
                    Description = "Group B",
                }
            },
            {
                GROUP_C,
                new Group
                {
                    Id = 3,
                    Name = "Group C",
                    Description = "Group C"
                }
            },
            {
                GROUP_DEFAULT,
                new Group
                {
                    Id = 4,
                    Name = "Group Default",
                    Description = "Group Default"
                }
            }
        };


        public List<Permission> Permissions { get; set; }
        public List<Role> Roles { get; set; }
        public List<Dictionary<string, object>> RolePermission { get; set; }
        public List<Department> Departments { get; set; }
        public List<Team> Teams { get; set; }
        public List<User> Users { get; set; }
        public List<Group> Groups { get; set; }
        private List<Dictionary<string,object>> UserGroups { get; set; }
        private (int, int) pageAccessPermissionForAdminIdRange { get; set; }
        private (int, int) pageAccessPermissionForNormalUserIdRange { get; set; }
        private (int, int) resourceAccessPermissionIdRange { get; set; }

        private readonly ModelBuilder _modelBuilder;

        public AdministrationDataSeeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
            Permissions = initializePermissions();
            Roles = initializeRoles();
            RolePermission = initializeRolePermissions();
            Departments = initializeDepartments();
            Teams = initializeTeams();
            Groups = initializeGroups();
            Users = initializeUsers();
            UserGroups = initializeUserGroups();
        }

        private List<Permission> initializePermissions()
        {
            var result = new List<Permission>();

            int index = 0; 
            int startIndex = index; 
            var resourceAccessPermission = ClaimGenerator.GenerateResourceAccessClaims();

            var resourceAccessPermissionList = resourceAccessPermission.Select((permission) => new Permission()
            {
                Id = ++index,
                Module = permission.Split(".")[1],
                Name = permission.Split(".")[2],
                Description = permission
            }).ToList();
            int endIndex = index;
            resourceAccessPermissionIdRange = (startIndex, endIndex);


            startIndex = index + 1;
            var pageAccessPermissionForAdmin = ClaimGenerator.GeneratePageAccessClaimsForAdminUser();
            var pageAccessPermissionListForAdminUser= pageAccessPermissionForAdmin.Select((permission) => new Permission()
            {
                Id = ++index,
                Module = permission.Split(".")[0],
                Name = permission,
                Description = permission
            }).ToList();

            endIndex = index;
            pageAccessPermissionForAdminIdRange = (startIndex, endIndex);

            startIndex = index + 1;
            var pageAccessForNormalUser = ClaimGenerator.GeneratePageAccessClaimsForNormalUser();
            var pageAccessPermissionListForNormalUser = pageAccessForNormalUser.Select((permission) => new Permission()
            {
                Id = ++index,
                Module = permission.Split(".")[0],
                Name = permission,
                Description = permission
            }).ToList();
            endIndex = index;
            pageAccessPermissionForNormalUserIdRange = (startIndex, endIndex);


            result.AddRange(pageAccessPermissionListForNormalUser);
            result.AddRange(pageAccessPermissionListForAdminUser);
            result.AddRange(resourceAccessPermissionList);

            return result;
        }

        private List<Role> initializeRoles()
        {
            var startIndex = DefaultRoleMap.Count() + 1;
            var result = new List<Role>() { };

            result.AddRange(DefaultRoleMap.Values.ToList());

            return result;
        }

        private List<Dictionary<string, object>> initializeUserGroups()
        {
            var result = new List<Dictionary<string, object>>();

            Users.ForEach((user) =>
            {
                Groups.ForEach((group) =>
                {
                    result.Add(new Dictionary<string, object>
                    {
                        ["UserId"]= user.Id,
                        ["GroupId"]= group.Id,
                    });
                });
            });

            return result;
        }

        private List<Dictionary<string, object>> initializeRolePermissions()
        {
            var result = new List<Dictionary<string, object>>();
            Roles.ForEach((role) =>
            {
                Permissions.ForEach((permission) =>
                {
                    // Generate permissions for admin, manager
                    if ((role.Id == 1 || role.Id == 2) && 
                        (
                            (
                                permission.Id >= pageAccessPermissionForAdminIdRange.Item1 && 
                                permission.Id <= pageAccessPermissionForAdminIdRange.Item2
                            ) ||
                            (

                                permission.Id >= resourceAccessPermissionIdRange.Item1 &&
                                permission.Id <= resourceAccessPermissionIdRange.Item2
                            )
                         )
                    )
                    {
                        result.Add(new Dictionary<string, object>
                        {
                            ["RoleId"] = role.Id,
                            ["PermissionId"] = permission.Id,
                        });
                    }
                    // Generate permissions for normal user
                    else if (
                        (role.Id != 1 && role.Id != 2) &&
                        (
                            (
                                permission.Id >= pageAccessPermissionForNormalUserIdRange.Item1 &&
                                permission.Id <= pageAccessPermissionForNormalUserIdRange.Item2
                            ) ||
                            (
                                permission.Id >= resourceAccessPermissionIdRange.Item1 &&
                                permission.Id <= resourceAccessPermissionIdRange.Item2
                            )
                        )
                    )
                    {
                        result.Add(new Dictionary<string, object>
                        {
                            ["RoleId"] = role.Id,
                            ["PermissionId"] = permission.Id,
                        });
                    }
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

            result.AddRange(Enumerable.Range(startIndex + 1, 100).Select((index) => new User()
            {
                Id = index,
                Name = $"User {index}",
                Username = $"user{index}",
                Password = $"password{index}",
                CitizenId = $"000000{index}",
                RoleId = DefaultRoleMap[EMPLOYEE_ROLE].Id ,
                TeamId = Teams[index % Teams.Count()].Id,
                BaseSalary = 10_000_000
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
                .HasData(Permissions);

            _modelBuilder.Entity<Role>()
                .HasData(Roles);

            _modelBuilder.Entity("RolePermission")
                .HasData(RolePermission);

            _modelBuilder.Entity<Department>()
                .HasData(Departments);

            _modelBuilder.Entity<Team>()
                .HasData(Teams);

            _modelBuilder.Entity<Group>()
                .HasData(Groups);

            _modelBuilder.Entity<User>()
                .HasData(Users);

            _modelBuilder.Entity("UserGroup")
                .HasData(UserGroups);
        }
    }
}
