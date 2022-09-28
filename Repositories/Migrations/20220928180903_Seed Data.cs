using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SDFormula_SDFormulaConstant");

            migrationBuilder.DropTable(
                name: "SDFormula_SDFormulaInput");

            migrationBuilder.DropTable(
                name: "Workday");

            migrationBuilder.DropTable(
                name: "SDFormulaConstant");

            migrationBuilder.DropTable(
                name: "SDFormulaInput");

            migrationBuilder.DropColumn(
                name: "FormulaDataType",
                table: "SDFormulas");

            migrationBuilder.AddColumn<decimal>(
                name: "BaseSalary",
                table: "Users",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "SDFormulaConstants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDFormulaConstants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingShiftType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Coeficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingShiftType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryDeltaFormula_SalaryDeltaVariable",
                columns: table => new
                {
                    SalaryDeltaFormulaId = table.Column<int>(type: "int", nullable: false),
                    SalaryDeltaVariableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryDeltaFormula_SalaryDeltaVariable", x => new { x.SalaryDeltaFormulaId, x.SalaryDeltaVariableId });
                    table.ForeignKey(
                        name: "FK_SalaryDeltaFormula_SalaryDeltaVariable_SDFormulaConstants_SalaryDeltaFormulaId",
                        column: x => x.SalaryDeltaFormulaId,
                        principalTable: "SDFormulaConstants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryDeltaFormula_SalaryDeltaVariable_SDFormulas_SalaryDeltaVariableId",
                        column: x => x.SalaryDeltaVariableId,
                        principalTable: "SDFormulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingShift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IsCheckIn = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkingShiftTypeId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingShift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingShift_Users_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingShift_Users_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkingShift_WorkingShiftType_WorkingShiftTypeId",
                        column: x => x.WorkingShiftTypeId,
                        principalTable: "WorkingShiftType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaryDeltaFormula_SalaryDeltaVariable_SalaryDeltaVariableId",
                table: "SalaryDeltaFormula_SalaryDeltaVariable",
                column: "SalaryDeltaVariableId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingShift_EmployeeId",
                table: "WorkingShift",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingShift_EmployeeId1",
                table: "WorkingShift",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingShift_WorkingShiftTypeId",
                table: "WorkingShift",
                column: "WorkingShiftTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryDeltaFormula_SalaryDeltaVariable");

            migrationBuilder.DropTable(
                name: "WorkingShift");

            migrationBuilder.DropTable(
                name: "SDFormulaConstants");

            migrationBuilder.DropTable(
                name: "WorkingShiftType");

            migrationBuilder.DropColumn(
                name: "BaseSalary",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "FormulaDataType",
                table: "SDFormulas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SDFormulaConstant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDFormulaConstant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SDFormulaInput",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColumnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDFormulaInput", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckAt = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "SDFormula_SDFormulaConstant",
                columns: table => new
                {
                    SDFormulaConstantId = table.Column<int>(type: "int", nullable: false),
                    SDFormulaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDFormula_SDFormulaConstant", x => new { x.SDFormulaConstantId, x.SDFormulaId });
                    table.ForeignKey(
                        name: "FK_SDFormula_SDFormulaConstant_SDFormulaConstant_SDFormulaConstantId",
                        column: x => x.SDFormulaConstantId,
                        principalTable: "SDFormulaConstant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SDFormula_SDFormulaConstant_SDFormulas_SDFormulaId",
                        column: x => x.SDFormulaId,
                        principalTable: "SDFormulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SDFormula_SDFormulaInput",
                columns: table => new
                {
                    SDFormulaInputId = table.Column<int>(type: "int", nullable: false),
                    SDFormulaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDFormula_SDFormulaInput", x => new { x.SDFormulaInputId, x.SDFormulaId });
                    table.ForeignKey(
                        name: "FK_SDFormula_SDFormulaInput_SDFormulaInput_SDFormulaInputId",
                        column: x => x.SDFormulaInputId,
                        principalTable: "SDFormulaInput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SDFormula_SDFormulaInput_SDFormulas_SDFormulaId",
                        column: x => x.SDFormulaId,
                        principalTable: "SDFormulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SDFormula_SDFormulaConstant_SDFormulaId",
                table: "SDFormula_SDFormulaConstant",
                column: "SDFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_SDFormula_SDFormulaInput_SDFormulaId",
                table: "SDFormula_SDFormulaInput",
                column: "SDFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_Workday_UserId",
                table: "Workday",
                column: "UserId");
        }
    }
}
