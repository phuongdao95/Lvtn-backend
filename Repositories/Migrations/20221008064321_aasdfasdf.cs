using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class aasdfasdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingShiftTimekeepings_Users_EmployeeId",
                table: "WorkingShiftTimekeepings");

            migrationBuilder.DropColumn(
                name: "WorkingShiftEventId",
                table: "PayslipWorkingShiftTimekeeping");

            migrationBuilder.RenameColumn(
                name: "Formula",
                table: "WorkingShiftEvents",
                newName: "FormulaName");

            migrationBuilder.RenameColumn(
                name: "Formula",
                table: "SalaryDeltas",
                newName: "FormulaName");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "WorkingShiftTimekeepings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "SalaryDeltas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "SalaryDeltas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FormulaName",
                value: "formula_2");

            migrationBuilder.UpdateData(
                table: "SalaryDeltas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FormulaName",
                value: "formula_3");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 4,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 5,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 6,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 7,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 8,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 9,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 10,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 11,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 12,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 13,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 14,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 15,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 16,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 17,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 18,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 19,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 20,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 21,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 22,
                column: "FormulaName",
                value: "formula_1");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingShiftTimekeepings_Users_EmployeeId",
                table: "WorkingShiftTimekeepings",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingShiftTimekeepings_Users_EmployeeId",
                table: "WorkingShiftTimekeepings");

            migrationBuilder.RenameColumn(
                name: "FormulaName",
                table: "WorkingShiftEvents",
                newName: "Formula");

            migrationBuilder.RenameColumn(
                name: "FormulaName",
                table: "SalaryDeltas",
                newName: "Formula");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "WorkingShiftTimekeepings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkingShiftEventId",
                table: "PayslipWorkingShiftTimekeeping",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SalaryDeltas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Formula",
                value: "variable_1");

            migrationBuilder.UpdateData(
                table: "SalaryDeltas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Formula",
                value: "variable_2");

            migrationBuilder.UpdateData(
                table: "SalaryDeltas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Formula",
                value: "variable_3");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 4,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 5,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 6,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 7,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 8,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 9,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 10,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 11,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 12,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 13,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 14,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 15,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 16,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 17,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 18,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 19,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 20,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 21,
                column: "Formula",
                value: "2");

            migrationBuilder.UpdateData(
                table: "WorkingShiftEvents",
                keyColumn: "Id",
                keyValue: 22,
                column: "Formula",
                value: "2");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingShiftTimekeepings_Users_EmployeeId",
                table: "WorkingShiftTimekeepings",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
