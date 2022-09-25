using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class _1112 : Migration
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
                name: "Constant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Define = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Input",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Input", x => x.Id);
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
                name: "ConstantFormula",
                columns: table => new
                {
                    ConstantsId = table.Column<int>(type: "int", nullable: false),
                    FormulasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstantFormula", x => new { x.ConstantsId, x.FormulasId });
                    table.ForeignKey(
                        name: "FK_ConstantFormula_Constant_ConstantsId",
                        column: x => x.ConstantsId,
                        principalTable: "Constant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstantFormula_Formula_FormulasId",
                        column: x => x.FormulasId,
                        principalTable: "Formula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeductionAllowanceBonusTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormulaId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplyType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeductionAllowanceBonusTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeductionAllowanceBonusTemplate_Formula_FormulaId",
                        column: x => x.FormulaId,
                        principalTable: "Formula",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormulaInput",
                columns: table => new
                {
                    FormulasId = table.Column<int>(type: "int", nullable: false),
                    InputsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaInput", x => new { x.FormulasId, x.InputsId });
                    table.ForeignKey(
                        name: "FK_FormulaInput_Formula_FormulasId",
                        column: x => x.FormulasId,
                        principalTable: "Formula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormulaInput_Input_InputsId",
                        column: x => x.InputsId,
                        principalTable: "Input",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "DeductionAllowanceBonus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateId = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeductionAllowanceBonus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeductionAllowanceBonus_DeductionAllowanceBonusTemplate_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "DeductionAllowanceBonusTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeductionAllowanceBonusUser",
                columns: table => new
                {
                    DeductionAllowanceBonusesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeductionAllowanceBonusUser", x => new { x.DeductionAllowanceBonusesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_DeductionAllowanceBonusUser_DeductionAllowanceBonus_DeductionAllowanceBonusesId",
                        column: x => x.DeductionAllowanceBonusesId,
                        principalTable: "DeductionAllowanceBonus",
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
                name: "Payslip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseSalary = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payslip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<bool>(type: "bit", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CitizenId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Workday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CheckAt = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workday_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "role.create", "role.create" },
                    { 2, "role.retrieve", "role.retrieve" },
                    { 3, "role.update", "role.update" },
                    { 4, "role.delete", "role.delete" },
                    { 5, "permission.create", "permission.create" },
                    { 6, "permission.retrieve", "permission.retrieve" },
                    { 7, "permission.update", "permission.update" },
                    { 8, "permission.delete", "permission.delete" },
                    { 9, "team.create", "team.create" },
                    { 10, "team.retrieve", "team.retrieve" },
                    { 11, "team.update", "team.update" },
                    { 12, "team.delete", "team.delete" },
                    { 13, "department.create", "department.create" },
                    { 14, "department.retrieve", "department.retrieve" },
                    { 15, "department.update", "department.update" },
                    { 16, "department.delete", "department.delete" },
                    { 17, "group.create", "group.create" },
                    { 18, "group.retrieve", "group.retrieve" },
                    { 19, "group.update", "group.update" },
                    { 20, "group.delete", "group.delete" },
                    { 21, "dab.create", "dab.create" },
                    { 22, "dab.retrieve", "dab.retrieve" },
                    { 23, "dab.update", "dab.update" },
                    { 24, "dab.delete", "dab.delete" },
                    { 25, "formula.create", "formula.create" },
                    { 26, "formula.retrieve", "formula.retrieve" },
                    { 27, "formula.update", "formula.update" },
                    { 28, "formula.delete", "formula.delete" },
                    { 29, "payslip.create", "payslip.create" },
                    { 30, "payslip.retrieve", "payslip.retrieve" },
                    { 31, "payslip.update", "payslip.update" },
                    { 32, "payslip.delete", "payslip.delete" }
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
                    { 32, 7 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BankInfoId", "Birthday", "CitizenId", "Email", "FaceId", "InsuranceCode", "Name", "Password", "PhoneNumber", "RoleId", "Sex", "SocialInsuranceId", "TaxCode", "TeamId", "TokenSlack", "TokenTrello", "UrlImage", "Username" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000001", null, null, null, "Admin User", "admin", null, 1, false, null, null, null, null, null, null, "admin" },
                    { 2, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000002", null, null, null, "Manager User", "manager", null, 2, false, null, null, null, null, null, null, "manager" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Detail", "ManagerId", "Name", "ParentDepartmentId" },
                values: new object[] { 1, "Detail for Head Department", 2, "Head Department", null });

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
                columns: new[] { "Id", "Address", "BankInfoId", "Birthday", "CitizenId", "Email", "FaceId", "InsuranceCode", "Name", "Password", "PhoneNumber", "RoleId", "Sex", "SocialInsuranceId", "TaxCode", "TeamId", "TokenSlack", "TokenTrello", "UrlImage", "Username" },
                values: new object[,]
                {
                    { 4, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0000004", null, null, null, "User 4", "password4", null, null, false, null, null, 1, null, null, null, "user4" },
                    { 5, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0000005", null, null, null, "User 5", "password5", null, null, false, null, null, 2, null, null, null, "user5" },
                    { 6, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0000006", null, null, null, "User 6", "password6", null, null, false, null, null, 1, null, null, null, "user6" },
                    { 7, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0000007", null, null, null, "User 7", "password7", null, null, false, null, null, 2, null, null, null, "user7" },
                    { 8, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0000008", null, null, null, "User 8", "password8", null, null, false, null, null, 1, null, null, null, "user8" },
                    { 9, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0000009", null, null, null, "User 9", "password9", null, null, false, null, null, 2, null, null, null, "user9" },
                    { 10, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000010", null, null, null, "User 10", "password10", null, null, false, null, null, 1, null, null, null, "user10" },
                    { 11, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000011", null, null, null, "User 11", "password11", null, null, false, null, null, 2, null, null, null, "user11" },
                    { 12, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000012", null, null, null, "User 12", "password12", null, null, false, null, null, 1, null, null, null, "user12" },
                    { 13, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000013", null, null, null, "User 13", "password13", null, null, false, null, null, 2, null, null, null, "user13" },
                    { 14, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000014", null, null, null, "User 14", "password14", null, null, false, null, null, 1, null, null, null, "user14" },
                    { 15, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000015", null, null, null, "User 15", "password15", null, null, false, null, null, 2, null, null, null, "user15" },
                    { 16, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000016", null, null, null, "User 16", "password16", null, null, false, null, null, 1, null, null, null, "user16" },
                    { 17, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000017", null, null, null, "User 17", "password17", null, null, false, null, null, 2, null, null, null, "user17" },
                    { 18, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000018", null, null, null, "User 18", "password18", null, null, false, null, null, 1, null, null, null, "user18" },
                    { 19, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000019", null, null, null, "User 19", "password19", null, null, false, null, null, 2, null, null, null, "user19" },
                    { 20, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000020", null, null, null, "User 20", "password20", null, null, false, null, null, 1, null, null, null, "user20" },
                    { 21, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000021", null, null, null, "User 21", "password21", null, null, false, null, null, 2, null, null, null, "user21" },
                    { 22, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000022", null, null, null, "User 22", "password22", null, null, false, null, null, 1, null, null, null, "user22" },
                    { 23, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000023", null, null, null, "User 23", "password23", null, null, false, null, null, 2, null, null, null, "user23" },
                    { 24, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000024", null, null, null, "User 24", "password24", null, null, false, null, null, 1, null, null, null, "user24" },
                    { 25, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000025", null, null, null, "User 25", "password25", null, null, false, null, null, 2, null, null, null, "user25" },
                    { 26, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000026", null, null, null, "User 26", "password26", null, null, false, null, null, 1, null, null, null, "user26" },
                    { 27, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000027", null, null, null, "User 27", "password27", null, null, false, null, null, 2, null, null, null, "user27" },
                    { 28, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000028", null, null, null, "User 28", "password28", null, null, false, null, null, 1, null, null, null, "user28" },
                    { 29, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000029", null, null, null, "User 29", "password29", null, null, false, null, null, 2, null, null, null, "user29" },
                    { 30, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000030", null, null, null, "User 30", "password30", null, null, false, null, null, 1, null, null, null, "user30" },
                    { 31, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000031", null, null, null, "User 31", "password31", null, null, false, null, null, 2, null, null, null, "user31" },
                    { 32, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000032", null, null, null, "User 32", "password32", null, null, false, null, null, 1, null, null, null, "user32" },
                    { 33, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000033", null, null, null, "User 33", "password33", null, null, false, null, null, 2, null, null, null, "user33" },
                    { 34, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000034", null, null, null, "User 34", "password34", null, null, false, null, null, 1, null, null, null, "user34" },
                    { 35, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000035", null, null, null, "User 35", "password35", null, null, false, null, null, 2, null, null, null, "user35" },
                    { 36, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000036", null, null, null, "User 36", "password36", null, null, false, null, null, 1, null, null, null, "user36" },
                    { 37, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000037", null, null, null, "User 37", "password37", null, null, false, null, null, 2, null, null, null, "user37" },
                    { 38, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000038", null, null, null, "User 38", "password38", null, null, false, null, null, 1, null, null, null, "user38" },
                    { 39, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000039", null, null, null, "User 39", "password39", null, null, false, null, null, 2, null, null, null, "user39" },
                    { 40, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000040", null, null, null, "User 40", "password40", null, null, false, null, null, 1, null, null, null, "user40" },
                    { 41, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000041", null, null, null, "User 41", "password41", null, null, false, null, null, 2, null, null, null, "user41" },
                    { 42, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000042", null, null, null, "User 42", "password42", null, null, false, null, null, 1, null, null, null, "user42" },
                    { 43, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000043", null, null, null, "User 43", "password43", null, null, false, null, null, 2, null, null, null, "user43" },
                    { 44, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000044", null, null, null, "User 44", "password44", null, null, false, null, null, 1, null, null, null, "user44" },
                    { 45, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000045", null, null, null, "User 45", "password45", null, null, false, null, null, 2, null, null, null, "user45" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BankInfoId", "Birthday", "CitizenId", "Email", "FaceId", "InsuranceCode", "Name", "Password", "PhoneNumber", "RoleId", "Sex", "SocialInsuranceId", "TaxCode", "TeamId", "TokenSlack", "TokenTrello", "UrlImage", "Username" },
                values: new object[,]
                {
                    { 46, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000046", null, null, null, "User 46", "password46", null, null, false, null, null, 1, null, null, null, "user46" },
                    { 47, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000047", null, null, null, "User 47", "password47", null, null, false, null, null, 2, null, null, null, "user47" },
                    { 48, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000048", null, null, null, "User 48", "password48", null, null, false, null, null, 1, null, null, null, "user48" },
                    { 49, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000049", null, null, null, "User 49", "password49", null, null, false, null, null, 2, null, null, null, "user49" },
                    { 50, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000050", null, null, null, "User 50", "password50", null, null, false, null, null, 1, null, null, null, "user50" },
                    { 51, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000051", null, null, null, "User 51", "password51", null, null, false, null, null, 2, null, null, null, "user51" },
                    { 52, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000052", null, null, null, "User 52", "password52", null, null, false, null, null, 1, null, null, null, "user52" },
                    { 53, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000053", null, null, null, "User 53", "password53", null, null, false, null, null, 2, null, null, null, "user53" },
                    { 54, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000054", null, null, null, "User 54", "password54", null, null, false, null, null, 1, null, null, null, "user54" },
                    { 55, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000055", null, null, null, "User 55", "password55", null, null, false, null, null, 2, null, null, null, "user55" },
                    { 56, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000056", null, null, null, "User 56", "password56", null, null, false, null, null, 1, null, null, null, "user56" },
                    { 57, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000057", null, null, null, "User 57", "password57", null, null, false, null, null, 2, null, null, null, "user57" },
                    { 58, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000058", null, null, null, "User 58", "password58", null, null, false, null, null, 1, null, null, null, "user58" },
                    { 59, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000059", null, null, null, "User 59", "password59", null, null, false, null, null, 2, null, null, null, "user59" },
                    { 60, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000060", null, null, null, "User 60", "password60", null, null, false, null, null, 1, null, null, null, "user60" },
                    { 61, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000061", null, null, null, "User 61", "password61", null, null, false, null, null, 2, null, null, null, "user61" },
                    { 62, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000062", null, null, null, "User 62", "password62", null, null, false, null, null, 1, null, null, null, "user62" },
                    { 63, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000063", null, null, null, "User 63", "password63", null, null, false, null, null, 2, null, null, null, "user63" },
                    { 64, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000064", null, null, null, "User 64", "password64", null, null, false, null, null, 1, null, null, null, "user64" },
                    { 65, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000065", null, null, null, "User 65", "password65", null, null, false, null, null, 2, null, null, null, "user65" },
                    { 66, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000066", null, null, null, "User 66", "password66", null, null, false, null, null, 1, null, null, null, "user66" },
                    { 67, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000067", null, null, null, "User 67", "password67", null, null, false, null, null, 2, null, null, null, "user67" },
                    { 68, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000068", null, null, null, "User 68", "password68", null, null, false, null, null, 1, null, null, null, "user68" },
                    { 69, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000069", null, null, null, "User 69", "password69", null, null, false, null, null, 2, null, null, null, "user69" },
                    { 70, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000070", null, null, null, "User 70", "password70", null, null, false, null, null, 1, null, null, null, "user70" },
                    { 71, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000071", null, null, null, "User 71", "password71", null, null, false, null, null, 2, null, null, null, "user71" },
                    { 72, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000072", null, null, null, "User 72", "password72", null, null, false, null, null, 1, null, null, null, "user72" },
                    { 73, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000073", null, null, null, "User 73", "password73", null, null, false, null, null, 2, null, null, null, "user73" },
                    { 74, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000074", null, null, null, "User 74", "password74", null, null, false, null, null, 1, null, null, null, "user74" },
                    { 75, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000075", null, null, null, "User 75", "password75", null, null, false, null, null, 2, null, null, null, "user75" },
                    { 76, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000076", null, null, null, "User 76", "password76", null, null, false, null, null, 1, null, null, null, "user76" },
                    { 77, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000077", null, null, null, "User 77", "password77", null, null, false, null, null, 2, null, null, null, "user77" },
                    { 78, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000078", null, null, null, "User 78", "password78", null, null, false, null, null, 1, null, null, null, "user78" },
                    { 79, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000079", null, null, null, "User 79", "password79", null, null, false, null, null, 2, null, null, null, "user79" },
                    { 80, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000080", null, null, null, "User 80", "password80", null, null, false, null, null, 1, null, null, null, "user80" },
                    { 81, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000081", null, null, null, "User 81", "password81", null, null, false, null, null, 2, null, null, null, "user81" },
                    { 82, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000082", null, null, null, "User 82", "password82", null, null, false, null, null, 1, null, null, null, "user82" },
                    { 83, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000083", null, null, null, "User 83", "password83", null, null, false, null, null, 2, null, null, null, "user83" },
                    { 84, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000084", null, null, null, "User 84", "password84", null, null, false, null, null, 1, null, null, null, "user84" },
                    { 85, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000085", null, null, null, "User 85", "password85", null, null, false, null, null, 2, null, null, null, "user85" },
                    { 86, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000086", null, null, null, "User 86", "password86", null, null, false, null, null, 1, null, null, null, "user86" },
                    { 87, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000087", null, null, null, "User 87", "password87", null, null, false, null, null, 2, null, null, null, "user87" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BankInfoId", "Birthday", "CitizenId", "Email", "FaceId", "InsuranceCode", "Name", "Password", "PhoneNumber", "RoleId", "Sex", "SocialInsuranceId", "TaxCode", "TeamId", "TokenSlack", "TokenTrello", "UrlImage", "Username" },
                values: new object[,]
                {
                    { 88, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000088", null, null, null, "User 88", "password88", null, null, false, null, null, 1, null, null, null, "user88" },
                    { 89, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000089", null, null, null, "User 89", "password89", null, null, false, null, null, 2, null, null, null, "user89" },
                    { 90, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000090", null, null, null, "User 90", "password90", null, null, false, null, null, 1, null, null, null, "user90" },
                    { 91, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000091", null, null, null, "User 91", "password91", null, null, false, null, null, 2, null, null, null, "user91" },
                    { 92, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000092", null, null, null, "User 92", "password92", null, null, false, null, null, 1, null, null, null, "user92" },
                    { 93, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000093", null, null, null, "User 93", "password93", null, null, false, null, null, 2, null, null, null, "user93" },
                    { 94, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000094", null, null, null, "User 94", "password94", null, null, false, null, null, 1, null, null, null, "user94" },
                    { 95, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000095", null, null, null, "User 95", "password95", null, null, false, null, null, 2, null, null, null, "user95" },
                    { 96, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000096", null, null, null, "User 96", "password96", null, null, false, null, null, 1, null, null, null, "user96" },
                    { 97, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000097", null, null, null, "User 97", "password97", null, null, false, null, null, 2, null, null, null, "user97" },
                    { 98, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000098", null, null, null, "User 98", "password98", null, null, false, null, null, 1, null, null, null, "user98" },
                    { 99, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000099", null, null, null, "User 99", "password99", null, null, false, null, null, 2, null, null, null, "user99" },
                    { 100, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000100", null, null, null, "User 100", "password100", null, null, false, null, null, 1, null, null, null, "user100" },
                    { 101, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000101", null, null, null, "User 101", "password101", null, null, false, null, null, 2, null, null, null, "user101" },
                    { 102, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000102", null, null, null, "User 102", "password102", null, null, false, null, null, 1, null, null, null, "user102" },
                    { 103, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000103", null, null, null, "User 103", "password103", null, null, false, null, null, 2, null, null, null, "user103" },
                    { 104, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000104", null, null, null, "User 104", "password104", null, null, false, null, null, 1, null, null, null, "user104" },
                    { 105, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000105", null, null, null, "User 105", "password105", null, null, false, null, null, 2, null, null, null, "user105" },
                    { 106, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000106", null, null, null, "User 106", "password106", null, null, false, null, null, 1, null, null, null, "user106" },
                    { 107, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000107", null, null, null, "User 107", "password107", null, null, false, null, null, 2, null, null, null, "user107" },
                    { 108, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000108", null, null, null, "User 108", "password108", null, null, false, null, null, 1, null, null, null, "user108" },
                    { 109, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000109", null, null, null, "User 109", "password109", null, null, false, null, null, 2, null, null, null, "user109" },
                    { 110, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000110", null, null, null, "User 110", "password110", null, null, false, null, null, 1, null, null, null, "user110" },
                    { 111, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000111", null, null, null, "User 111", "password111", null, null, false, null, null, 2, null, null, null, "user111" },
                    { 112, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000112", null, null, null, "User 112", "password112", null, null, false, null, null, 1, null, null, null, "user112" },
                    { 113, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000113", null, null, null, "User 113", "password113", null, null, false, null, null, 2, null, null, null, "user113" },
                    { 114, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000114", null, null, null, "User 114", "password114", null, null, false, null, null, 1, null, null, null, "user114" },
                    { 115, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000115", null, null, null, "User 115", "password115", null, null, false, null, null, 2, null, null, null, "user115" },
                    { 116, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000116", null, null, null, "User 116", "password116", null, null, false, null, null, 1, null, null, null, "user116" },
                    { 117, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000117", null, null, null, "User 117", "password117", null, null, false, null, null, 2, null, null, null, "user117" },
                    { 118, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000118", null, null, null, "User 118", "password118", null, null, false, null, null, 1, null, null, null, "user118" },
                    { 119, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000119", null, null, null, "User 119", "password119", null, null, false, null, null, 2, null, null, null, "user119" },
                    { 120, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000120", null, null, null, "User 120", "password120", null, null, false, null, null, 1, null, null, null, "user120" },
                    { 121, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000121", null, null, null, "User 121", "password121", null, null, false, null, null, 2, null, null, null, "user121" },
                    { 122, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000122", null, null, null, "User 122", "password122", null, null, false, null, null, 1, null, null, null, "user122" },
                    { 123, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000123", null, null, null, "User 123", "password123", null, null, false, null, null, 2, null, null, null, "user123" },
                    { 124, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000124", null, null, null, "User 124", "password124", null, null, false, null, null, 1, null, null, null, "user124" },
                    { 125, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000125", null, null, null, "User 125", "password125", null, null, false, null, null, 2, null, null, null, "user125" },
                    { 126, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000126", null, null, null, "User 126", "password126", null, null, false, null, null, 1, null, null, null, "user126" },
                    { 127, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000127", null, null, null, "User 127", "password127", null, null, false, null, null, 2, null, null, null, "user127" },
                    { 128, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000128", null, null, null, "User 128", "password128", null, null, false, null, null, 1, null, null, null, "user128" },
                    { 129, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000129", null, null, null, "User 129", "password129", null, null, false, null, null, 2, null, null, null, "user129" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BankInfoId", "Birthday", "CitizenId", "Email", "FaceId", "InsuranceCode", "Name", "Password", "PhoneNumber", "RoleId", "Sex", "SocialInsuranceId", "TaxCode", "TeamId", "TokenSlack", "TokenTrello", "UrlImage", "Username" },
                values: new object[,]
                {
                    { 130, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000130", null, null, null, "User 130", "password130", null, null, false, null, null, 1, null, null, null, "user130" },
                    { 131, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000131", null, null, null, "User 131", "password131", null, null, false, null, null, 2, null, null, null, "user131" },
                    { 132, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000132", null, null, null, "User 132", "password132", null, null, false, null, null, 1, null, null, null, "user132" },
                    { 133, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000133", null, null, null, "User 133", "password133", null, null, false, null, null, 2, null, null, null, "user133" },
                    { 134, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000134", null, null, null, "User 134", "password134", null, null, false, null, null, 1, null, null, null, "user134" },
                    { 135, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000135", null, null, null, "User 135", "password135", null, null, false, null, null, 2, null, null, null, "user135" },
                    { 136, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000136", null, null, null, "User 136", "password136", null, null, false, null, null, 1, null, null, null, "user136" },
                    { 137, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000137", null, null, null, "User 137", "password137", null, null, false, null, null, 2, null, null, null, "user137" },
                    { 138, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000138", null, null, null, "User 138", "password138", null, null, false, null, null, 1, null, null, null, "user138" },
                    { 139, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000139", null, null, null, "User 139", "password139", null, null, false, null, null, 2, null, null, null, "user139" },
                    { 140, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000140", null, null, null, "User 140", "password140", null, null, false, null, null, 1, null, null, null, "user140" },
                    { 141, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000141", null, null, null, "User 141", "password141", null, null, false, null, null, 2, null, null, null, "user141" },
                    { 142, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000142", null, null, null, "User 142", "password142", null, null, false, null, null, 1, null, null, null, "user142" },
                    { 143, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000143", null, null, null, "User 143", "password143", null, null, false, null, null, 2, null, null, null, "user143" },
                    { 144, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000144", null, null, null, "User 144", "password144", null, null, false, null, null, 1, null, null, null, "user144" },
                    { 145, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000145", null, null, null, "User 145", "password145", null, null, false, null, null, 2, null, null, null, "user145" },
                    { 146, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000146", null, null, null, "User 146", "password146", null, null, false, null, null, 1, null, null, null, "user146" },
                    { 147, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000147", null, null, null, "User 147", "password147", null, null, false, null, null, 2, null, null, null, "user147" },
                    { 148, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000148", null, null, null, "User 148", "password148", null, null, false, null, null, 1, null, null, null, "user148" },
                    { 149, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000149", null, null, null, "User 149", "password149", null, null, false, null, null, 2, null, null, null, "user149" },
                    { 150, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000150", null, null, null, "User 150", "password150", null, null, false, null, null, 1, null, null, null, "user150" },
                    { 151, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000151", null, null, null, "User 151", "password151", null, null, false, null, null, 2, null, null, null, "user151" },
                    { 152, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000152", null, null, null, "User 152", "password152", null, null, false, null, null, 1, null, null, null, "user152" },
                    { 153, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000153", null, null, null, "User 153", "password153", null, null, false, null, null, 2, null, null, null, "user153" },
                    { 154, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000154", null, null, null, "User 154", "password154", null, null, false, null, null, 1, null, null, null, "user154" },
                    { 155, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000155", null, null, null, "User 155", "password155", null, null, false, null, null, 2, null, null, null, "user155" },
                    { 156, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000156", null, null, null, "User 156", "password156", null, null, false, null, null, 1, null, null, null, "user156" },
                    { 157, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000157", null, null, null, "User 157", "password157", null, null, false, null, null, 2, null, null, null, "user157" },
                    { 158, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000158", null, null, null, "User 158", "password158", null, null, false, null, null, 1, null, null, null, "user158" },
                    { 159, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000159", null, null, null, "User 159", "password159", null, null, false, null, null, 2, null, null, null, "user159" },
                    { 160, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000160", null, null, null, "User 160", "password160", null, null, false, null, null, 1, null, null, null, "user160" },
                    { 161, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000161", null, null, null, "User 161", "password161", null, null, false, null, null, 2, null, null, null, "user161" },
                    { 162, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000162", null, null, null, "User 162", "password162", null, null, false, null, null, 1, null, null, null, "user162" },
                    { 163, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000163", null, null, null, "User 163", "password163", null, null, false, null, null, 2, null, null, null, "user163" },
                    { 164, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000164", null, null, null, "User 164", "password164", null, null, false, null, null, 1, null, null, null, "user164" },
                    { 165, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000165", null, null, null, "User 165", "password165", null, null, false, null, null, 2, null, null, null, "user165" },
                    { 166, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000166", null, null, null, "User 166", "password166", null, null, false, null, null, 1, null, null, null, "user166" },
                    { 167, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000167", null, null, null, "User 167", "password167", null, null, false, null, null, 2, null, null, null, "user167" },
                    { 168, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000168", null, null, null, "User 168", "password168", null, null, false, null, null, 1, null, null, null, "user168" },
                    { 169, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000169", null, null, null, "User 169", "password169", null, null, false, null, null, 2, null, null, null, "user169" },
                    { 170, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000170", null, null, null, "User 170", "password170", null, null, false, null, null, 1, null, null, null, "user170" },
                    { 171, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000171", null, null, null, "User 171", "password171", null, null, false, null, null, 2, null, null, null, "user171" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BankInfoId", "Birthday", "CitizenId", "Email", "FaceId", "InsuranceCode", "Name", "Password", "PhoneNumber", "RoleId", "Sex", "SocialInsuranceId", "TaxCode", "TeamId", "TokenSlack", "TokenTrello", "UrlImage", "Username" },
                values: new object[,]
                {
                    { 172, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000172", null, null, null, "User 172", "password172", null, null, false, null, null, 1, null, null, null, "user172" },
                    { 173, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000173", null, null, null, "User 173", "password173", null, null, false, null, null, 2, null, null, null, "user173" },
                    { 174, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000174", null, null, null, "User 174", "password174", null, null, false, null, null, 1, null, null, null, "user174" },
                    { 175, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000175", null, null, null, "User 175", "password175", null, null, false, null, null, 2, null, null, null, "user175" },
                    { 176, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000176", null, null, null, "User 176", "password176", null, null, false, null, null, 1, null, null, null, "user176" },
                    { 177, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000177", null, null, null, "User 177", "password177", null, null, false, null, null, 2, null, null, null, "user177" },
                    { 178, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000178", null, null, null, "User 178", "password178", null, null, false, null, null, 1, null, null, null, "user178" },
                    { 179, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000179", null, null, null, "User 179", "password179", null, null, false, null, null, 2, null, null, null, "user179" },
                    { 180, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000180", null, null, null, "User 180", "password180", null, null, false, null, null, 1, null, null, null, "user180" },
                    { 181, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000181", null, null, null, "User 181", "password181", null, null, false, null, null, 2, null, null, null, "user181" },
                    { 182, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000182", null, null, null, "User 182", "password182", null, null, false, null, null, 1, null, null, null, "user182" },
                    { 183, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000183", null, null, null, "User 183", "password183", null, null, false, null, null, 2, null, null, null, "user183" },
                    { 184, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000184", null, null, null, "User 184", "password184", null, null, false, null, null, 1, null, null, null, "user184" },
                    { 185, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000185", null, null, null, "User 185", "password185", null, null, false, null, null, 2, null, null, null, "user185" },
                    { 186, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000186", null, null, null, "User 186", "password186", null, null, false, null, null, 1, null, null, null, "user186" },
                    { 187, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000187", null, null, null, "User 187", "password187", null, null, false, null, null, 2, null, null, null, "user187" },
                    { 188, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000188", null, null, null, "User 188", "password188", null, null, false, null, null, 1, null, null, null, "user188" },
                    { 189, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000189", null, null, null, "User 189", "password189", null, null, false, null, null, 2, null, null, null, "user189" },
                    { 190, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000190", null, null, null, "User 190", "password190", null, null, false, null, null, 1, null, null, null, "user190" },
                    { 191, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000191", null, null, null, "User 191", "password191", null, null, false, null, null, 2, null, null, null, "user191" },
                    { 192, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000192", null, null, null, "User 192", "password192", null, null, false, null, null, 1, null, null, null, "user192" },
                    { 193, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000193", null, null, null, "User 193", "password193", null, null, false, null, null, 2, null, null, null, "user193" },
                    { 194, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000194", null, null, null, "User 194", "password194", null, null, false, null, null, 1, null, null, null, "user194" },
                    { 195, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000195", null, null, null, "User 195", "password195", null, null, false, null, null, 2, null, null, null, "user195" },
                    { 196, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000196", null, null, null, "User 196", "password196", null, null, false, null, null, 1, null, null, null, "user196" },
                    { 197, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000197", null, null, null, "User 197", "password197", null, null, false, null, null, 2, null, null, null, "user197" },
                    { 198, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000198", null, null, null, "User 198", "password198", null, null, false, null, null, 1, null, null, null, "user198" },
                    { 199, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000199", null, null, null, "User 199", "password199", null, null, false, null, null, 2, null, null, null, "user199" },
                    { 200, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000200", null, null, null, "User 200", "password200", null, null, false, null, null, 1, null, null, null, "user200" },
                    { 201, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000201", null, null, null, "User 201", "password201", null, null, false, null, null, 2, null, null, null, "user201" },
                    { 202, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000202", null, null, null, "User 202", "password202", null, null, false, null, null, 1, null, null, null, "user202" },
                    { 203, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000203", null, null, null, "User 203", "password203", null, null, false, null, null, 2, null, null, null, "user203" },
                    { 204, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000204", null, null, null, "User 204", "password204", null, null, false, null, null, 1, null, null, null, "user204" },
                    { 205, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000205", null, null, null, "User 205", "password205", null, null, false, null, null, 2, null, null, null, "user205" },
                    { 206, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000206", null, null, null, "User 206", "password206", null, null, false, null, null, 1, null, null, null, "user206" },
                    { 207, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000207", null, null, null, "User 207", "password207", null, null, false, null, null, 2, null, null, null, "user207" },
                    { 208, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000208", null, null, null, "User 208", "password208", null, null, false, null, null, 1, null, null, null, "user208" },
                    { 209, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000209", null, null, null, "User 209", "password209", null, null, false, null, null, 2, null, null, null, "user209" },
                    { 210, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000210", null, null, null, "User 210", "password210", null, null, false, null, null, 1, null, null, null, "user210" },
                    { 211, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000211", null, null, null, "User 211", "password211", null, null, false, null, null, 2, null, null, null, "user211" },
                    { 212, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000212", null, null, null, "User 212", "password212", null, null, false, null, null, 1, null, null, null, "user212" },
                    { 213, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000213", null, null, null, "User 213", "password213", null, null, false, null, null, 2, null, null, null, "user213" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BankInfoId", "Birthday", "CitizenId", "Email", "FaceId", "InsuranceCode", "Name", "Password", "PhoneNumber", "RoleId", "Sex", "SocialInsuranceId", "TaxCode", "TeamId", "TokenSlack", "TokenTrello", "UrlImage", "Username" },
                values: new object[,]
                {
                    { 214, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000214", null, null, null, "User 214", "password214", null, null, false, null, null, 1, null, null, null, "user214" },
                    { 215, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000215", null, null, null, "User 215", "password215", null, null, false, null, null, 2, null, null, null, "user215" },
                    { 216, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000216", null, null, null, "User 216", "password216", null, null, false, null, null, 1, null, null, null, "user216" },
                    { 217, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000217", null, null, null, "User 217", "password217", null, null, false, null, null, 2, null, null, null, "user217" },
                    { 218, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000218", null, null, null, "User 218", "password218", null, null, false, null, null, 1, null, null, null, "user218" },
                    { 219, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000219", null, null, null, "User 219", "password219", null, null, false, null, null, 2, null, null, null, "user219" },
                    { 220, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000220", null, null, null, "User 220", "password220", null, null, false, null, null, 1, null, null, null, "user220" },
                    { 221, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000221", null, null, null, "User 221", "password221", null, null, false, null, null, 2, null, null, null, "user221" },
                    { 222, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000222", null, null, null, "User 222", "password222", null, null, false, null, null, 1, null, null, null, "user222" },
                    { 223, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000223", null, null, null, "User 223", "password223", null, null, false, null, null, 2, null, null, null, "user223" },
                    { 224, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000224", null, null, null, "User 224", "password224", null, null, false, null, null, 1, null, null, null, "user224" },
                    { 225, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000225", null, null, null, "User 225", "password225", null, null, false, null, null, 2, null, null, null, "user225" },
                    { 226, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000226", null, null, null, "User 226", "password226", null, null, false, null, null, 1, null, null, null, "user226" },
                    { 227, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000227", null, null, null, "User 227", "password227", null, null, false, null, null, 2, null, null, null, "user227" },
                    { 228, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000228", null, null, null, "User 228", "password228", null, null, false, null, null, 1, null, null, null, "user228" },
                    { 229, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000229", null, null, null, "User 229", "password229", null, null, false, null, null, 2, null, null, null, "user229" },
                    { 230, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000230", null, null, null, "User 230", "password230", null, null, false, null, null, 1, null, null, null, "user230" },
                    { 231, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000231", null, null, null, "User 231", "password231", null, null, false, null, null, 2, null, null, null, "user231" },
                    { 232, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000232", null, null, null, "User 232", "password232", null, null, false, null, null, 1, null, null, null, "user232" },
                    { 233, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000233", null, null, null, "User 233", "password233", null, null, false, null, null, 2, null, null, null, "user233" },
                    { 234, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000234", null, null, null, "User 234", "password234", null, null, false, null, null, 1, null, null, null, "user234" },
                    { 235, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000235", null, null, null, "User 235", "password235", null, null, false, null, null, 2, null, null, null, "user235" },
                    { 236, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000236", null, null, null, "User 236", "password236", null, null, false, null, null, 1, null, null, null, "user236" },
                    { 237, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000237", null, null, null, "User 237", "password237", null, null, false, null, null, 2, null, null, null, "user237" },
                    { 238, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000238", null, null, null, "User 238", "password238", null, null, false, null, null, 1, null, null, null, "user238" },
                    { 239, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000239", null, null, null, "User 239", "password239", null, null, false, null, null, 2, null, null, null, "user239" },
                    { 240, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000240", null, null, null, "User 240", "password240", null, null, false, null, null, 1, null, null, null, "user240" },
                    { 241, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000241", null, null, null, "User 241", "password241", null, null, false, null, null, 2, null, null, null, "user241" },
                    { 242, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000242", null, null, null, "User 242", "password242", null, null, false, null, null, 1, null, null, null, "user242" },
                    { 243, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "000000243", null, null, null, "User 243", "password243", null, null, false, null, null, 2, null, null, null, "user243" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstantFormula_FormulasId",
                table: "ConstantFormula",
                column: "FormulasId");

            migrationBuilder.CreateIndex(
                name: "IX_DeductionAllowanceBonus_TemplateId",
                table: "DeductionAllowanceBonus",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DeductionAllowanceBonusTemplate_FormulaId",
                table: "DeductionAllowanceBonusTemplate",
                column: "FormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_DeductionAllowanceBonusUser_UsersId",
                table: "DeductionAllowanceBonusUser",
                column: "UsersId");

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
                name: "IX_FormulaInput_InputsId",
                table: "FormulaInput",
                column: "InputsId");

            migrationBuilder.CreateIndex(
                name: "IX_Payslip_EmployeeId",
                table: "Payslip",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                table: "RolePermission",
                column: "RoleId");

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
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Workday_UserId",
                table: "Workday",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeductionAllowanceBonusUser_Users_UsersId",
                table: "DeductionAllowanceBonusUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_ManagerId",
                table: "Departments",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payslip_Users_EmployeeId",
                table: "Payslip",
                column: "EmployeeId",
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
                name: "ConstantFormula");

            migrationBuilder.DropTable(
                name: "DeductionAllowanceBonusUser");

            migrationBuilder.DropTable(
                name: "FormulaInput");

            migrationBuilder.DropTable(
                name: "Payslip");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "Workday");

            migrationBuilder.DropTable(
                name: "Constant");

            migrationBuilder.DropTable(
                name: "DeductionAllowanceBonus");

            migrationBuilder.DropTable(
                name: "Input");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "DeductionAllowanceBonusTemplate");

            migrationBuilder.DropTable(
                name: "Formula");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BankInfo");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
