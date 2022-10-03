using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class UpdateSextoGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payrolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payrolls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryDeltas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FromMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToMonth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryDeltas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryFormulas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Define = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryFormulas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormulaName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryVariables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryVariables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskLabels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskLabels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingShiftEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingShiftEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.PermissionId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RolePermission_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermission_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    ParentDepartmentId = table.Column<int>(type: "int", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_ParentDepartmentId",
                        column: x => x.ParentDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payslips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    PayrollId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payslips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payslips_Payrolls_PayrollId",
                        column: x => x.PayrollId,
                        principalTable: "Payrolls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PayslipSalaryDelta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryDeltaType = table.Column<int>(type: "int", nullable: false),
                    FromMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PayslipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayslipSalaryDelta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayslipSalaryDelta_Payslips_PayslipId",
                        column: x => x.PayslipId,
                        principalTable: "Payslips",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskBoards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskColumns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskColumns_TaskBoards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "TaskBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskCommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskFiles_TaskComments_TaskCommentId",
                        column: x => x.TaskCommentId,
                        principalTable: "TaskComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    ColumnId = table.Column<int>(type: "int", nullable: true),
                    ColumnId1 = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskColumns_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "TaskColumns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskColumns_ColumnId1",
                        column: x => x.ColumnId1,
                        principalTable: "TaskColumns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskTaskLabel",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    TaskLabelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTaskLabel", x => new { x.TaskId, x.TaskLabelId });
                    table.ForeignKey(
                        name: "FK_TaskTaskLabel_TaskLabels_TaskLabelId",
                        column: x => x.TaskLabelId,
                        principalTable: "TaskLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskTaskLabel_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CitizenId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    FaceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenSlack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenTrello = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    SocialInsuranceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankInfoId = table.Column<int>(type: "int", nullable: true),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_BankInfo_BankInfoId",
                        column: x => x.BankInfoId,
                        principalTable: "BankInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_SalaryGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "SalaryGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Users_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserSalaryDelta",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SalaryDeltaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSalaryDelta", x => new { x.UserId, x.SalaryDeltaId });
                    table.ForeignKey(
                        name: "FK_UserSalaryDelta_SalaryDeltas_SalaryDeltaId",
                        column: x => x.SalaryDeltaId,
                        principalTable: "SalaryDeltas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSalaryDelta_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingShiftEventUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WorkingShiftEventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingShiftEventUser", x => new { x.UserId, x.WorkingShiftEventId });
                    table.ForeignKey(
                        name: "FK_WorkingShiftEventUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingShiftEventUser_WorkingShiftEvents_WorkingShiftEventId",
                        column: x => x.WorkingShiftEventId,
                        principalTable: "WorkingShiftEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingShiftTimekeepings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DidCheckIn = table.Column<bool>(type: "bit", nullable: false),
                    CheckinTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DidCheckout = table.Column<bool>(type: "bit", nullable: false),
                    CheckoutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkingShiftEventId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PayslipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingShiftTimekeepings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingShiftTimekeepings_Payslips_PayslipId",
                        column: x => x.PayslipId,
                        principalTable: "Payslips",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkingShiftTimekeepings_Users_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingShiftTimekeepings_WorkingShiftEvents_WorkingShiftEventId",
                        column: x => x.WorkingShiftEventId,
                        principalTable: "WorkingShiftEvents",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Payrolls",
                columns: new[] { "Id", "Description", "FromDate", "Name", "Status", "ToDate" },
                values: new object[,]
                {
                    { 1, "Generated payroll 1", new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generated Payroll 1", 0, new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Generated payroll 2", new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generated Payroll 2", 0, new DateTime(2022, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Generated payroll 2", new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generated Payroll 2", 0, new DateTime(2022, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "user.create", "user.create" },
                    { 2, "user.retrieve", "user.retrieve" },
                    { 3, "user.update", "user.update" },
                    { 4, "user.delete", "user.delete" },
                    { 5, "role.create", "role.create" },
                    { 6, "role.retrieve", "role.retrieve" },
                    { 7, "role.update", "role.update" },
                    { 8, "role.delete", "role.delete" },
                    { 9, "permission.create", "permission.create" },
                    { 10, "permission.retrieve", "permission.retrieve" },
                    { 11, "permission.update", "permission.update" },
                    { 12, "permission.delete", "permission.delete" },
                    { 13, "team.create", "team.create" },
                    { 14, "team.retrieve", "team.retrieve" },
                    { 15, "team.update", "team.update" },
                    { 16, "team.delete", "team.delete" },
                    { 17, "department.create", "department.create" },
                    { 18, "department.retrieve", "department.retrieve" },
                    { 19, "department.update", "department.update" },
                    { 20, "department.delete", "department.delete" },
                    { 21, "group.create", "group.create" },
                    { 22, "group.retrieve", "group.retrieve" },
                    { 23, "group.update", "group.update" },
                    { 24, "group.delete", "group.delete" },
                    { 25, "dab.create", "dab.create" },
                    { 26, "dab.retrieve", "dab.retrieve" },
                    { 27, "dab.update", "dab.update" },
                    { 28, "dab.delete", "dab.delete" },
                    { 29, "salary_formula.create", "salary_formula.create" },
                    { 30, "salary_formula.retrieve", "salary_formula.retrieve" },
                    { 31, "salary_formula.update", "salary_formula.update" },
                    { 32, "salary_formula.delete", "salary_formula.delete" },
                    { 33, "salary_variable.create", "salary_variable.create" },
                    { 34, "salary_variable.retrieve", "salary_variable.retrieve" },
                    { 35, "salary_variable.update", "salary_variable.update" },
                    { 36, "salary_variable.delete", "salary_variable.delete" },
                    { 37, "payroll.create", "payroll.create" },
                    { 38, "payroll.retrieve", "payroll.retrieve" },
                    { 39, "payroll.update", "payroll.update" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 40, "payroll.delete", "payroll.delete" },
                    { 41, "payslip.create", "payslip.create" },
                    { 42, "payslip.retrieve", "payslip.retrieve" },
                    { 43, "payslip.update", "payslip.update" },
                    { 44, "payslip.delete", "payslip.delete" },
                    { 45, "milestone.create", "milestone.create" },
                    { 46, "milestone.retrieve", "milestone.retrieve" },
                    { 47, "milestone.update", "milestone.update" },
                    { 48, "milestone.delete", "milestone.delete" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Admin Role", "Admin" },
                    { 2, "Manager Role", "Manager" },
                    { 3, "Employee Role", "Employee" },
                    { 5, "Description for role Role 5", "Role 5" },
                    { 6, "Description for role Role 6", "Role 6" },
                    { 7, "Description for role Role 7", "Role 7" }
                });

            migrationBuilder.InsertData(
                table: "SalaryDeltas",
                columns: new[] { "Id", "Description", "Formula", "FromMonth", "Name", "ToMonth", "Type" },
                values: new object[,]
                {
                    { 1, "Salary Delta 2", "variable_1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salary Delta 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, "Salary Delta 2", "variable_2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salary Delta 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3, "Salary Delta 3", "variable_3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salary Delta 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "SalaryFormulas",
                columns: new[] { "Id", "Define", "Description", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1, "200000", "formula_1", "Formula One", "formula_1" },
                    { 2, "200000 + variable_1", "formula_2", "Formula Two", "formula_2" },
                    { 3, "variable_1 + variable_2", "formula_3", "Formula Three", "formula_3" },
                    { 4, "IF(variable_4, 400000, 200000)", "formula_4", "Formula Three", "formula_4" }
                });

            migrationBuilder.InsertData(
                table: "SalaryGroups",
                columns: new[] { "Id", "Description", "FormulaName", "Name" },
                values: new object[,]
                {
                    { 1, "Group A", "formula_1", "Group A" },
                    { 2, "Group B", "formula_2", "Group B" },
                    { 3, "Group C", "formula_3", "Group C" }
                });

            migrationBuilder.InsertData(
                table: "SalaryVariables",
                columns: new[] { "Id", "DataType", "Description", "DisplayName", "Name", "Value" },
                values: new object[,]
                {
                    { 1, 1, "variable 1", "Variable One", "variable_1", "200000" },
                    { 2, 1, "variable 2", "Variable Two", "variable_2", "170000" },
                    { 3, 1, "variable 3", "Variable Three", "variable_3", "170000" },
                    { 4, 2, null, "Variable Four", "variable_4", "TRUE" },
                    { 5, 2, null, "Variable Five", "variable_5", "FALSE" }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftEvents",
                columns: new[] { "Id", "Description", "EndTime", "Formula", "Name", "StartTime" },
                values: new object[,]
                {
                    { 1, "Normal Working Day", new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Normal Working Day", new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Normal Working Day", new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Normal Working Day", new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Normal Working Day", new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Normal Working Day", new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Normal Working Day", new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Normal Working Day", new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Normal Working Day", new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Normal Working Day", new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Normal Working Day", new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Normal Working Day", new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftEvents",
                columns: new[] { "Id", "Description", "EndTime", "Formula", "Name", "StartTime" },
                values: new object[,]
                {
                    { 13, "Normal Working Day", new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Normal Working Day", new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Normal Working Day", new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "Normal Working Day", new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Normal Working Day", new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "Normal Working Day", new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "Normal Working Day", new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "Normal Working Day", new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "Normal Working Day", new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "Normal Working Day", new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), "2", "Normal Working Day", new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 5 },
                    { 5, 6 },
                    { 5, 7 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 3 },
                    { 6, 5 },
                    { 6, 6 },
                    { 6, 7 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 5 },
                    { 7, 6 },
                    { 7, 7 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 8, 1 },
                    { 8, 2 },
                    { 8, 3 },
                    { 8, 5 },
                    { 8, 6 },
                    { 8, 7 },
                    { 9, 1 },
                    { 9, 2 },
                    { 9, 3 },
                    { 9, 5 },
                    { 9, 6 },
                    { 9, 7 },
                    { 10, 1 },
                    { 10, 2 },
                    { 10, 3 },
                    { 10, 5 },
                    { 10, 6 },
                    { 10, 7 },
                    { 11, 1 },
                    { 11, 2 },
                    { 11, 3 },
                    { 11, 5 },
                    { 11, 6 },
                    { 11, 7 },
                    { 12, 1 },
                    { 12, 2 },
                    { 12, 3 },
                    { 12, 5 },
                    { 12, 6 },
                    { 12, 7 },
                    { 13, 1 },
                    { 13, 2 },
                    { 13, 3 },
                    { 13, 5 },
                    { 13, 6 },
                    { 13, 7 },
                    { 14, 1 },
                    { 14, 2 },
                    { 14, 3 },
                    { 14, 5 },
                    { 14, 6 },
                    { 14, 7 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 15, 1 },
                    { 15, 2 },
                    { 15, 3 },
                    { 15, 5 },
                    { 15, 6 },
                    { 15, 7 },
                    { 16, 1 },
                    { 16, 2 },
                    { 16, 3 },
                    { 16, 5 },
                    { 16, 6 },
                    { 16, 7 },
                    { 17, 1 },
                    { 17, 2 },
                    { 17, 3 },
                    { 17, 5 },
                    { 17, 6 },
                    { 17, 7 },
                    { 18, 1 },
                    { 18, 2 },
                    { 18, 3 },
                    { 18, 5 },
                    { 18, 6 },
                    { 18, 7 },
                    { 19, 1 },
                    { 19, 2 },
                    { 19, 3 },
                    { 19, 5 },
                    { 19, 6 },
                    { 19, 7 },
                    { 20, 1 },
                    { 20, 2 },
                    { 20, 3 },
                    { 20, 5 },
                    { 20, 6 },
                    { 20, 7 },
                    { 21, 1 },
                    { 21, 2 },
                    { 21, 3 },
                    { 21, 5 },
                    { 21, 6 },
                    { 21, 7 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 22, 1 },
                    { 22, 2 },
                    { 22, 3 },
                    { 22, 5 },
                    { 22, 6 },
                    { 22, 7 },
                    { 23, 1 },
                    { 23, 2 },
                    { 23, 3 },
                    { 23, 5 },
                    { 23, 6 },
                    { 23, 7 },
                    { 24, 1 },
                    { 24, 2 },
                    { 24, 3 },
                    { 24, 5 },
                    { 24, 6 },
                    { 24, 7 },
                    { 25, 1 },
                    { 25, 2 },
                    { 25, 3 },
                    { 25, 5 },
                    { 25, 6 },
                    { 25, 7 },
                    { 26, 1 },
                    { 26, 2 },
                    { 26, 3 },
                    { 26, 5 },
                    { 26, 6 },
                    { 26, 7 },
                    { 27, 1 },
                    { 27, 2 },
                    { 27, 3 },
                    { 27, 5 },
                    { 27, 6 },
                    { 27, 7 },
                    { 28, 1 },
                    { 28, 2 },
                    { 28, 3 },
                    { 28, 5 },
                    { 28, 6 },
                    { 28, 7 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 29, 1 },
                    { 29, 2 },
                    { 29, 3 },
                    { 29, 5 },
                    { 29, 6 },
                    { 29, 7 },
                    { 30, 1 },
                    { 30, 2 },
                    { 30, 3 },
                    { 30, 5 },
                    { 30, 6 },
                    { 30, 7 },
                    { 31, 1 },
                    { 31, 2 },
                    { 31, 3 },
                    { 31, 5 },
                    { 31, 6 },
                    { 31, 7 },
                    { 32, 1 },
                    { 32, 2 },
                    { 32, 3 },
                    { 32, 5 },
                    { 32, 6 },
                    { 32, 7 },
                    { 33, 1 },
                    { 33, 2 },
                    { 33, 3 },
                    { 33, 5 },
                    { 33, 6 },
                    { 33, 7 },
                    { 34, 1 },
                    { 34, 2 },
                    { 34, 3 },
                    { 34, 5 },
                    { 34, 6 },
                    { 34, 7 },
                    { 35, 1 },
                    { 35, 2 },
                    { 35, 3 },
                    { 35, 5 },
                    { 35, 6 },
                    { 35, 7 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 36, 1 },
                    { 36, 2 },
                    { 36, 3 },
                    { 36, 5 },
                    { 36, 6 },
                    { 36, 7 },
                    { 37, 1 },
                    { 37, 2 },
                    { 37, 3 },
                    { 37, 5 },
                    { 37, 6 },
                    { 37, 7 },
                    { 38, 1 },
                    { 38, 2 },
                    { 38, 3 },
                    { 38, 5 },
                    { 38, 6 },
                    { 38, 7 },
                    { 39, 1 },
                    { 39, 2 },
                    { 39, 3 },
                    { 39, 5 },
                    { 39, 6 },
                    { 39, 7 },
                    { 40, 1 },
                    { 40, 2 },
                    { 40, 3 },
                    { 40, 5 },
                    { 40, 6 },
                    { 40, 7 },
                    { 41, 1 },
                    { 41, 2 },
                    { 41, 3 },
                    { 41, 5 },
                    { 41, 6 },
                    { 41, 7 },
                    { 42, 1 },
                    { 42, 2 },
                    { 42, 3 },
                    { 42, 5 },
                    { 42, 6 },
                    { 42, 7 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 43, 1 },
                    { 43, 2 },
                    { 43, 3 },
                    { 43, 5 },
                    { 43, 6 },
                    { 43, 7 },
                    { 44, 1 },
                    { 44, 2 },
                    { 44, 3 },
                    { 44, 5 },
                    { 44, 6 },
                    { 44, 7 },
                    { 45, 1 },
                    { 45, 2 },
                    { 45, 3 },
                    { 45, 5 },
                    { 45, 6 },
                    { 45, 7 },
                    { 46, 1 },
                    { 46, 2 },
                    { 46, 3 },
                    { 46, 5 },
                    { 46, 6 },
                    { 46, 7 },
                    { 47, 1 },
                    { 47, 2 },
                    { 47, 3 },
                    { 47, 5 },
                    { 47, 6 },
                    { 47, 7 },
                    { 48, 1 },
                    { 48, 2 },
                    { 48, 3 },
                    { 48, 5 },
                    { 48, 6 },
                    { 48, 7 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BankInfoId", "BaseSalary", "Birthday", "CitizenId", "Email", "FaceId", "Gender", "GroupId", "InsuranceCode", "Name", "Password", "PhoneNumber", "RoleId", "SocialInsuranceId", "TaxCode", "TeamId", "TokenSlack", "TokenTrello", "UrlImage", "Username" },
                values: new object[,]
                {
                    { 1, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000001", null, null, null, null, null, "Admin User", "admin", null, 1, null, null, null, null, null, null, "admin" },
                    { 2, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000002", null, null, null, null, null, "Manager User", "manager", null, 2, null, null, null, null, null, null, "manager" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Detail", "ManagerId", "Name", "ParentDepartmentId" },
                values: new object[] { 1, "Detail for Head Department", 2, "Head Department", null });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 1 },
                    { 2, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 1 },
                    { 103, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 2 },
                    { 104, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 2 },
                    { 205, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 3 },
                    { 206, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 3 },
                    { 307, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 4 },
                    { 308, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 4 },
                    { 409, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 5 },
                    { 410, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 5 },
                    { 511, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 6 },
                    { 512, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 6 },
                    { 613, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 7 },
                    { 614, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 7 },
                    { 715, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 8 },
                    { 716, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 8 },
                    { 817, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 9 },
                    { 818, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 9 },
                    { 919, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 10 },
                    { 920, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 10 },
                    { 1021, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 11 },
                    { 1022, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 11 },
                    { 1123, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 12 },
                    { 1124, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 12 },
                    { 1225, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 13 },
                    { 1226, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 13 },
                    { 1327, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 14 },
                    { 1328, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 14 },
                    { 1429, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 15 },
                    { 1430, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 15 },
                    { 1531, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 16 },
                    { 1532, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 16 },
                    { 1633, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 17 },
                    { 1634, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 17 },
                    { 1735, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 18 },
                    { 1736, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 18 },
                    { 1837, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 19 },
                    { 1838, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 19 },
                    { 1939, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 20 },
                    { 1940, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 20 },
                    { 2041, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 21 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[] { 2042, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 21 });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[] { 2143, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null, 22 });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[] { 2144, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 2, null, 22 });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Detail", "ManagerId", "Name", "ParentDepartmentId" },
                values: new object[,]
                {
                    { 2, "Detail for department Department 2", null, "Department 2", 1 },
                    { 3, "Detail for department Department 3", null, "Department 3", 1 },
                    { 4, "Detail for department Department 4", null, "Department 4", 1 },
                    { 5, "Detail for department Department 5", null, "Department 5", 1 },
                    { 6, "Detail for department Department 6", null, "Department 6", 1 },
                    { 7, "Detail for department Department 7", null, "Department 7", 1 },
                    { 8, "Detail for department Department 8", null, "Department 8", 1 },
                    { 9, "Detail for department Department 9", null, "Department 9", 1 },
                    { 10, "Detail for department Department 10", null, "Department 10", 1 },
                    { 11, "Detail for department Department 11", null, "Department 11", 1 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "DepartmentId", "Detail", "LeaderId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "The A Team", 1, "The A Team" },
                    { 2, 1, "The B Team", 2, "The B Team" },
                    { 3, 1, "The C Team", null, "The C Team" },
                    { 5, 1, "Detail for department Team 5", null, "Team 5" },
                    { 6, 1, "Detail for department Team 6", null, "Team 6" },
                    { 7, 1, "Detail for department Team 7", null, "Team 7" },
                    { 8, 1, "Detail for department Team 8", null, "Team 8" },
                    { 9, 1, "Detail for department Team 9", null, "Team 9" },
                    { 10, 1, "Detail for department Team 10", null, "Team 10" },
                    { 11, 1, "Detail for department Team 11", null, "Team 11" },
                    { 12, 1, "Detail for department Team 12", null, "Team 12" },
                    { 13, 1, "Detail for department Team 13", null, "Team 13" },
                    { 14, 1, "Detail for department Team 14", null, "Team 14" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BankInfoId", "BaseSalary", "Birthday", "CitizenId", "Email", "FaceId", "Gender", "GroupId", "InsuranceCode", "Name", "Password", "PhoneNumber", "RoleId", "SocialInsuranceId", "TaxCode", "TeamId", "TokenSlack", "TokenTrello", "UrlImage", "Username" },
                values: new object[,]
                {
                    { 4, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0000004", null, null, null, null, null, "User 4", "password4", null, null, null, null, 1, null, null, null, "user4" },
                    { 5, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0000005", null, null, null, null, null, "User 5", "password5", null, null, null, null, 2, null, null, null, "user5" },
                    { 6, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0000006", null, null, null, null, null, "User 6", "password6", null, null, null, null, 1, null, null, null, "user6" },
                    { 7, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0000007", null, null, null, null, null, "User 7", "password7", null, null, null, null, 2, null, null, null, "user7" },
                    { 8, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0000008", null, null, null, null, null, "User 8", "password8", null, null, null, null, 1, null, null, null, "user8" },
                    { 9, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0000009", null, null, null, null, null, "User 9", "password9", null, null, null, null, 2, null, null, null, "user9" },
                    { 10, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000010", null, null, null, null, null, "User 10", "password10", null, null, null, null, 1, null, null, null, "user10" },
                    { 11, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000011", null, null, null, null, null, "User 11", "password11", null, null, null, null, 2, null, null, null, "user11" },
                    { 12, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000012", null, null, null, null, null, "User 12", "password12", null, null, null, null, 1, null, null, null, "user12" },
                    { 13, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000013", null, null, null, null, null, "User 13", "password13", null, null, null, null, 2, null, null, null, "user13" },
                    { 14, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000014", null, null, null, null, null, "User 14", "password14", null, null, null, null, 1, null, null, null, "user14" },
                    { 15, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000015", null, null, null, null, null, "User 15", "password15", null, null, null, null, 2, null, null, null, "user15" },
                    { 16, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000016", null, null, null, null, null, "User 16", "password16", null, null, null, null, 1, null, null, null, "user16" },
                    { 17, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000017", null, null, null, null, null, "User 17", "password17", null, null, null, null, 2, null, null, null, "user17" },
                    { 18, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000018", null, null, null, null, null, "User 18", "password18", null, null, null, null, 1, null, null, null, "user18" },
                    { 19, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000019", null, null, null, null, null, "User 19", "password19", null, null, null, null, 2, null, null, null, "user19" },
                    { 20, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000020", null, null, null, null, null, "User 20", "password20", null, null, null, null, 1, null, null, null, "user20" },
                    { 21, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000021", null, null, null, null, null, "User 21", "password21", null, null, null, null, 2, null, null, null, "user21" },
                    { 22, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000022", null, null, null, null, null, "User 22", "password22", null, null, null, null, 1, null, null, null, "user22" },
                    { 23, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000023", null, null, null, null, null, "User 23", "password23", null, null, null, null, 2, null, null, null, "user23" },
                    { 24, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000024", null, null, null, null, null, "User 24", "password24", null, null, null, null, 1, null, null, null, "user24" },
                    { 25, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000025", null, null, null, null, null, "User 25", "password25", null, null, null, null, 2, null, null, null, "user25" },
                    { 26, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000026", null, null, null, null, null, "User 26", "password26", null, null, null, null, 1, null, null, null, "user26" },
                    { 27, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000027", null, null, null, null, null, "User 27", "password27", null, null, null, null, 2, null, null, null, "user27" },
                    { 28, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000028", null, null, null, null, null, "User 28", "password28", null, null, null, null, 1, null, null, null, "user28" },
                    { 29, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000029", null, null, null, null, null, "User 29", "password29", null, null, null, null, 2, null, null, null, "user29" },
                    { 30, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000030", null, null, null, null, null, "User 30", "password30", null, null, null, null, 1, null, null, null, "user30" },
                    { 31, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000031", null, null, null, null, null, "User 31", "password31", null, null, null, null, 2, null, null, null, "user31" },
                    { 32, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000032", null, null, null, null, null, "User 32", "password32", null, null, null, null, 1, null, null, null, "user32" },
                    { 33, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000033", null, null, null, null, null, "User 33", "password33", null, null, null, null, 2, null, null, null, "user33" },
                    { 34, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000034", null, null, null, null, null, "User 34", "password34", null, null, null, null, 1, null, null, null, "user34" },
                    { 35, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000035", null, null, null, null, null, "User 35", "password35", null, null, null, null, 2, null, null, null, "user35" },
                    { 36, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000036", null, null, null, null, null, "User 36", "password36", null, null, null, null, 1, null, null, null, "user36" },
                    { 37, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000037", null, null, null, null, null, "User 37", "password37", null, null, null, null, 2, null, null, null, "user37" },
                    { 38, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000038", null, null, null, null, null, "User 38", "password38", null, null, null, null, 1, null, null, null, "user38" },
                    { 39, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000039", null, null, null, null, null, "User 39", "password39", null, null, null, null, 2, null, null, null, "user39" },
                    { 40, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000040", null, null, null, null, null, "User 40", "password40", null, null, null, null, 1, null, null, null, "user40" },
                    { 41, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000041", null, null, null, null, null, "User 41", "password41", null, null, null, null, 2, null, null, null, "user41" },
                    { 42, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000042", null, null, null, null, null, "User 42", "password42", null, null, null, null, 1, null, null, null, "user42" },
                    { 43, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000043", null, null, null, null, null, "User 43", "password43", null, null, null, null, 2, null, null, null, "user43" },
                    { 44, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000044", null, null, null, null, null, "User 44", "password44", null, null, null, null, 1, null, null, null, "user44" },
                    { 45, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000045", null, null, null, null, null, "User 45", "password45", null, null, null, null, 2, null, null, null, "user45" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BankInfoId", "BaseSalary", "Birthday", "CitizenId", "Email", "FaceId", "Gender", "GroupId", "InsuranceCode", "Name", "Password", "PhoneNumber", "RoleId", "SocialInsuranceId", "TaxCode", "TeamId", "TokenSlack", "TokenTrello", "UrlImage", "Username" },
                values: new object[,]
                {
                    { 46, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000046", null, null, null, null, null, "User 46", "password46", null, null, null, null, 1, null, null, null, "user46" },
                    { 47, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000047", null, null, null, null, null, "User 47", "password47", null, null, null, null, 2, null, null, null, "user47" },
                    { 48, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000048", null, null, null, null, null, "User 48", "password48", null, null, null, null, 1, null, null, null, "user48" },
                    { 49, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000049", null, null, null, null, null, "User 49", "password49", null, null, null, null, 2, null, null, null, "user49" },
                    { 50, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000050", null, null, null, null, null, "User 50", "password50", null, null, null, null, 1, null, null, null, "user50" },
                    { 51, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000051", null, null, null, null, null, "User 51", "password51", null, null, null, null, 2, null, null, null, "user51" },
                    { 52, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000052", null, null, null, null, null, "User 52", "password52", null, null, null, null, 1, null, null, null, "user52" },
                    { 53, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000053", null, null, null, null, null, "User 53", "password53", null, null, null, null, 2, null, null, null, "user53" },
                    { 54, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000054", null, null, null, null, null, "User 54", "password54", null, null, null, null, 1, null, null, null, "user54" },
                    { 55, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000055", null, null, null, null, null, "User 55", "password55", null, null, null, null, 2, null, null, null, "user55" },
                    { 56, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000056", null, null, null, null, null, "User 56", "password56", null, null, null, null, 1, null, null, null, "user56" },
                    { 57, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000057", null, null, null, null, null, "User 57", "password57", null, null, null, null, 2, null, null, null, "user57" },
                    { 58, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000058", null, null, null, null, null, "User 58", "password58", null, null, null, null, 1, null, null, null, "user58" },
                    { 59, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000059", null, null, null, null, null, "User 59", "password59", null, null, null, null, 2, null, null, null, "user59" },
                    { 60, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000060", null, null, null, null, null, "User 60", "password60", null, null, null, null, 1, null, null, null, "user60" },
                    { 61, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000061", null, null, null, null, null, "User 61", "password61", null, null, null, null, 2, null, null, null, "user61" },
                    { 62, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000062", null, null, null, null, null, "User 62", "password62", null, null, null, null, 1, null, null, null, "user62" },
                    { 63, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000063", null, null, null, null, null, "User 63", "password63", null, null, null, null, 2, null, null, null, "user63" },
                    { 64, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000064", null, null, null, null, null, "User 64", "password64", null, null, null, null, 1, null, null, null, "user64" },
                    { 65, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000065", null, null, null, null, null, "User 65", "password65", null, null, null, null, 2, null, null, null, "user65" },
                    { 66, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000066", null, null, null, null, null, "User 66", "password66", null, null, null, null, 1, null, null, null, "user66" },
                    { 67, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000067", null, null, null, null, null, "User 67", "password67", null, null, null, null, 2, null, null, null, "user67" },
                    { 68, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000068", null, null, null, null, null, "User 68", "password68", null, null, null, null, 1, null, null, null, "user68" },
                    { 69, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000069", null, null, null, null, null, "User 69", "password69", null, null, null, null, 2, null, null, null, "user69" },
                    { 70, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000070", null, null, null, null, null, "User 70", "password70", null, null, null, null, 1, null, null, null, "user70" },
                    { 71, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000071", null, null, null, null, null, "User 71", "password71", null, null, null, null, 2, null, null, null, "user71" },
                    { 72, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000072", null, null, null, null, null, "User 72", "password72", null, null, null, null, 1, null, null, null, "user72" },
                    { 73, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000073", null, null, null, null, null, "User 73", "password73", null, null, null, null, 2, null, null, null, "user73" },
                    { 74, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000074", null, null, null, null, null, "User 74", "password74", null, null, null, null, 1, null, null, null, "user74" },
                    { 75, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000075", null, null, null, null, null, "User 75", "password75", null, null, null, null, 2, null, null, null, "user75" },
                    { 76, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000076", null, null, null, null, null, "User 76", "password76", null, null, null, null, 1, null, null, null, "user76" },
                    { 77, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000077", null, null, null, null, null, "User 77", "password77", null, null, null, null, 2, null, null, null, "user77" },
                    { 78, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000078", null, null, null, null, null, "User 78", "password78", null, null, null, null, 1, null, null, null, "user78" },
                    { 79, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000079", null, null, null, null, null, "User 79", "password79", null, null, null, null, 2, null, null, null, "user79" },
                    { 80, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000080", null, null, null, null, null, "User 80", "password80", null, null, null, null, 1, null, null, null, "user80" },
                    { 81, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000081", null, null, null, null, null, "User 81", "password81", null, null, null, null, 2, null, null, null, "user81" },
                    { 82, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000082", null, null, null, null, null, "User 82", "password82", null, null, null, null, 1, null, null, null, "user82" },
                    { 83, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000083", null, null, null, null, null, "User 83", "password83", null, null, null, null, 2, null, null, null, "user83" },
                    { 84, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000084", null, null, null, null, null, "User 84", "password84", null, null, null, null, 1, null, null, null, "user84" },
                    { 85, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000085", null, null, null, null, null, "User 85", "password85", null, null, null, null, 2, null, null, null, "user85" },
                    { 86, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000086", null, null, null, null, null, "User 86", "password86", null, null, null, null, 1, null, null, null, "user86" },
                    { 87, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000087", null, null, null, null, null, "User 87", "password87", null, null, null, null, 2, null, null, null, "user87" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BankInfoId", "BaseSalary", "Birthday", "CitizenId", "Email", "FaceId", "Gender", "GroupId", "InsuranceCode", "Name", "Password", "PhoneNumber", "RoleId", "SocialInsuranceId", "TaxCode", "TeamId", "TokenSlack", "TokenTrello", "UrlImage", "Username" },
                values: new object[,]
                {
                    { 88, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000088", null, null, null, null, null, "User 88", "password88", null, null, null, null, 1, null, null, null, "user88" },
                    { 89, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000089", null, null, null, null, null, "User 89", "password89", null, null, null, null, 2, null, null, null, "user89" },
                    { 90, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000090", null, null, null, null, null, "User 90", "password90", null, null, null, null, 1, null, null, null, "user90" },
                    { 91, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000091", null, null, null, null, null, "User 91", "password91", null, null, null, null, 2, null, null, null, "user91" },
                    { 92, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000092", null, null, null, null, null, "User 92", "password92", null, null, null, null, 1, null, null, null, "user92" },
                    { 93, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000093", null, null, null, null, null, "User 93", "password93", null, null, null, null, 2, null, null, null, "user93" },
                    { 94, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000094", null, null, null, null, null, "User 94", "password94", null, null, null, null, 1, null, null, null, "user94" },
                    { 95, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000095", null, null, null, null, null, "User 95", "password95", null, null, null, null, 2, null, null, null, "user95" },
                    { 96, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000096", null, null, null, null, null, "User 96", "password96", null, null, null, null, 1, null, null, null, "user96" },
                    { 97, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000097", null, null, null, null, null, "User 97", "password97", null, null, null, null, 2, null, null, null, "user97" },
                    { 98, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000098", null, null, null, null, null, "User 98", "password98", null, null, null, null, 1, null, null, null, "user98" },
                    { 99, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000099", null, null, null, null, null, "User 99", "password99", null, null, null, null, 2, null, null, null, "user99" },
                    { 100, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000100", null, null, null, null, null, "User 100", "password100", null, null, null, null, 1, null, null, null, "user100" },
                    { 101, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000101", null, null, null, null, null, "User 101", "password101", null, null, null, null, 2, null, null, null, "user101" },
                    { 102, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000102", null, null, null, null, null, "User 102", "password102", null, null, null, null, 1, null, null, null, "user102" },
                    { 103, null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000103", null, null, null, null, null, "User 103", "password103", null, null, null, null, 2, null, null, null, "user103" }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 3, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 1 },
                    { 4, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 1 },
                    { 5, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 1 },
                    { 6, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 1 },
                    { 7, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 1 },
                    { 8, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 1 },
                    { 9, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 1 },
                    { 10, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 1 },
                    { 11, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 1 },
                    { 12, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 1 },
                    { 13, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 1 },
                    { 14, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 1 },
                    { 15, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 1 },
                    { 16, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 1 },
                    { 17, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 1 },
                    { 18, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 1 },
                    { 19, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 1 },
                    { 20, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 1 },
                    { 21, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 1 },
                    { 22, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 1 },
                    { 23, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 1 },
                    { 24, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 1 },
                    { 25, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 1 },
                    { 26, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 1 },
                    { 27, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 1 },
                    { 28, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 1 },
                    { 29, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 1 },
                    { 30, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 1 },
                    { 31, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 1 },
                    { 32, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 1 },
                    { 33, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 1 },
                    { 34, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 1 },
                    { 35, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 1 },
                    { 36, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 1 },
                    { 37, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 1 },
                    { 38, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 1 },
                    { 39, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 1 },
                    { 40, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 1 },
                    { 41, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 1 },
                    { 42, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 1 },
                    { 43, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 1 },
                    { 44, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 45, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 1 },
                    { 46, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 1 },
                    { 47, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 1 },
                    { 48, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 1 },
                    { 49, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 1 },
                    { 50, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 1 },
                    { 51, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 1 },
                    { 52, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 1 },
                    { 53, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 1 },
                    { 54, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 1 },
                    { 55, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 1 },
                    { 56, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 1 },
                    { 57, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 1 },
                    { 58, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 1 },
                    { 59, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 1 },
                    { 60, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 1 },
                    { 61, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 1 },
                    { 62, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 1 },
                    { 63, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 1 },
                    { 64, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 1 },
                    { 65, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 1 },
                    { 66, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 1 },
                    { 67, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 1 },
                    { 68, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 1 },
                    { 69, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 1 },
                    { 70, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 1 },
                    { 71, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 1 },
                    { 72, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 1 },
                    { 73, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 1 },
                    { 74, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 1 },
                    { 75, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 1 },
                    { 76, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 1 },
                    { 77, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 1 },
                    { 78, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 1 },
                    { 79, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 1 },
                    { 80, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 1 },
                    { 81, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 1 },
                    { 82, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 1 },
                    { 83, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 1 },
                    { 84, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 1 },
                    { 85, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 1 },
                    { 86, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 87, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 1 },
                    { 88, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 1 },
                    { 89, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 1 },
                    { 90, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 1 },
                    { 91, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 1 },
                    { 92, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 1 },
                    { 93, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 1 },
                    { 94, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 1 },
                    { 95, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 1 },
                    { 96, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 1 },
                    { 97, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 1 },
                    { 98, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 1 },
                    { 99, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 1 },
                    { 100, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 1 },
                    { 101, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 1 },
                    { 102, new DateTime(2022, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 1 },
                    { 105, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 2 },
                    { 106, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 2 },
                    { 107, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 2 },
                    { 108, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 2 },
                    { 109, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 2 },
                    { 110, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 2 },
                    { 111, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 2 },
                    { 112, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 2 },
                    { 113, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 2 },
                    { 114, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 2 },
                    { 115, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 2 },
                    { 116, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 2 },
                    { 117, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 2 },
                    { 118, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 2 },
                    { 119, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 2 },
                    { 120, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 2 },
                    { 121, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 2 },
                    { 122, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 2 },
                    { 123, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 2 },
                    { 124, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 2 },
                    { 125, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 2 },
                    { 126, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 2 },
                    { 127, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 2 },
                    { 128, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 2 },
                    { 129, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 2 },
                    { 130, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 131, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 2 },
                    { 132, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 2 },
                    { 133, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 2 },
                    { 134, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 2 },
                    { 135, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 2 },
                    { 136, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 2 },
                    { 137, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 2 },
                    { 138, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 2 },
                    { 139, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 2 },
                    { 140, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 2 },
                    { 141, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 2 },
                    { 142, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 2 },
                    { 143, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 2 },
                    { 144, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 2 },
                    { 145, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 2 },
                    { 146, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 2 },
                    { 147, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 2 },
                    { 148, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 2 },
                    { 149, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 2 },
                    { 150, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 2 },
                    { 151, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 2 },
                    { 152, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 2 },
                    { 153, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 2 },
                    { 154, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 2 },
                    { 155, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 2 },
                    { 156, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 2 },
                    { 157, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 2 },
                    { 158, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 2 },
                    { 159, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 2 },
                    { 160, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 2 },
                    { 161, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 2 },
                    { 162, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 2 },
                    { 163, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 2 },
                    { 164, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 2 },
                    { 165, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 2 },
                    { 166, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 2 },
                    { 167, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 2 },
                    { 168, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 2 },
                    { 169, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 2 },
                    { 170, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 2 },
                    { 171, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 2 },
                    { 172, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 173, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 2 },
                    { 174, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 2 },
                    { 175, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 2 },
                    { 176, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 2 },
                    { 177, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 2 },
                    { 178, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 2 },
                    { 179, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 2 },
                    { 180, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 2 },
                    { 181, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 2 },
                    { 182, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 2 },
                    { 183, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 2 },
                    { 184, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 2 },
                    { 185, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 2 },
                    { 186, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 2 },
                    { 187, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 2 },
                    { 188, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 2 },
                    { 189, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 2 },
                    { 190, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 2 },
                    { 191, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 2 },
                    { 192, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 2 },
                    { 193, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 2 },
                    { 194, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 2 },
                    { 195, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 2 },
                    { 196, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 2 },
                    { 197, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 2 },
                    { 198, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 2 },
                    { 199, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 2 },
                    { 200, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 2 },
                    { 201, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 2 },
                    { 202, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 2 },
                    { 203, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 2 },
                    { 204, new DateTime(2022, 9, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 2 },
                    { 207, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 3 },
                    { 208, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 3 },
                    { 209, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 3 },
                    { 210, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 3 },
                    { 211, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 3 },
                    { 212, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 3 },
                    { 213, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 3 },
                    { 214, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 3 },
                    { 215, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 3 },
                    { 216, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 217, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 3 },
                    { 218, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 3 },
                    { 219, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 3 },
                    { 220, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 3 },
                    { 221, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 3 },
                    { 222, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 3 },
                    { 223, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 3 },
                    { 224, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 3 },
                    { 225, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 3 },
                    { 226, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 3 },
                    { 227, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 3 },
                    { 228, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 3 },
                    { 229, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 3 },
                    { 230, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 3 },
                    { 231, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 3 },
                    { 232, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 3 },
                    { 233, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 3 },
                    { 234, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 3 },
                    { 235, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 3 },
                    { 236, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 3 },
                    { 237, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 3 },
                    { 238, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 3 },
                    { 239, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 3 },
                    { 240, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 3 },
                    { 241, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 3 },
                    { 242, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 3 },
                    { 243, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 3 },
                    { 244, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 3 },
                    { 245, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 3 },
                    { 246, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 3 },
                    { 247, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 3 },
                    { 248, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 3 },
                    { 249, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 3 },
                    { 250, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 3 },
                    { 251, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 3 },
                    { 252, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 3 },
                    { 253, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 3 },
                    { 254, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 3 },
                    { 255, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 3 },
                    { 256, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 3 },
                    { 257, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 3 },
                    { 258, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 259, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 3 },
                    { 260, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 3 },
                    { 261, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 3 },
                    { 262, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 3 },
                    { 263, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 3 },
                    { 264, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 3 },
                    { 265, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 3 },
                    { 266, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 3 },
                    { 267, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 3 },
                    { 268, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 3 },
                    { 269, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 3 },
                    { 270, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 3 },
                    { 271, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 3 },
                    { 272, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 3 },
                    { 273, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 3 },
                    { 274, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 3 },
                    { 275, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 3 },
                    { 276, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 3 },
                    { 277, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 3 },
                    { 278, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 3 },
                    { 279, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 3 },
                    { 280, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 3 },
                    { 281, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 3 },
                    { 282, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 3 },
                    { 283, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 3 },
                    { 284, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 3 },
                    { 285, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 3 },
                    { 286, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 3 },
                    { 287, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 3 },
                    { 288, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 3 },
                    { 289, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 3 },
                    { 290, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 3 },
                    { 291, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 3 },
                    { 292, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 3 },
                    { 293, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 3 },
                    { 294, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 3 },
                    { 295, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 3 },
                    { 296, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 3 },
                    { 297, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 3 },
                    { 298, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 3 },
                    { 299, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 3 },
                    { 300, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 301, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 3 },
                    { 302, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 3 },
                    { 303, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 3 },
                    { 304, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 3 },
                    { 305, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 3 },
                    { 306, new DateTime(2022, 9, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 3 },
                    { 309, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 4 },
                    { 310, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 4 },
                    { 311, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 4 },
                    { 312, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 4 },
                    { 313, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 4 },
                    { 314, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 4 },
                    { 315, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 4 },
                    { 316, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 4 },
                    { 317, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 4 },
                    { 318, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 4 },
                    { 319, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 4 },
                    { 320, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 4 },
                    { 321, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 4 },
                    { 322, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 4 },
                    { 323, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 4 },
                    { 324, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 4 },
                    { 325, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 4 },
                    { 326, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 4 },
                    { 327, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 4 },
                    { 328, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 4 },
                    { 329, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 4 },
                    { 330, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 4 },
                    { 331, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 4 },
                    { 332, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 4 },
                    { 333, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 4 },
                    { 334, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 4 },
                    { 335, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 4 },
                    { 336, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 4 },
                    { 337, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 4 },
                    { 338, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 4 },
                    { 339, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 4 },
                    { 340, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 4 },
                    { 341, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 4 },
                    { 342, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 4 },
                    { 343, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 4 },
                    { 344, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 345, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 4 },
                    { 346, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 4 },
                    { 347, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 4 },
                    { 348, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 4 },
                    { 349, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 4 },
                    { 350, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 4 },
                    { 351, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 4 },
                    { 352, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 4 },
                    { 353, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 4 },
                    { 354, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 4 },
                    { 355, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 4 },
                    { 356, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 4 },
                    { 357, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 4 },
                    { 358, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 4 },
                    { 359, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 4 },
                    { 360, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 4 },
                    { 361, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 4 },
                    { 362, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 4 },
                    { 363, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 4 },
                    { 364, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 4 },
                    { 365, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 4 },
                    { 366, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 4 },
                    { 367, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 4 },
                    { 368, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 4 },
                    { 369, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 4 },
                    { 370, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 4 },
                    { 371, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 4 },
                    { 372, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 4 },
                    { 373, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 4 },
                    { 374, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 4 },
                    { 375, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 4 },
                    { 376, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 4 },
                    { 377, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 4 },
                    { 378, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 4 },
                    { 379, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 4 },
                    { 380, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 4 },
                    { 381, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 4 },
                    { 382, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 4 },
                    { 383, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 4 },
                    { 384, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 4 },
                    { 385, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 4 },
                    { 386, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 387, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 4 },
                    { 388, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 4 },
                    { 389, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 4 },
                    { 390, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 4 },
                    { 391, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 4 },
                    { 392, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 4 },
                    { 393, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 4 },
                    { 394, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 4 },
                    { 395, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 4 },
                    { 396, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 4 },
                    { 397, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 4 },
                    { 398, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 4 },
                    { 399, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 4 },
                    { 400, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 4 },
                    { 401, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 4 },
                    { 402, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 4 },
                    { 403, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 4 },
                    { 404, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 4 },
                    { 405, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 4 },
                    { 406, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 4 },
                    { 407, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 4 },
                    { 408, new DateTime(2022, 9, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 4 },
                    { 411, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 5 },
                    { 412, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 5 },
                    { 413, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 5 },
                    { 414, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 5 },
                    { 415, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 5 },
                    { 416, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 5 },
                    { 417, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 5 },
                    { 418, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 5 },
                    { 419, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 5 },
                    { 420, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 5 },
                    { 421, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 5 },
                    { 422, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 5 },
                    { 423, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 5 },
                    { 424, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 5 },
                    { 425, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 5 },
                    { 426, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 5 },
                    { 427, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 5 },
                    { 428, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 5 },
                    { 429, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 5 },
                    { 430, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 431, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 5 },
                    { 432, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 5 },
                    { 433, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 5 },
                    { 434, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 5 },
                    { 435, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 5 },
                    { 436, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 5 },
                    { 437, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 5 },
                    { 438, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 5 },
                    { 439, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 5 },
                    { 440, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 5 },
                    { 441, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 5 },
                    { 442, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 5 },
                    { 443, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 5 },
                    { 444, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 5 },
                    { 445, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 5 },
                    { 446, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 5 },
                    { 447, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 5 },
                    { 448, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 5 },
                    { 449, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 5 },
                    { 450, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 5 },
                    { 451, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 5 },
                    { 452, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 5 },
                    { 453, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 5 },
                    { 454, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 5 },
                    { 455, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 5 },
                    { 456, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 5 },
                    { 457, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 5 },
                    { 458, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 5 },
                    { 459, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 5 },
                    { 460, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 5 },
                    { 461, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 5 },
                    { 462, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 5 },
                    { 463, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 5 },
                    { 464, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 5 },
                    { 465, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 5 },
                    { 466, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 5 },
                    { 467, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 5 },
                    { 468, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 5 },
                    { 469, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 5 },
                    { 470, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 5 },
                    { 471, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 5 },
                    { 472, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 473, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 5 },
                    { 474, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 5 },
                    { 475, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 5 },
                    { 476, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 5 },
                    { 477, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 5 },
                    { 478, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 5 },
                    { 479, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 5 },
                    { 480, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 5 },
                    { 481, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 5 },
                    { 482, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 5 },
                    { 483, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 5 },
                    { 484, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 5 },
                    { 485, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 5 },
                    { 486, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 5 },
                    { 487, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 5 },
                    { 488, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 5 },
                    { 489, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 5 },
                    { 490, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 5 },
                    { 491, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 5 },
                    { 492, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 5 },
                    { 493, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 5 },
                    { 494, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 5 },
                    { 495, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 5 },
                    { 496, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 5 },
                    { 497, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 5 },
                    { 498, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 5 },
                    { 499, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 5 },
                    { 500, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 5 },
                    { 501, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 5 },
                    { 502, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 5 },
                    { 503, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 5 },
                    { 504, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 5 },
                    { 505, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 5 },
                    { 506, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 5 },
                    { 507, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 5 },
                    { 508, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 5 },
                    { 509, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 5 },
                    { 510, new DateTime(2022, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 5 },
                    { 513, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 6 },
                    { 514, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 6 },
                    { 515, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 6 },
                    { 516, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 6 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 517, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 6 },
                    { 518, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 6 },
                    { 519, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 6 },
                    { 520, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 6 },
                    { 521, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 6 },
                    { 522, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 6 },
                    { 523, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 6 },
                    { 524, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 6 },
                    { 525, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 6 },
                    { 526, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 6 },
                    { 527, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 6 },
                    { 528, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 6 },
                    { 529, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 6 },
                    { 530, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 6 },
                    { 531, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 6 },
                    { 532, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 6 },
                    { 533, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 6 },
                    { 534, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 6 },
                    { 535, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 6 },
                    { 536, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 6 },
                    { 537, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 6 },
                    { 538, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 6 },
                    { 539, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 6 },
                    { 540, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 6 },
                    { 541, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 6 },
                    { 542, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 6 },
                    { 543, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 6 },
                    { 544, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 6 },
                    { 545, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 6 },
                    { 546, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 6 },
                    { 547, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 6 },
                    { 548, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 6 },
                    { 549, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 6 },
                    { 550, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 6 },
                    { 551, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 6 },
                    { 552, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 6 },
                    { 553, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 6 },
                    { 554, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 6 },
                    { 555, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 6 },
                    { 556, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 6 },
                    { 557, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 6 },
                    { 558, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 6 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 559, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 6 },
                    { 560, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 6 },
                    { 561, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 6 },
                    { 562, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 6 },
                    { 563, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 6 },
                    { 564, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 6 },
                    { 565, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 6 },
                    { 566, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 6 },
                    { 567, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 6 },
                    { 568, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 6 },
                    { 569, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 6 },
                    { 570, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 6 },
                    { 571, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 6 },
                    { 572, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 6 },
                    { 573, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 6 },
                    { 574, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 6 },
                    { 575, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 6 },
                    { 576, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 6 },
                    { 577, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 6 },
                    { 578, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 6 },
                    { 579, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 6 },
                    { 580, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 6 },
                    { 581, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 6 },
                    { 582, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 6 },
                    { 583, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 6 },
                    { 584, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 6 },
                    { 585, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 6 },
                    { 586, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 6 },
                    { 587, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 6 },
                    { 588, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 6 },
                    { 589, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 6 },
                    { 590, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 6 },
                    { 591, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 6 },
                    { 592, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 6 },
                    { 593, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 6 },
                    { 594, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 6 },
                    { 595, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 6 },
                    { 596, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 6 },
                    { 597, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 6 },
                    { 598, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 6 },
                    { 599, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 6 },
                    { 600, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 6 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 601, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 6 },
                    { 602, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 6 },
                    { 603, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 6 },
                    { 604, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 6 },
                    { 605, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 6 },
                    { 606, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 6 },
                    { 607, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 6 },
                    { 608, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 6 },
                    { 609, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 6 },
                    { 610, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 6 },
                    { 611, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 6 },
                    { 612, new DateTime(2022, 9, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 6 },
                    { 615, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 7 },
                    { 616, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 7 },
                    { 617, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 7 },
                    { 618, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 7 },
                    { 619, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 7 },
                    { 620, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 7 },
                    { 621, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 7 },
                    { 622, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 7 },
                    { 623, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 7 },
                    { 624, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 7 },
                    { 625, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 7 },
                    { 626, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 7 },
                    { 627, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 7 },
                    { 628, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 7 },
                    { 629, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 7 },
                    { 630, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 7 },
                    { 631, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 7 },
                    { 632, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 7 },
                    { 633, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 7 },
                    { 634, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 7 },
                    { 635, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 7 },
                    { 636, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 7 },
                    { 637, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 7 },
                    { 638, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 7 },
                    { 639, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 7 },
                    { 640, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 7 },
                    { 641, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 7 },
                    { 642, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 7 },
                    { 643, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 7 },
                    { 644, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 7 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 645, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 7 },
                    { 646, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 7 },
                    { 647, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 7 },
                    { 648, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 7 },
                    { 649, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 7 },
                    { 650, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 7 },
                    { 651, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 7 },
                    { 652, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 7 },
                    { 653, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 7 },
                    { 654, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 7 },
                    { 655, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 7 },
                    { 656, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 7 },
                    { 657, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 7 },
                    { 658, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 7 },
                    { 659, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 7 },
                    { 660, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 7 },
                    { 661, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 7 },
                    { 662, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 7 },
                    { 663, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 7 },
                    { 664, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 7 },
                    { 665, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 7 },
                    { 666, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 7 },
                    { 667, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 7 },
                    { 668, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 7 },
                    { 669, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 7 },
                    { 670, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 7 },
                    { 671, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 7 },
                    { 672, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 7 },
                    { 673, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 7 },
                    { 674, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 7 },
                    { 675, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 7 },
                    { 676, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 7 },
                    { 677, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 7 },
                    { 678, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 7 },
                    { 679, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 7 },
                    { 680, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 7 },
                    { 681, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 7 },
                    { 682, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 7 },
                    { 683, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 7 },
                    { 684, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 7 },
                    { 685, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 7 },
                    { 686, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 7 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 687, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 7 },
                    { 688, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 7 },
                    { 689, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 7 },
                    { 690, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 7 },
                    { 691, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 7 },
                    { 692, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 7 },
                    { 693, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 7 },
                    { 694, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 7 },
                    { 695, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 7 },
                    { 696, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 7 },
                    { 697, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 7 },
                    { 698, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 7 },
                    { 699, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 7 },
                    { 700, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 7 },
                    { 701, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 7 },
                    { 702, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 7 },
                    { 703, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 7 },
                    { 704, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 7 },
                    { 705, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 7 },
                    { 706, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 7 },
                    { 707, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 7 },
                    { 708, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 7 },
                    { 709, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 7 },
                    { 710, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 7 },
                    { 711, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 7 },
                    { 712, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 7 },
                    { 713, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 7 },
                    { 714, new DateTime(2022, 9, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 7 },
                    { 717, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 8 },
                    { 718, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 8 },
                    { 719, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 8 },
                    { 720, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 8 },
                    { 721, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 8 },
                    { 722, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 8 },
                    { 723, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 8 },
                    { 724, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 8 },
                    { 725, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 8 },
                    { 726, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 8 },
                    { 727, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 8 },
                    { 728, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 8 },
                    { 729, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 8 },
                    { 730, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 8 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 731, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 8 },
                    { 732, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 8 },
                    { 733, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 8 },
                    { 734, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 8 },
                    { 735, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 8 },
                    { 736, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 8 },
                    { 737, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 8 },
                    { 738, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 8 },
                    { 739, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 8 },
                    { 740, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 8 },
                    { 741, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 8 },
                    { 742, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 8 },
                    { 743, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 8 },
                    { 744, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 8 },
                    { 745, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 8 },
                    { 746, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 8 },
                    { 747, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 8 },
                    { 748, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 8 },
                    { 749, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 8 },
                    { 750, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 8 },
                    { 751, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 8 },
                    { 752, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 8 },
                    { 753, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 8 },
                    { 754, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 8 },
                    { 755, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 8 },
                    { 756, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 8 },
                    { 757, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 8 },
                    { 758, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 8 },
                    { 759, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 8 },
                    { 760, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 8 },
                    { 761, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 8 },
                    { 762, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 8 },
                    { 763, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 8 },
                    { 764, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 8 },
                    { 765, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 8 },
                    { 766, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 8 },
                    { 767, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 8 },
                    { 768, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 8 },
                    { 769, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 8 },
                    { 770, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 8 },
                    { 771, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 8 },
                    { 772, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 8 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 773, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 8 },
                    { 774, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 8 },
                    { 775, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 8 },
                    { 776, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 8 },
                    { 777, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 8 },
                    { 778, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 8 },
                    { 779, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 8 },
                    { 780, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 8 },
                    { 781, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 8 },
                    { 782, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 8 },
                    { 783, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 8 },
                    { 784, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 8 },
                    { 785, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 8 },
                    { 786, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 8 },
                    { 787, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 8 },
                    { 788, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 8 },
                    { 789, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 8 },
                    { 790, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 8 },
                    { 791, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 8 },
                    { 792, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 8 },
                    { 793, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 8 },
                    { 794, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 8 },
                    { 795, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 8 },
                    { 796, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 8 },
                    { 797, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 8 },
                    { 798, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 8 },
                    { 799, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 8 },
                    { 800, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 8 },
                    { 801, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 8 },
                    { 802, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 8 },
                    { 803, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 8 },
                    { 804, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 8 },
                    { 805, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 8 },
                    { 806, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 8 },
                    { 807, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 8 },
                    { 808, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 8 },
                    { 809, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 8 },
                    { 810, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 8 },
                    { 811, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 8 },
                    { 812, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 8 },
                    { 813, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 8 },
                    { 814, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 8 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 815, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 8 },
                    { 816, new DateTime(2022, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 8 },
                    { 819, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 9 },
                    { 820, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 9 },
                    { 821, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 9 },
                    { 822, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 9 },
                    { 823, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 9 },
                    { 824, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 9 },
                    { 825, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 9 },
                    { 826, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 9 },
                    { 827, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 9 },
                    { 828, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 9 },
                    { 829, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 9 },
                    { 830, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 9 },
                    { 831, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 9 },
                    { 832, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 9 },
                    { 833, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 9 },
                    { 834, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 9 },
                    { 835, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 9 },
                    { 836, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 9 },
                    { 837, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 9 },
                    { 838, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 9 },
                    { 839, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 9 },
                    { 840, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 9 },
                    { 841, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 9 },
                    { 842, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 9 },
                    { 843, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 9 },
                    { 844, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 9 },
                    { 845, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 9 },
                    { 846, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 9 },
                    { 847, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 9 },
                    { 848, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 9 },
                    { 849, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 9 },
                    { 850, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 9 },
                    { 851, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 9 },
                    { 852, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 9 },
                    { 853, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 9 },
                    { 854, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 9 },
                    { 855, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 9 },
                    { 856, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 9 },
                    { 857, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 9 },
                    { 858, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 9 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 859, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 9 },
                    { 860, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 9 },
                    { 861, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 9 },
                    { 862, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 9 },
                    { 863, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 9 },
                    { 864, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 9 },
                    { 865, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 9 },
                    { 866, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 9 },
                    { 867, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 9 },
                    { 868, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 9 },
                    { 869, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 9 },
                    { 870, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 9 },
                    { 871, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 9 },
                    { 872, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 9 },
                    { 873, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 9 },
                    { 874, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 9 },
                    { 875, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 9 },
                    { 876, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 9 },
                    { 877, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 9 },
                    { 878, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 9 },
                    { 879, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 9 },
                    { 880, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 9 },
                    { 881, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 9 },
                    { 882, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 9 },
                    { 883, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 9 },
                    { 884, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 9 },
                    { 885, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 9 },
                    { 886, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 9 },
                    { 887, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 9 },
                    { 888, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 9 },
                    { 889, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 9 },
                    { 890, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 9 },
                    { 891, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 9 },
                    { 892, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 9 },
                    { 893, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 9 },
                    { 894, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 9 },
                    { 895, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 9 },
                    { 896, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 9 },
                    { 897, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 9 },
                    { 898, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 9 },
                    { 899, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 9 },
                    { 900, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 9 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 901, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 9 },
                    { 902, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 9 },
                    { 903, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 9 },
                    { 904, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 9 },
                    { 905, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 9 },
                    { 906, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 9 },
                    { 907, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 9 },
                    { 908, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 9 },
                    { 909, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 9 },
                    { 910, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 9 },
                    { 911, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 9 },
                    { 912, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 9 },
                    { 913, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 9 },
                    { 914, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 9 },
                    { 915, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 9 },
                    { 916, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 9 },
                    { 917, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 9 },
                    { 918, new DateTime(2022, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 9 },
                    { 921, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 10 },
                    { 922, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 10 },
                    { 923, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 10 },
                    { 924, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 10 },
                    { 925, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 10 },
                    { 926, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 10 },
                    { 927, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 10 },
                    { 928, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 10 },
                    { 929, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 10 },
                    { 930, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 10 },
                    { 931, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 10 },
                    { 932, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 10 },
                    { 933, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 10 },
                    { 934, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 10 },
                    { 935, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 10 },
                    { 936, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 10 },
                    { 937, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 10 },
                    { 938, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 10 },
                    { 939, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 10 },
                    { 940, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 10 },
                    { 941, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 10 },
                    { 942, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 10 },
                    { 943, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 10 },
                    { 944, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 10 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 945, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 10 },
                    { 946, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 10 },
                    { 947, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 10 },
                    { 948, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 10 },
                    { 949, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 10 },
                    { 950, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 10 },
                    { 951, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 10 },
                    { 952, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 10 },
                    { 953, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 10 },
                    { 954, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 10 },
                    { 955, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 10 },
                    { 956, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 10 },
                    { 957, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 10 },
                    { 958, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 10 },
                    { 959, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 10 },
                    { 960, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 10 },
                    { 961, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 10 },
                    { 962, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 10 },
                    { 963, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 10 },
                    { 964, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 10 },
                    { 965, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 10 },
                    { 966, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 10 },
                    { 967, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 10 },
                    { 968, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 10 },
                    { 969, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 10 },
                    { 970, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 10 },
                    { 971, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 10 },
                    { 972, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 10 },
                    { 973, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 10 },
                    { 974, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 10 },
                    { 975, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 10 },
                    { 976, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 10 },
                    { 977, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 10 },
                    { 978, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 10 },
                    { 979, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 10 },
                    { 980, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 10 },
                    { 981, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 10 },
                    { 982, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 10 },
                    { 983, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 10 },
                    { 984, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 10 },
                    { 985, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 10 },
                    { 986, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 10 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 987, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 10 },
                    { 988, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 10 },
                    { 989, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 10 },
                    { 990, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 10 },
                    { 991, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 10 },
                    { 992, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 10 },
                    { 993, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 10 },
                    { 994, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 10 },
                    { 995, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 10 },
                    { 996, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 10 },
                    { 997, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 10 },
                    { 998, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 10 },
                    { 999, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 10 },
                    { 1000, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 10 },
                    { 1001, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 10 },
                    { 1002, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 10 },
                    { 1003, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 10 },
                    { 1004, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 10 },
                    { 1005, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 10 },
                    { 1006, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 10 },
                    { 1007, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 10 },
                    { 1008, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 10 },
                    { 1009, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 10 },
                    { 1010, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 10 },
                    { 1011, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 10 },
                    { 1012, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 10 },
                    { 1013, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 10 },
                    { 1014, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 10 },
                    { 1015, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 10 },
                    { 1016, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 10 },
                    { 1017, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 10 },
                    { 1018, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 10 },
                    { 1019, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 10 },
                    { 1020, new DateTime(2022, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 10 },
                    { 1023, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 11 },
                    { 1024, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 11 },
                    { 1025, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 11 },
                    { 1026, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 11 },
                    { 1027, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 11 },
                    { 1028, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 11 },
                    { 1029, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 11 },
                    { 1030, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 11 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1031, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 11 },
                    { 1032, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 11 },
                    { 1033, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 11 },
                    { 1034, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 11 },
                    { 1035, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 11 },
                    { 1036, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 11 },
                    { 1037, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 11 },
                    { 1038, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 11 },
                    { 1039, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 11 },
                    { 1040, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 11 },
                    { 1041, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 11 },
                    { 1042, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 11 },
                    { 1043, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 11 },
                    { 1044, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 11 },
                    { 1045, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 11 },
                    { 1046, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 11 },
                    { 1047, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 11 },
                    { 1048, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 11 },
                    { 1049, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 11 },
                    { 1050, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 11 },
                    { 1051, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 11 },
                    { 1052, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 11 },
                    { 1053, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 11 },
                    { 1054, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 11 },
                    { 1055, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 11 },
                    { 1056, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 11 },
                    { 1057, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 11 },
                    { 1058, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 11 },
                    { 1059, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 11 },
                    { 1060, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 11 },
                    { 1061, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 11 },
                    { 1062, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 11 },
                    { 1063, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 11 },
                    { 1064, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 11 },
                    { 1065, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 11 },
                    { 1066, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 11 },
                    { 1067, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 11 },
                    { 1068, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 11 },
                    { 1069, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 11 },
                    { 1070, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 11 },
                    { 1071, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 11 },
                    { 1072, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 11 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1073, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 11 },
                    { 1074, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 11 },
                    { 1075, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 11 },
                    { 1076, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 11 },
                    { 1077, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 11 },
                    { 1078, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 11 },
                    { 1079, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 11 },
                    { 1080, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 11 },
                    { 1081, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 11 },
                    { 1082, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 11 },
                    { 1083, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 11 },
                    { 1084, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 11 },
                    { 1085, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 11 },
                    { 1086, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 11 },
                    { 1087, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 11 },
                    { 1088, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 11 },
                    { 1089, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 11 },
                    { 1090, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 11 },
                    { 1091, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 11 },
                    { 1092, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 11 },
                    { 1093, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 11 },
                    { 1094, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 11 },
                    { 1095, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 11 },
                    { 1096, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 11 },
                    { 1097, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 11 },
                    { 1098, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 11 },
                    { 1099, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 11 },
                    { 1100, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 11 },
                    { 1101, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 11 },
                    { 1102, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 11 },
                    { 1103, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 11 },
                    { 1104, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 11 },
                    { 1105, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 11 },
                    { 1106, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 11 },
                    { 1107, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 11 },
                    { 1108, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 11 },
                    { 1109, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 11 },
                    { 1110, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 11 },
                    { 1111, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 11 },
                    { 1112, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 11 },
                    { 1113, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 11 },
                    { 1114, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 11 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1115, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 11 },
                    { 1116, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 11 },
                    { 1117, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 11 },
                    { 1118, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 11 },
                    { 1119, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 11 },
                    { 1120, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 11 },
                    { 1121, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 11 },
                    { 1122, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 11 },
                    { 1125, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 12 },
                    { 1126, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 12 },
                    { 1127, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 12 },
                    { 1128, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 12 },
                    { 1129, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 12 },
                    { 1130, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 12 },
                    { 1131, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 12 },
                    { 1132, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 12 },
                    { 1133, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 12 },
                    { 1134, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 12 },
                    { 1135, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 12 },
                    { 1136, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 12 },
                    { 1137, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 12 },
                    { 1138, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 12 },
                    { 1139, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 12 },
                    { 1140, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 12 },
                    { 1141, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 12 },
                    { 1142, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 12 },
                    { 1143, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 12 },
                    { 1144, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 12 },
                    { 1145, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 12 },
                    { 1146, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 12 },
                    { 1147, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 12 },
                    { 1148, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 12 },
                    { 1149, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 12 },
                    { 1150, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 12 },
                    { 1151, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 12 },
                    { 1152, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 12 },
                    { 1153, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 12 },
                    { 1154, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 12 },
                    { 1155, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 12 },
                    { 1156, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 12 },
                    { 1157, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 12 },
                    { 1158, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 12 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1159, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 12 },
                    { 1160, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 12 },
                    { 1161, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 12 },
                    { 1162, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 12 },
                    { 1163, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 12 },
                    { 1164, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 12 },
                    { 1165, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 12 },
                    { 1166, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 12 },
                    { 1167, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 12 },
                    { 1168, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 12 },
                    { 1169, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 12 },
                    { 1170, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 12 },
                    { 1171, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 12 },
                    { 1172, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 12 },
                    { 1173, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 12 },
                    { 1174, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 12 },
                    { 1175, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 12 },
                    { 1176, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 12 },
                    { 1177, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 12 },
                    { 1178, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 12 },
                    { 1179, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 12 },
                    { 1180, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 12 },
                    { 1181, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 12 },
                    { 1182, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 12 },
                    { 1183, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 12 },
                    { 1184, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 12 },
                    { 1185, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 12 },
                    { 1186, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 12 },
                    { 1187, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 12 },
                    { 1188, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 12 },
                    { 1189, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 12 },
                    { 1190, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 12 },
                    { 1191, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 12 },
                    { 1192, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 12 },
                    { 1193, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 12 },
                    { 1194, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 12 },
                    { 1195, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 12 },
                    { 1196, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 12 },
                    { 1197, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 12 },
                    { 1198, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 12 },
                    { 1199, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 12 },
                    { 1200, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 12 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1201, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 12 },
                    { 1202, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 12 },
                    { 1203, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 12 },
                    { 1204, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 12 },
                    { 1205, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 12 },
                    { 1206, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 12 },
                    { 1207, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 12 },
                    { 1208, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 12 },
                    { 1209, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 12 },
                    { 1210, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 12 },
                    { 1211, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 12 },
                    { 1212, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 12 },
                    { 1213, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 12 },
                    { 1214, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 12 },
                    { 1215, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 12 },
                    { 1216, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 12 },
                    { 1217, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 12 },
                    { 1218, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 12 },
                    { 1219, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 12 },
                    { 1220, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 12 },
                    { 1221, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 12 },
                    { 1222, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 12 },
                    { 1223, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 12 },
                    { 1224, new DateTime(2022, 9, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 12 },
                    { 1227, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 13 },
                    { 1228, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 13 },
                    { 1229, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 13 },
                    { 1230, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 13 },
                    { 1231, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 13 },
                    { 1232, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 13 },
                    { 1233, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 13 },
                    { 1234, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 13 },
                    { 1235, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 13 },
                    { 1236, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 13 },
                    { 1237, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 13 },
                    { 1238, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 13 },
                    { 1239, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 13 },
                    { 1240, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 13 },
                    { 1241, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 13 },
                    { 1242, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 13 },
                    { 1243, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 13 },
                    { 1244, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 13 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1245, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 13 },
                    { 1246, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 13 },
                    { 1247, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 13 },
                    { 1248, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 13 },
                    { 1249, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 13 },
                    { 1250, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 13 },
                    { 1251, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 13 },
                    { 1252, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 13 },
                    { 1253, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 13 },
                    { 1254, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 13 },
                    { 1255, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 13 },
                    { 1256, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 13 },
                    { 1257, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 13 },
                    { 1258, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 13 },
                    { 1259, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 13 },
                    { 1260, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 13 },
                    { 1261, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 13 },
                    { 1262, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 13 },
                    { 1263, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 13 },
                    { 1264, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 13 },
                    { 1265, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 13 },
                    { 1266, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 13 },
                    { 1267, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 13 },
                    { 1268, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 13 },
                    { 1269, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 13 },
                    { 1270, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 13 },
                    { 1271, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 13 },
                    { 1272, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 13 },
                    { 1273, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 13 },
                    { 1274, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 13 },
                    { 1275, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 13 },
                    { 1276, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 13 },
                    { 1277, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 13 },
                    { 1278, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 13 },
                    { 1279, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 13 },
                    { 1280, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 13 },
                    { 1281, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 13 },
                    { 1282, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 13 },
                    { 1283, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 13 },
                    { 1284, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 13 },
                    { 1285, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 13 },
                    { 1286, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 13 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1287, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 13 },
                    { 1288, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 13 },
                    { 1289, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 13 },
                    { 1290, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 13 },
                    { 1291, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 13 },
                    { 1292, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 13 },
                    { 1293, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 13 },
                    { 1294, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 13 },
                    { 1295, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 13 },
                    { 1296, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 13 },
                    { 1297, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 13 },
                    { 1298, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 13 },
                    { 1299, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 13 },
                    { 1300, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 13 },
                    { 1301, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 13 },
                    { 1302, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 13 },
                    { 1303, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 13 },
                    { 1304, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 13 },
                    { 1305, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 13 },
                    { 1306, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 13 },
                    { 1307, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 13 },
                    { 1308, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 13 },
                    { 1309, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 13 },
                    { 1310, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 13 },
                    { 1311, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 13 },
                    { 1312, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 13 },
                    { 1313, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 13 },
                    { 1314, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 13 },
                    { 1315, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 13 },
                    { 1316, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 13 },
                    { 1317, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 13 },
                    { 1318, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 13 },
                    { 1319, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 13 },
                    { 1320, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 13 },
                    { 1321, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 13 },
                    { 1322, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 13 },
                    { 1323, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 13 },
                    { 1324, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 13 },
                    { 1325, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 13 },
                    { 1326, new DateTime(2022, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 13 },
                    { 1329, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 14 },
                    { 1330, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 14 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1331, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 14 },
                    { 1332, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 14 },
                    { 1333, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 14 },
                    { 1334, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 14 },
                    { 1335, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 14 },
                    { 1336, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 14 },
                    { 1337, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 14 },
                    { 1338, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 14 },
                    { 1339, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 14 },
                    { 1340, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 14 },
                    { 1341, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 14 },
                    { 1342, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 14 },
                    { 1343, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 14 },
                    { 1344, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 14 },
                    { 1345, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 14 },
                    { 1346, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 14 },
                    { 1347, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 14 },
                    { 1348, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 14 },
                    { 1349, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 14 },
                    { 1350, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 14 },
                    { 1351, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 14 },
                    { 1352, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 14 },
                    { 1353, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 14 },
                    { 1354, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 14 },
                    { 1355, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 14 },
                    { 1356, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 14 },
                    { 1357, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 14 },
                    { 1358, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 14 },
                    { 1359, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 14 },
                    { 1360, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 14 },
                    { 1361, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 14 },
                    { 1362, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 14 },
                    { 1363, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 14 },
                    { 1364, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 14 },
                    { 1365, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 14 },
                    { 1366, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 14 },
                    { 1367, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 14 },
                    { 1368, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 14 },
                    { 1369, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 14 },
                    { 1370, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 14 },
                    { 1371, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 14 },
                    { 1372, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 14 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1373, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 14 },
                    { 1374, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 14 },
                    { 1375, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 14 },
                    { 1376, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 14 },
                    { 1377, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 14 },
                    { 1378, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 14 },
                    { 1379, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 14 },
                    { 1380, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 14 },
                    { 1381, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 14 },
                    { 1382, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 14 },
                    { 1383, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 14 },
                    { 1384, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 14 },
                    { 1385, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 14 },
                    { 1386, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 14 },
                    { 1387, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 14 },
                    { 1388, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 14 },
                    { 1389, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 14 },
                    { 1390, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 14 },
                    { 1391, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 14 },
                    { 1392, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 14 },
                    { 1393, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 14 },
                    { 1394, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 14 },
                    { 1395, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 14 },
                    { 1396, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 14 },
                    { 1397, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 14 },
                    { 1398, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 14 },
                    { 1399, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 14 },
                    { 1400, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 14 },
                    { 1401, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 14 },
                    { 1402, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 14 },
                    { 1403, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 14 },
                    { 1404, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 14 },
                    { 1405, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 14 },
                    { 1406, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 14 },
                    { 1407, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 14 },
                    { 1408, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 14 },
                    { 1409, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 14 },
                    { 1410, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 14 },
                    { 1411, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 14 },
                    { 1412, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 14 },
                    { 1413, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 14 },
                    { 1414, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 14 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1415, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 14 },
                    { 1416, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 14 },
                    { 1417, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 14 },
                    { 1418, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 14 },
                    { 1419, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 14 },
                    { 1420, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 14 },
                    { 1421, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 14 },
                    { 1422, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 14 },
                    { 1423, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 14 },
                    { 1424, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 14 },
                    { 1425, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 14 },
                    { 1426, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 14 },
                    { 1427, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 14 },
                    { 1428, new DateTime(2022, 9, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 14 },
                    { 1431, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 15 },
                    { 1432, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 15 },
                    { 1433, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 15 },
                    { 1434, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 15 },
                    { 1435, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 15 },
                    { 1436, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 15 },
                    { 1437, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 15 },
                    { 1438, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 15 },
                    { 1439, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 15 },
                    { 1440, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 15 },
                    { 1441, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 15 },
                    { 1442, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 15 },
                    { 1443, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 15 },
                    { 1444, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 15 },
                    { 1445, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 15 },
                    { 1446, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 15 },
                    { 1447, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 15 },
                    { 1448, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 15 },
                    { 1449, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 15 },
                    { 1450, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 15 },
                    { 1451, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 15 },
                    { 1452, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 15 },
                    { 1453, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 15 },
                    { 1454, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 15 },
                    { 1455, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 15 },
                    { 1456, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 15 },
                    { 1457, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 15 },
                    { 1458, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 15 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1459, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 15 },
                    { 1460, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 15 },
                    { 1461, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 15 },
                    { 1462, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 15 },
                    { 1463, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 15 },
                    { 1464, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 15 },
                    { 1465, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 15 },
                    { 1466, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 15 },
                    { 1467, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 15 },
                    { 1468, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 15 },
                    { 1469, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 15 },
                    { 1470, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 15 },
                    { 1471, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 15 },
                    { 1472, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 15 },
                    { 1473, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 15 },
                    { 1474, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 15 },
                    { 1475, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 15 },
                    { 1476, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 15 },
                    { 1477, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 15 },
                    { 1478, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 15 },
                    { 1479, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 15 },
                    { 1480, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 15 },
                    { 1481, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 15 },
                    { 1482, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 15 },
                    { 1483, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 15 },
                    { 1484, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 15 },
                    { 1485, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 15 },
                    { 1486, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 15 },
                    { 1487, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 15 },
                    { 1488, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 15 },
                    { 1489, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 15 },
                    { 1490, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 15 },
                    { 1491, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 15 },
                    { 1492, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 15 },
                    { 1493, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 15 },
                    { 1494, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 15 },
                    { 1495, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 15 },
                    { 1496, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 15 },
                    { 1497, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 15 },
                    { 1498, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 15 },
                    { 1499, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 15 },
                    { 1500, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 15 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1501, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 15 },
                    { 1502, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 15 },
                    { 1503, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 15 },
                    { 1504, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 15 },
                    { 1505, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 15 },
                    { 1506, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 15 },
                    { 1507, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 15 },
                    { 1508, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 15 },
                    { 1509, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 15 },
                    { 1510, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 15 },
                    { 1511, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 15 },
                    { 1512, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 15 },
                    { 1513, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 15 },
                    { 1514, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 15 },
                    { 1515, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 15 },
                    { 1516, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 15 },
                    { 1517, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 15 },
                    { 1518, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 15 },
                    { 1519, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 15 },
                    { 1520, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 15 },
                    { 1521, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 15 },
                    { 1522, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 15 },
                    { 1523, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 15 },
                    { 1524, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 15 },
                    { 1525, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 15 },
                    { 1526, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 15 },
                    { 1527, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 15 },
                    { 1528, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 15 },
                    { 1529, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 15 },
                    { 1530, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 15 },
                    { 1533, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 16 },
                    { 1534, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 16 },
                    { 1535, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 16 },
                    { 1536, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 16 },
                    { 1537, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 16 },
                    { 1538, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 16 },
                    { 1539, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 16 },
                    { 1540, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 16 },
                    { 1541, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 16 },
                    { 1542, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 16 },
                    { 1543, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 16 },
                    { 1544, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 16 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1545, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 16 },
                    { 1546, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 16 },
                    { 1547, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 16 },
                    { 1548, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 16 },
                    { 1549, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 16 },
                    { 1550, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 16 },
                    { 1551, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 16 },
                    { 1552, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 16 },
                    { 1553, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 16 },
                    { 1554, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 16 },
                    { 1555, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 16 },
                    { 1556, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 16 },
                    { 1557, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 16 },
                    { 1558, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 16 },
                    { 1559, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 16 },
                    { 1560, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 16 },
                    { 1561, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 16 },
                    { 1562, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 16 },
                    { 1563, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 16 },
                    { 1564, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 16 },
                    { 1565, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 16 },
                    { 1566, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 16 },
                    { 1567, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 16 },
                    { 1568, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 16 },
                    { 1569, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 16 },
                    { 1570, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 16 },
                    { 1571, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 16 },
                    { 1572, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 16 },
                    { 1573, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 16 },
                    { 1574, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 16 },
                    { 1575, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 16 },
                    { 1576, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 16 },
                    { 1577, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 16 },
                    { 1578, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 16 },
                    { 1579, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 16 },
                    { 1580, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 16 },
                    { 1581, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 16 },
                    { 1582, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 16 },
                    { 1583, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 16 },
                    { 1584, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 16 },
                    { 1585, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 16 },
                    { 1586, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 16 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1587, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 16 },
                    { 1588, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 16 },
                    { 1589, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 16 },
                    { 1590, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 16 },
                    { 1591, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 16 },
                    { 1592, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 16 },
                    { 1593, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 16 },
                    { 1594, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 16 },
                    { 1595, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 16 },
                    { 1596, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 16 },
                    { 1597, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 16 },
                    { 1598, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 16 },
                    { 1599, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 16 },
                    { 1600, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 16 },
                    { 1601, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 16 },
                    { 1602, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 16 },
                    { 1603, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 16 },
                    { 1604, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 16 },
                    { 1605, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 16 },
                    { 1606, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 16 },
                    { 1607, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 16 },
                    { 1608, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 16 },
                    { 1609, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 16 },
                    { 1610, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 16 },
                    { 1611, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 16 },
                    { 1612, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 16 },
                    { 1613, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 16 },
                    { 1614, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 16 },
                    { 1615, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 16 },
                    { 1616, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 16 },
                    { 1617, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 16 },
                    { 1618, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 16 },
                    { 1619, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 16 },
                    { 1620, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 16 },
                    { 1621, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 16 },
                    { 1622, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 16 },
                    { 1623, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 16 },
                    { 1624, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 16 },
                    { 1625, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 16 },
                    { 1626, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 16 },
                    { 1627, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 16 },
                    { 1628, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 16 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1629, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 16 },
                    { 1630, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 16 },
                    { 1631, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 16 },
                    { 1632, new DateTime(2022, 9, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 16 },
                    { 1635, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 17 },
                    { 1636, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 17 },
                    { 1637, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 17 },
                    { 1638, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 17 },
                    { 1639, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 17 },
                    { 1640, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 17 },
                    { 1641, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 17 },
                    { 1642, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 17 },
                    { 1643, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 17 },
                    { 1644, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 17 },
                    { 1645, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 17 },
                    { 1646, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 17 },
                    { 1647, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 17 },
                    { 1648, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 17 },
                    { 1649, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 17 },
                    { 1650, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 17 },
                    { 1651, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 17 },
                    { 1652, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 17 },
                    { 1653, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 17 },
                    { 1654, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 17 },
                    { 1655, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 17 },
                    { 1656, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 17 },
                    { 1657, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 17 },
                    { 1658, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 17 },
                    { 1659, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 17 },
                    { 1660, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 17 },
                    { 1661, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 17 },
                    { 1662, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 17 },
                    { 1663, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 17 },
                    { 1664, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 17 },
                    { 1665, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 17 },
                    { 1666, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 17 },
                    { 1667, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 17 },
                    { 1668, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 17 },
                    { 1669, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 17 },
                    { 1670, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 17 },
                    { 1671, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 17 },
                    { 1672, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 17 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1673, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 17 },
                    { 1674, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 17 },
                    { 1675, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 17 },
                    { 1676, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 17 },
                    { 1677, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 17 },
                    { 1678, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 17 },
                    { 1679, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 17 },
                    { 1680, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 17 },
                    { 1681, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 17 },
                    { 1682, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 17 },
                    { 1683, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 17 },
                    { 1684, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 17 },
                    { 1685, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 17 },
                    { 1686, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 17 },
                    { 1687, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 17 },
                    { 1688, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 17 },
                    { 1689, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 17 },
                    { 1690, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 17 },
                    { 1691, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 17 },
                    { 1692, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 17 },
                    { 1693, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 17 },
                    { 1694, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 17 },
                    { 1695, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 17 },
                    { 1696, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 17 },
                    { 1697, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 17 },
                    { 1698, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 17 },
                    { 1699, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 17 },
                    { 1700, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 17 },
                    { 1701, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 17 },
                    { 1702, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 17 },
                    { 1703, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 17 },
                    { 1704, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 17 },
                    { 1705, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 17 },
                    { 1706, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 17 },
                    { 1707, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 17 },
                    { 1708, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 17 },
                    { 1709, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 17 },
                    { 1710, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 17 },
                    { 1711, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 17 },
                    { 1712, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 17 },
                    { 1713, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 17 },
                    { 1714, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 17 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1715, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 17 },
                    { 1716, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 17 },
                    { 1717, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 17 },
                    { 1718, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 17 },
                    { 1719, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 17 },
                    { 1720, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 17 },
                    { 1721, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 17 },
                    { 1722, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 17 },
                    { 1723, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 17 },
                    { 1724, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 17 },
                    { 1725, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 17 },
                    { 1726, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 17 },
                    { 1727, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 17 },
                    { 1728, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 17 },
                    { 1729, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 17 },
                    { 1730, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 17 },
                    { 1731, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 17 },
                    { 1732, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 17 },
                    { 1733, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 17 },
                    { 1734, new DateTime(2022, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 17 },
                    { 1737, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 18 },
                    { 1738, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 18 },
                    { 1739, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 18 },
                    { 1740, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 18 },
                    { 1741, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 18 },
                    { 1742, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 18 },
                    { 1743, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 18 },
                    { 1744, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 18 },
                    { 1745, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 18 },
                    { 1746, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 18 },
                    { 1747, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 18 },
                    { 1748, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 18 },
                    { 1749, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 18 },
                    { 1750, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 18 },
                    { 1751, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 18 },
                    { 1752, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 18 },
                    { 1753, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 18 },
                    { 1754, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 18 },
                    { 1755, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 18 },
                    { 1756, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 18 },
                    { 1757, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 18 },
                    { 1758, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 18 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1759, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 18 },
                    { 1760, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 18 },
                    { 1761, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 18 },
                    { 1762, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 18 },
                    { 1763, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 18 },
                    { 1764, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 18 },
                    { 1765, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 18 },
                    { 1766, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 18 },
                    { 1767, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 18 },
                    { 1768, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 18 },
                    { 1769, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 18 },
                    { 1770, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 18 },
                    { 1771, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 18 },
                    { 1772, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 18 },
                    { 1773, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 18 },
                    { 1774, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 18 },
                    { 1775, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 18 },
                    { 1776, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 18 },
                    { 1777, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 18 },
                    { 1778, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 18 },
                    { 1779, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 18 },
                    { 1780, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 18 },
                    { 1781, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 18 },
                    { 1782, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 18 },
                    { 1783, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 18 },
                    { 1784, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 18 },
                    { 1785, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 18 },
                    { 1786, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 18 },
                    { 1787, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 18 },
                    { 1788, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 18 },
                    { 1789, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 18 },
                    { 1790, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 18 },
                    { 1791, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 18 },
                    { 1792, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 18 },
                    { 1793, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 18 },
                    { 1794, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 18 },
                    { 1795, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 18 },
                    { 1796, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 18 },
                    { 1797, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 18 },
                    { 1798, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 18 },
                    { 1799, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 18 },
                    { 1800, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 18 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1801, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 18 },
                    { 1802, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 18 },
                    { 1803, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 18 },
                    { 1804, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 18 },
                    { 1805, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 18 },
                    { 1806, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 18 },
                    { 1807, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 18 },
                    { 1808, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 18 },
                    { 1809, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 18 },
                    { 1810, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 18 },
                    { 1811, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 18 },
                    { 1812, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 18 },
                    { 1813, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 18 },
                    { 1814, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 18 },
                    { 1815, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 18 },
                    { 1816, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 18 },
                    { 1817, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 18 },
                    { 1818, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 18 },
                    { 1819, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 18 },
                    { 1820, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 18 },
                    { 1821, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 18 },
                    { 1822, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 18 },
                    { 1823, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 18 },
                    { 1824, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 18 },
                    { 1825, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 18 },
                    { 1826, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 18 },
                    { 1827, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 18 },
                    { 1828, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 18 },
                    { 1829, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 18 },
                    { 1830, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 18 },
                    { 1831, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 18 },
                    { 1832, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 18 },
                    { 1833, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 18 },
                    { 1834, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 18 },
                    { 1835, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 18 },
                    { 1836, new DateTime(2022, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 18 },
                    { 1839, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 19 },
                    { 1840, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 19 },
                    { 1841, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 19 },
                    { 1842, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 19 },
                    { 1843, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 19 },
                    { 1844, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 19 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1845, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 19 },
                    { 1846, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 19 },
                    { 1847, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 19 },
                    { 1848, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 19 },
                    { 1849, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 19 },
                    { 1850, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 19 },
                    { 1851, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 19 },
                    { 1852, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 19 },
                    { 1853, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 19 },
                    { 1854, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 19 },
                    { 1855, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 19 },
                    { 1856, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 19 },
                    { 1857, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 19 },
                    { 1858, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 19 },
                    { 1859, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 19 },
                    { 1860, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 19 },
                    { 1861, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 19 },
                    { 1862, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 19 },
                    { 1863, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 19 },
                    { 1864, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 19 },
                    { 1865, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 19 },
                    { 1866, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 19 },
                    { 1867, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 19 },
                    { 1868, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 19 },
                    { 1869, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 19 },
                    { 1870, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 19 },
                    { 1871, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 19 },
                    { 1872, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 19 },
                    { 1873, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 19 },
                    { 1874, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 19 },
                    { 1875, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 19 },
                    { 1876, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 19 },
                    { 1877, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 19 },
                    { 1878, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 19 },
                    { 1879, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 19 },
                    { 1880, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 19 },
                    { 1881, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 19 },
                    { 1882, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 19 },
                    { 1883, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 19 },
                    { 1884, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 19 },
                    { 1885, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 19 },
                    { 1886, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 19 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1887, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 19 },
                    { 1888, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 19 },
                    { 1889, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 19 },
                    { 1890, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 19 },
                    { 1891, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 19 },
                    { 1892, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 19 },
                    { 1893, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 19 },
                    { 1894, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 19 },
                    { 1895, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 19 },
                    { 1896, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 19 },
                    { 1897, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 19 },
                    { 1898, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 19 },
                    { 1899, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 19 },
                    { 1900, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 19 },
                    { 1901, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 19 },
                    { 1902, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 19 },
                    { 1903, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 19 },
                    { 1904, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 19 },
                    { 1905, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 19 },
                    { 1906, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 19 },
                    { 1907, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 19 },
                    { 1908, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 19 },
                    { 1909, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 19 },
                    { 1910, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 19 },
                    { 1911, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 19 },
                    { 1912, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 19 },
                    { 1913, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 19 },
                    { 1914, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 19 },
                    { 1915, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 19 },
                    { 1916, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 19 },
                    { 1917, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 19 },
                    { 1918, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 19 },
                    { 1919, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 19 },
                    { 1920, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 19 },
                    { 1921, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 19 },
                    { 1922, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 19 },
                    { 1923, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 19 },
                    { 1924, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 19 },
                    { 1925, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 19 },
                    { 1926, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 19 },
                    { 1927, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 19 },
                    { 1928, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 19 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1929, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 19 },
                    { 1930, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 19 },
                    { 1931, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 19 },
                    { 1932, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 19 },
                    { 1933, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 19 },
                    { 1934, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 19 },
                    { 1935, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 19 },
                    { 1936, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 19 },
                    { 1937, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 19 },
                    { 1938, new DateTime(2022, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 19 },
                    { 1941, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 20 },
                    { 1942, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 20 },
                    { 1943, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 20 },
                    { 1944, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 20 },
                    { 1945, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 20 },
                    { 1946, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 20 },
                    { 1947, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 20 },
                    { 1948, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 20 },
                    { 1949, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 20 },
                    { 1950, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 20 },
                    { 1951, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 20 },
                    { 1952, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 20 },
                    { 1953, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 20 },
                    { 1954, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 20 },
                    { 1955, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 20 },
                    { 1956, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 20 },
                    { 1957, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 20 },
                    { 1958, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 20 },
                    { 1959, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 20 },
                    { 1960, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 20 },
                    { 1961, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 20 },
                    { 1962, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 20 },
                    { 1963, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 20 },
                    { 1964, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 20 },
                    { 1965, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 20 },
                    { 1966, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 20 },
                    { 1967, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 20 },
                    { 1968, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 20 },
                    { 1969, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 20 },
                    { 1970, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 20 },
                    { 1971, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 20 },
                    { 1972, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 20 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 1973, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 20 },
                    { 1974, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 20 },
                    { 1975, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 20 },
                    { 1976, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 20 },
                    { 1977, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 20 },
                    { 1978, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 20 },
                    { 1979, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 20 },
                    { 1980, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 20 },
                    { 1981, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 20 },
                    { 1982, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 20 },
                    { 1983, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 20 },
                    { 1984, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 20 },
                    { 1985, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 20 },
                    { 1986, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 20 },
                    { 1987, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 20 },
                    { 1988, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 20 },
                    { 1989, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 20 },
                    { 1990, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 20 },
                    { 1991, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 20 },
                    { 1992, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 20 },
                    { 1993, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 20 },
                    { 1994, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 20 },
                    { 1995, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 20 },
                    { 1996, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 20 },
                    { 1997, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 20 },
                    { 1998, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 20 },
                    { 1999, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 20 },
                    { 2000, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 20 },
                    { 2001, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 20 },
                    { 2002, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 20 },
                    { 2003, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 20 },
                    { 2004, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 20 },
                    { 2005, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 20 },
                    { 2006, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 20 },
                    { 2007, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 20 },
                    { 2008, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 20 },
                    { 2009, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 20 },
                    { 2010, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 20 },
                    { 2011, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 20 },
                    { 2012, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 20 },
                    { 2013, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 20 },
                    { 2014, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 20 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 2015, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 20 },
                    { 2016, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 20 },
                    { 2017, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 20 },
                    { 2018, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 20 },
                    { 2019, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 20 },
                    { 2020, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 20 },
                    { 2021, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 20 },
                    { 2022, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 20 },
                    { 2023, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 20 },
                    { 2024, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 20 },
                    { 2025, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 20 },
                    { 2026, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 20 },
                    { 2027, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 20 },
                    { 2028, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 20 },
                    { 2029, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 20 },
                    { 2030, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 20 },
                    { 2031, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 20 },
                    { 2032, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 20 },
                    { 2033, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 20 },
                    { 2034, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 20 },
                    { 2035, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 20 },
                    { 2036, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 20 },
                    { 2037, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 20 },
                    { 2038, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 20 },
                    { 2039, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 20 },
                    { 2040, new DateTime(2022, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 20 },
                    { 2043, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 21 },
                    { 2044, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 21 },
                    { 2045, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 21 },
                    { 2046, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 21 },
                    { 2047, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 21 },
                    { 2048, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 21 },
                    { 2049, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 21 },
                    { 2050, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 21 },
                    { 2051, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 21 },
                    { 2052, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 21 },
                    { 2053, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 21 },
                    { 2054, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 21 },
                    { 2055, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 21 },
                    { 2056, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 21 },
                    { 2057, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 21 },
                    { 2058, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 21 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 2059, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 21 },
                    { 2060, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 21 },
                    { 2061, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 21 },
                    { 2062, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 21 },
                    { 2063, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 21 },
                    { 2064, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 21 },
                    { 2065, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 21 },
                    { 2066, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 21 },
                    { 2067, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 21 },
                    { 2068, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 21 },
                    { 2069, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 21 },
                    { 2070, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 21 },
                    { 2071, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 21 },
                    { 2072, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 21 },
                    { 2073, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 21 },
                    { 2074, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 21 },
                    { 2075, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 21 },
                    { 2076, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 21 },
                    { 2077, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 21 },
                    { 2078, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 21 },
                    { 2079, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 21 },
                    { 2080, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 21 },
                    { 2081, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 21 },
                    { 2082, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 21 },
                    { 2083, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 21 },
                    { 2084, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 21 },
                    { 2085, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 21 },
                    { 2086, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 21 },
                    { 2087, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 21 },
                    { 2088, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 21 },
                    { 2089, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 21 },
                    { 2090, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 21 },
                    { 2091, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 21 },
                    { 2092, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 21 },
                    { 2093, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 21 },
                    { 2094, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 21 },
                    { 2095, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 21 },
                    { 2096, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 21 },
                    { 2097, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 21 },
                    { 2098, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 21 },
                    { 2099, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 21 },
                    { 2100, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 21 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 2101, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 21 },
                    { 2102, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 21 },
                    { 2103, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 21 },
                    { 2104, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 21 },
                    { 2105, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 21 },
                    { 2106, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 21 },
                    { 2107, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 21 },
                    { 2108, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 21 },
                    { 2109, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 21 },
                    { 2110, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 21 },
                    { 2111, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 21 },
                    { 2112, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 21 },
                    { 2113, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 21 },
                    { 2114, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 21 },
                    { 2115, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 21 },
                    { 2116, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 21 },
                    { 2117, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 21 },
                    { 2118, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 21 },
                    { 2119, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 21 },
                    { 2120, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 21 },
                    { 2121, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 21 },
                    { 2122, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 21 },
                    { 2123, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 21 },
                    { 2124, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 21 },
                    { 2125, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 21 },
                    { 2126, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 21 },
                    { 2127, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 21 },
                    { 2128, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 21 },
                    { 2129, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 21 },
                    { 2130, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 21 },
                    { 2131, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 21 },
                    { 2132, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 21 },
                    { 2133, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 21 },
                    { 2134, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 21 },
                    { 2135, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 21 },
                    { 2136, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 21 },
                    { 2137, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 21 },
                    { 2138, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 21 },
                    { 2139, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 21 },
                    { 2140, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 21 },
                    { 2141, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 21 },
                    { 2142, new DateTime(2022, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 21 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 2145, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 4, null, 22 },
                    { 2146, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 5, null, 22 },
                    { 2147, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 6, null, 22 },
                    { 2148, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 7, null, 22 },
                    { 2149, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 8, null, 22 },
                    { 2150, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 9, null, 22 },
                    { 2151, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 10, null, 22 },
                    { 2152, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 11, null, 22 },
                    { 2153, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 12, null, 22 },
                    { 2154, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 13, null, 22 },
                    { 2155, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 14, null, 22 },
                    { 2156, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, null, 22 },
                    { 2157, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 16, null, 22 },
                    { 2158, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 17, null, 22 },
                    { 2159, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 18, null, 22 },
                    { 2160, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 19, null, 22 },
                    { 2161, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 20, null, 22 },
                    { 2162, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 21, null, 22 },
                    { 2163, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 22, null, 22 },
                    { 2164, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 23, null, 22 },
                    { 2165, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 24, null, 22 },
                    { 2166, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 25, null, 22 },
                    { 2167, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 26, null, 22 },
                    { 2168, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 27, null, 22 },
                    { 2169, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 28, null, 22 },
                    { 2170, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 29, null, 22 },
                    { 2171, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 30, null, 22 },
                    { 2172, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 31, null, 22 },
                    { 2173, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 32, null, 22 },
                    { 2174, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 33, null, 22 },
                    { 2175, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 34, null, 22 },
                    { 2176, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 35, null, 22 },
                    { 2177, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 36, null, 22 },
                    { 2178, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 37, null, 22 },
                    { 2179, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 38, null, 22 },
                    { 2180, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 39, null, 22 },
                    { 2181, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 40, null, 22 },
                    { 2182, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 41, null, 22 },
                    { 2183, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 42, null, 22 },
                    { 2184, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 43, null, 22 },
                    { 2185, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 44, null, 22 },
                    { 2186, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 45, null, 22 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 2187, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 46, null, 22 },
                    { 2188, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 47, null, 22 },
                    { 2189, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 48, null, 22 },
                    { 2190, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 49, null, 22 },
                    { 2191, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50, null, 22 },
                    { 2192, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 51, null, 22 },
                    { 2193, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 52, null, 22 },
                    { 2194, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 53, null, 22 },
                    { 2195, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 54, null, 22 },
                    { 2196, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 55, null, 22 },
                    { 2197, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 56, null, 22 },
                    { 2198, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 57, null, 22 },
                    { 2199, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 58, null, 22 },
                    { 2200, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 59, null, 22 },
                    { 2201, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 60, null, 22 },
                    { 2202, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 61, null, 22 },
                    { 2203, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 62, null, 22 },
                    { 2204, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 63, null, 22 },
                    { 2205, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 64, null, 22 },
                    { 2206, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 65, null, 22 },
                    { 2207, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 66, null, 22 },
                    { 2208, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 67, null, 22 },
                    { 2209, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 68, null, 22 },
                    { 2210, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 69, null, 22 },
                    { 2211, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 70, null, 22 },
                    { 2212, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 71, null, 22 },
                    { 2213, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 72, null, 22 },
                    { 2214, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 73, null, 22 },
                    { 2215, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 74, null, 22 },
                    { 2216, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 75, null, 22 },
                    { 2217, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 76, null, 22 },
                    { 2218, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 77, null, 22 },
                    { 2219, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 78, null, 22 },
                    { 2220, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 79, null, 22 },
                    { 2221, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 80, null, 22 },
                    { 2222, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 81, null, 22 },
                    { 2223, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 82, null, 22 },
                    { 2224, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 83, null, 22 },
                    { 2225, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 84, null, 22 },
                    { 2226, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 85, null, 22 },
                    { 2227, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 86, null, 22 },
                    { 2228, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 87, null, 22 }
                });

            migrationBuilder.InsertData(
                table: "WorkingShiftTimekeepings",
                columns: new[] { "Id", "CheckinTime", "CheckoutTime", "DidCheckIn", "DidCheckout", "EmployeeId", "PayslipId", "WorkingShiftEventId" },
                values: new object[,]
                {
                    { 2229, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 88, null, 22 },
                    { 2230, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 89, null, 22 },
                    { 2231, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 90, null, 22 },
                    { 2232, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 91, null, 22 },
                    { 2233, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 92, null, 22 },
                    { 2234, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 93, null, 22 },
                    { 2235, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 94, null, 22 },
                    { 2236, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 95, null, 22 },
                    { 2237, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 96, null, 22 },
                    { 2238, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 97, null, 22 },
                    { 2239, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 98, null, 22 },
                    { 2240, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 99, null, 22 },
                    { 2241, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 100, null, 22 },
                    { 2242, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 101, null, 22 },
                    { 2243, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 102, null, 22 },
                    { 2244, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), true, true, 103, null, 22 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerId",
                table: "Departments",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentDepartmentId",
                table: "Departments",
                column: "ParentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_EmployeeId",
                table: "Payslips",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_PayrollId",
                table: "Payslips",
                column: "PayrollId");

            migrationBuilder.CreateIndex(
                name: "IX_PayslipSalaryDelta_PayslipId",
                table: "PayslipSalaryDelta",
                column: "PayslipId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                table: "RolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryFormulas_Name",
                table: "SalaryFormulas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalaryVariables_Name",
                table: "SalaryVariables",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskBoards_TeamId",
                table: "TaskBoards",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskColumns_BoardId",
                table: "TaskColumns",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_TaskId",
                table: "TaskComments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_UserId",
                table: "TaskComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskFiles_TaskCommentId",
                table: "TaskFiles",
                column: "TaskCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ColumnId",
                table: "Tasks",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ColumnId1",
                table: "Tasks",
                column: "ColumnId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTaskLabel_TaskLabelId",
                table: "TaskTaskLabel",
                column: "TaskLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_DepartmentId",
                table: "Teams",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeaderId",
                table: "Teams",
                column: "LeaderId",
                unique: true,
                filter: "[LeaderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BankInfoId",
                table: "Users",
                column: "BankInfoId",
                unique: true,
                filter: "[BankInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSalaryDelta_SalaryDeltaId",
                table: "UserSalaryDelta",
                column: "SalaryDeltaId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingShiftEventUser_WorkingShiftEventId",
                table: "WorkingShiftEventUser",
                column: "WorkingShiftEventId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingShiftTimekeepings_EmployeeId",
                table: "WorkingShiftTimekeepings",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingShiftTimekeepings_PayslipId",
                table: "WorkingShiftTimekeepings",
                column: "PayslipId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingShiftTimekeepings_WorkingShiftEventId",
                table: "WorkingShiftTimekeepings",
                column: "WorkingShiftEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_ManagerId",
                table: "Departments",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payslips_Users_EmployeeId",
                table: "Payslips",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskBoards_Teams_TeamId",
                table: "TaskBoards",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_Tasks_TaskId",
                table: "TaskComments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_Users_UserId",
                table: "TaskComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_LeaderId",
                table: "Teams",
                column: "LeaderId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_ManagerId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_LeaderId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "PayslipSalaryDelta");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "SalaryFormulas");

            migrationBuilder.DropTable(
                name: "SalaryVariables");

            migrationBuilder.DropTable(
                name: "TaskFiles");

            migrationBuilder.DropTable(
                name: "TaskTaskLabel");

            migrationBuilder.DropTable(
                name: "UserSalaryDelta");

            migrationBuilder.DropTable(
                name: "WorkingShiftEventUser");

            migrationBuilder.DropTable(
                name: "WorkingShiftTimekeepings");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "TaskComments");

            migrationBuilder.DropTable(
                name: "TaskLabels");

            migrationBuilder.DropTable(
                name: "SalaryDeltas");

            migrationBuilder.DropTable(
                name: "Payslips");

            migrationBuilder.DropTable(
                name: "WorkingShiftEvents");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Payrolls");

            migrationBuilder.DropTable(
                name: "TaskColumns");

            migrationBuilder.DropTable(
                name: "TaskBoards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BankInfo");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SalaryGroups");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
