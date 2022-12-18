using Microsoft.EntityFrameworkCore;
using Models.DTO.Response;
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
        public static readonly string TEAMLEAD_ROLE = "TEAMLEAD_ROLE";

        public static readonly string ADMIN_USER = "ADMIN_USER";
        public static readonly string MANAGER_USER = "MANAGER_USER";
        public static readonly string HEAD_DEPARTMENT = "HEAD_DEPARTMENT";

        public static readonly string TEAM_DEFAULT = "TEAM_DEFAULT";
        public static readonly string TEAM_A = "TEAM_A";
        public static readonly string TEAM_B = "TEAM_B";
        public static readonly string TEAM_C = "TEAM_C";
        public static readonly string TEAM_D = "TEAM_D";
        public static readonly string TEAM_E = "TEAM_E";
        public static readonly string TEAM_F = "TEAM_F";
        public static readonly string TEAM_G = "TEAM_G";
        public static readonly string TEAM_H = "TEAM_H";
        public static readonly string TEAM_I = "TEAM_I";

        public static readonly string GROUP_DEFAULT = "GROUP_DEFAULT";
        public static readonly string GROUP_A = "GROUP_A";
        public static readonly string GROUP_B = "GROUP_B";
        public static readonly string GROUP_C = "GROUP_C";

        public List<Dictionary<string, string>> nameList = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string>
            {
                ["Name"] = "Trịnh Minh Cảnh",
                ["Username"] = "tminhcanh",
                ["Gender"] = "male",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Hoàng Trung Hiếu",
                ["Username"] = "htrunghieu",
                ["Gender"] = "male",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Đồng Gia Hùng",
                ["Username"] = "dgiahung",
                ["Gender"] = "male"
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Bá Long Quân",
                ["Username"] = "blongquan",
                ["Gender"] = "male"
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Trí Ngọc Trụ",
                ["Username"] = "tngoctru",
                ["Gender"] = "male"
            },            
            new Dictionary<string, string>
            {
                ["Name"] = "Giáp Quốc Thành",
                ["Username"] = "gquocthanh",
                ["Gender"] = "male"
            },            
            new Dictionary<string, string>
            {
                ["Name"] = "Khương Gia Cần",
                ["Username"] = "kgiacan",
                ["Gender"] = "male"
            },            
            new Dictionary<string, string>
            {
                ["Name"] = "Cát Khánh Hải",
                ["Username"] = "ckhanhhai",
                ["Gender"] = "male"
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Quản Quốc Hoàng",
                ["Username"] = "qquochoang",
                ["Gender"] = "male"
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Mang Hải Nam",
                ["Username"] = "mhainam",
                ["Gender"] = "male",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Thành Đức Toàn",
                ["Username"] = "tductoan",
                ["Gender"] = "male",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Ngân Huy Tuấn",
                ["Username"] = "nhuytuan",
                ["Gender"] = "male",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Phương Trường Thành",
                ["Username"] = "ptuongthanh",
                ["Gender"] = "male",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Phi Hòa Bình",
                ["Username"] = "phoabinh",
                ["Gender"] = "male",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Đỗ Hữu Đạt",
                ["Username"] = "dhuudat",
                ["Gender"] = "male",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Xung Hồng Giang",
                ["Username"] = "xhonggiang",
                ["Gender"] = "male",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Nông Cẩm Hường",
                ["Username"] = "ncamhuong",
                ["Gender"] = "female",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Đào Kiều Anh",
                ["Username"] = "dkieuanh",
                ["Gender"] = "female",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Tiếp Mỹ Hường",
                ["Username"] = "tmyhuong",
                ["Gender"] = "female",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Dư Tường Vy",
                ["Username"] = "dtuongvy",
                ["Gender"] = "female",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Bảo Phương Quế",
                ["Username"] = "bphuongque",
                ["Gender"] = "female"
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Đặng Thủy Quỳnh",
                ["Username"] = "dthuyquynh",
                ["Gender"] = "female",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Phong Yến Nhi",
                ["Username"] = "pyennhi",
                ["Gender"] = "female",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Đan Quỳnh Nhung",
                ["Username"] = "dquynhnhung",
                ["Gender"] = "female",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Âu Dương Phương Quế",
                ["Username"] = "adphuongque",
                ["Gender"] = "female",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Mã Mai Liên",
                ["Username"] = "mmailien",
                ["Gender"] = "female",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Mẫn Bạch Vân",
                ["Username"] = "mbachvan",
                ["Gender"] = "female",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Tống Cao Phong",
                ["Username"] = "tcaophong",
                ["Gender"] = "male",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Võ Minh Nhật",
                ["Username"] = "vminhnhat",
                ["Gender"] = "male",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Dư Thiện Đức",
                ["Username"] = "dthienduc",
                ["Gender"] = "male",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Đặng Thế Vinh",
                ["Username"] = "dthevinh",
                ["Gender"] = "male",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Nguyễn Công Bằng",
                ["Username"] = "ncongbang",
                ["Gender"] = "male",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Ca Quang Đức",
                ["Username"] = "cquangduc",
                ["Gender"] = "male"
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Linh Công Sơn",
                ["Username"] = "lcongson",
                ["Gender"] = "male"
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Kha Thành Phương",
                ["Username"] = "kthanhphuong",
                ["Gender"] = "male",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Khu Hoài Nam",
                ["Username"] = "khoainam",
                ["Gender"] = "male"
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Hàn Thế Sơn",
                ["Username"] = "htheson",
                ["Gender"] = "male"
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Nhan Ngọc Quế",
                ["Username"] = "nngocque",
                ["Gender"] = "female",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Linh Minh Phương",
                ["Username"] = "lminhphuong",
                ["Gender"] = "female",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Thành Thảo Quyên",
                ["Username"] = "tthaoquyen",
                ["Gender"] = "female",
            },
            new Dictionary<string, string>
            {
                ["Name"] = "Thục Trúc Mai",
                ["Username"] = "ttrucmai",
                ["Gender"] = "female",
            }
        };

        public static readonly Dictionary<string, Role> DefaultRoleMap = new Dictionary<string, Role>
        {
            {
                ADMIN_ROLE,
                new Role() {
                    Id = 1,
                    Name = "Admin",
                    Description = "Chức vụ Quản trị viên",
                }
            },
            {
                MANAGER_ROLE,
                new Role()
                {
                    Id = 2,
                    Name = "Manager",
                    Description = "Chức vụ Quản lý",
                }
            },
            {
                TEAMLEAD_ROLE,
                new Role()
                {
                    Id = 4,
                    Name = "Team Lead",
                    Description = "Chức vụ Lãnh đạo team"
                }
            },
            {
                EMPLOYEE_ROLE,
                new Role()
                {
                    Id = 3,
                    Name = "Employee",
                    Description = "Chức vụ nhân viên"
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
                    Gender = "male",
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
                    Gender = "male",
                }
            },
        };


        public static readonly string FINANCIAL_DEPARTMENT = "FINANCIAL_DEPARTMENT";
        public static readonly string HUMANRESOURCE_DEPARTMENT = "HUMANRESOURCE_DEPARTMENT";
        public static readonly string ITSUPPORT_DEPARTMENT = "ITSUPPORT_DEPARTMENT";
        public static readonly string IT_DEPARTMENT = "IT_DEPARTMENT";

        public static readonly Dictionary<string, Department> DefaultDepartmentMap = new Dictionary<string, Department>
        {
            {
                HEAD_DEPARTMENT, 
                new Department()
                {
                    Id = 1,
                    ParentDepartmentId = 1,
                    Name = "Head Department",
                    Detail = "Detail for Head Department",
                }
            },
            {
                FINANCIAL_DEPARTMENT,
                new Department()
                {
                    Id = 2,
                    ParentDepartmentId = 1,
                    Name = "Phòng ban Tài chính",
                    Detail = "Detail for Head Department",
                }

            },
            {
                HUMANRESOURCE_DEPARTMENT,
                new Department()
                {
                    Id = 3,
                    ParentDepartmentId = 1,
                    Name = "Phòng ban Nhân sự",
                    Detail = "Detail for Head Department",
                }
            },
            {
                ITSUPPORT_DEPARTMENT,
                new Department()
                {
                    Id = 4,
                    ParentDepartmentId = 1,
                    Name = "Phòng ban IT Support",
                    Detail = "Detail for Head Department",
                }
            },
            {
                IT_DEPARTMENT,
                new Department()
                {
                    Id = 5,
                    ParentDepartmentId = 1,
                    Name = "Phòng ban IT",
                    Detail = "Detail for Head Department",
                }
            },
        };

        public static readonly Dictionary<string, Team> DefaultTeamMap = new Dictionary<string, Team>
        {
            {
                TEAM_DEFAULT,
                new Team()
                {
                    Id = 1,
                    DepartmentId = DefaultDepartmentMap[HEAD_DEPARTMENT].Id,
                    Name = "Team Mặc định",
                    Detail = "Team Mặc định",
                    LeaderId = null,
                }
            },
            {
                TEAM_A,
                new Team()
                {
                    Id = 2,
                    DepartmentId = DefaultDepartmentMap[IT_DEPARTMENT].Id,
                    Name = "Team A",
                    Detail = "Team A",
                    LeaderId = null,
                }
            },
            {
                TEAM_B,
                new Team()
                {
                    Id = 3,
                    DepartmentId = DefaultDepartmentMap[HUMANRESOURCE_DEPARTMENT].Id,
                    Name = "Team B",
                    Detail = "Team B",
                    LeaderId = DefaultUserMap[MANAGER_USER].Id,

                }
            },
            {
                TEAM_C,
                new Team()
                {
                    Id = 4,
                    DepartmentId = DefaultDepartmentMap[ITSUPPORT_DEPARTMENT].Id,
                    Name = "Team C",
                    Detail = "Team C",
                    LeaderId = null,
                }
            },
            {
                TEAM_D,
                new Team()
                {
                    Id = 5,
                    DepartmentId = DefaultDepartmentMap[FINANCIAL_DEPARTMENT].Id,
                    Name = "Team D",
                    Detail = "Team D",
                    LeaderId = null,
                }
            },
            {
                TEAM_E,
                new Team()
                {
                    Id = 6,
                    DepartmentId = DefaultDepartmentMap[IT_DEPARTMENT].Id,
                    Name = "Team E",
                    Detail = "Team E",
                    LeaderId = null,
                }
            },
            {
                TEAM_F,
                new Team()
                {
                    Id = 7,
                    DepartmentId = DefaultDepartmentMap[IT_DEPARTMENT].Id,
                    Name = "Team F",
                    Detail = "Team F",
                    LeaderId = null,
                }
            },
            {
                TEAM_G,
                new Team()
                {
                    Id = 8,
                    DepartmentId = DefaultDepartmentMap[IT_DEPARTMENT].Id,
                    Name = "Team G",
                    Detail = "Team G",
                    LeaderId = null,
                }
            },            
            {
                TEAM_H,
                new Team()
                {
                    Id = 9,
                    DepartmentId = DefaultDepartmentMap[IT_DEPARTMENT].Id,
                    Name = "Team H",
                    Detail = "Team H",
                    LeaderId = null,
                }
            },
            {
                TEAM_I,
                new Team()
                {
                    Id = 10,
                    DepartmentId = DefaultDepartmentMap[IT_DEPARTMENT].Id,
                    Name = "Team I",
                    Detail = "Team I",
                    LeaderId = null,
                }
            }
        };

        public static readonly Dictionary<string, Group> DefaultGroupMap = new Dictionary<string, Group>
        {
            {
                GROUP_DEFAULT,
                new Group
                {
                    Id = 1,
                    Name = "Group Mặc định",
                    Description = "Group Mặc định"
                }
            },
            {
                GROUP_A,
                new Group
                {
                    Id = 2,
                    Name = "Group A",
                    Description = "Group A",
                }
            },
            {
                GROUP_B,
                new Group
                {
                    Id = 3,
                    Name = "Group B",
                    Description = "Group B",
                }
            },
            {
                GROUP_C,
                new Group
                {
                    Id = 4,
                    Name = "Group C",
                    Description = "Group C"
                }
            },
        };


        public List<Permission> Permissions { get; set; }
        public List<Role> Roles { get; set; }
        public List<Dictionary<string, object>> RolePermission { get; set; }
        public List<Department> Departments { get; set; }
        public List<Team> Teams { get; set; }
        public List<User> Users { get; set; }
        public List<Group> Groups { get; set; }
        private List<Dictionary<string,object>> UserGroups { get; set; }

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
            var resourceAccessPermission = ClaimGenerator.GenerateResourceAccessClaims();

            var resourceAccessPermissionList = resourceAccessPermission.Select((permission) => new Permission()
            {
                Id = ++index,
                Module = "resource",
                Name = permission,
                Description = generatePermissionDescriptionPrefix(permission.Split(".")[1]) + permission.Split(".")[0]
            }).ToList();
            int endIndex = index;

            var pageAccessClaims = ClaimGenerator.GeneratePageAccessClaims();
            var pageAccessPermissionList = pageAccessClaims.Select((permission) => new Permission()
            {
                Id = ++index,
                Module = "page_access",
                Name = permission,
                Description = generatePermissionDescriptionPrefix("page_access") + permission,
            }).ToList();

            result.AddRange(pageAccessPermissionList);
            result.AddRange(resourceAccessPermissionList);

            return result;
        }

        private string generatePermissionDescriptionPrefix(string permissionName)
        {
            switch (permissionName)
            {
                case "create":
                    return "Tạo mới ";
                case "update":
                    return "Cập nhật ";
                case "delete":
                    return "Xóa ";
                case "retrieve":
                    return "Xem ";
                case "page_access":
                    return "Truy cập trang ";
                default:
                    return "";
            }
        }

        private List<Role> initializeRoles()
        {
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

            var pageAccessClaimsForAdminUser = ClaimGenerator.GeneratePageAccessClaimsForAdminUser();
            var resourceAccessClaimsForAdminUser = ClaimGenerator.GenerateResourceAccessClaimsForAdminUser();
            var accessClaimsForAdminUser = pageAccessClaimsForAdminUser
                .Concat(resourceAccessClaimsForAdminUser)
                .ToList();

            var adminPermissionIds = Permissions
                .Where(p => accessClaimsForAdminUser.Contains(p.Name))
                .Select(p => p.Id)  
                .ToList();

            var pageAccessClaimsForNormalUser = ClaimGenerator.GeneratePageAccessClaimsForNormalUser();
            var resourceAccessClaimsForNormalUser = ClaimGenerator.GenerateResourceAccessClaimsForNormalUser();
            var accessClaimsForNormalUser = pageAccessClaimsForNormalUser
                .Concat(resourceAccessClaimsForNormalUser)
                .ToList();

            var normalUserPermissionIds = Permissions
                .Where(p => accessClaimsForNormalUser.Contains(p.Name))
                .Select(p => p.Id)
                .ToList();

            Roles.ForEach((role) =>
            {
                Permissions.ForEach((permission) =>
                {
                    /** Admin and Manager*/
                    if ((role.Id == 1 || role.Id == 2) && adminPermissionIds.Contains(permission.Id))
                    {
                        result.Add(new Dictionary<string, object>
                        {
                            ["RoleId"] = role.Id,
                            ["PermissionId"] = permission.Id,
                        });
                    }

                    if ((role.Id != 1 && role.Id != 2) && normalUserPermissionIds.Contains(permission.Id))
                    {
                        result.Add(new Dictionary<string, object>
                        {
                            ["RoleId"] = role.Id,
                            ["PermissionId"] = permission.Id
                        });
                    }
                });
            });

            return result;
        }


        private List<Department> initializeDepartments()
        {
            var result = new List<Department>();

            result.AddRange(DefaultDepartmentMap.Values);

            return result;
        }

        private List<Team> initializeTeams()
        {
            var result = new List<Team>();
            result.AddRange(DefaultTeamMap.Values);
            return result;
        }

        private List<User> initializeUsers()
        {
            var result = new List<User>();
            var startIndex = DefaultUserMap.Values.Count() + 1;

            result.AddRange(DefaultUserMap.Values);

            result.AddRange(nameList.Select((user) => new User()
            {
                Id = ++startIndex,
                Name = user["Name"],
                Gender = user["Gender"],
                Username = user["Username"],
                Password = user["Username"],
                RoleId = DefaultRoleMap[EMPLOYEE_ROLE].Id,
                TeamId = Teams[startIndex % Teams.Count()].Id,
                BaseSalary = new Random().Next(100, 220) * 100_000,
                PhoneNumber = new Random().Next(100000000, 999999999).ToString(),
                CitizenId = new Random().Next(100000000, 999999999).ToString(),
                Email = $"{user["Username"]}@ems.com",
                Birthday = new DateTime(new Random().Next(1990, 2000), new Random().Next(1, 12), new Random().Next(1, 27)),
            }));

            return result;
        }

        private List<Group> initializeGroups()
        {
            var result = new List<Group>();

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
