using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class SeedData123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payslip_Payroll_PayrollId",
                table: "Payslip");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaryDelta_SDFormula_FormulaId",
                table: "SalaryDelta");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaryDeltaUser_SalaryDelta_SalaryDeltaListId",
                table: "SalaryDeltaUser");

            migrationBuilder.DropForeignKey(
                name: "FK_SDFormula_SDFormulaConstant_SDFormula_SDFormulaId",
                table: "SDFormula_SDFormulaConstant");

            migrationBuilder.DropForeignKey(
                name: "FK_SDFormula_SDFormulaInput_SDFormula_SDFormulaId",
                table: "SDFormula_SDFormulaInput");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SDFormula",
                table: "SDFormula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalaryDelta",
                table: "SalaryDelta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payroll",
                table: "Payroll");

            migrationBuilder.DropColumn(
                name: "FieldName",
                table: "SDFormulaInput");

            migrationBuilder.RenameTable(
                name: "SDFormula",
                newName: "SDFormulas");

            migrationBuilder.RenameTable(
                name: "SalaryDelta",
                newName: "SalaryDeltas");

            migrationBuilder.RenameTable(
                name: "Payroll",
                newName: "Payrolls");

            migrationBuilder.RenameIndex(
                name: "IX_SalaryDelta_FormulaId",
                table: "SalaryDeltas",
                newName: "IX_SalaryDeltas_FormulaId");

            migrationBuilder.AlterColumn<string>(
                name: "TableName",
                table: "SDFormulaInput",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SDFormulaInput",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ColumnName",
                table: "SDFormulaInput",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SDFormulaInput",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SDFormulaConstant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SDFormulaConstant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "SDFormulaConstant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormulaDataType",
                table: "SDFormulas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SDFormulas",
                table: "SDFormulas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalaryDeltas",
                table: "SalaryDeltas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payrolls",
                table: "Payrolls",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payslip_Payrolls_PayrollId",
                table: "Payslip",
                column: "PayrollId",
                principalTable: "Payrolls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryDeltas_SDFormulas_FormulaId",
                table: "SalaryDeltas",
                column: "FormulaId",
                principalTable: "SDFormulas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryDeltaUser_SalaryDeltas_SalaryDeltaListId",
                table: "SalaryDeltaUser",
                column: "SalaryDeltaListId",
                principalTable: "SalaryDeltas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SDFormula_SDFormulaConstant_SDFormulas_SDFormulaId",
                table: "SDFormula_SDFormulaConstant",
                column: "SDFormulaId",
                principalTable: "SDFormulas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SDFormula_SDFormulaInput_SDFormulas_SDFormulaId",
                table: "SDFormula_SDFormulaInput",
                column: "SDFormulaId",
                principalTable: "SDFormulas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payslip_Payrolls_PayrollId",
                table: "Payslip");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaryDeltas_SDFormulas_FormulaId",
                table: "SalaryDeltas");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaryDeltaUser_SalaryDeltas_SalaryDeltaListId",
                table: "SalaryDeltaUser");

            migrationBuilder.DropForeignKey(
                name: "FK_SDFormula_SDFormulaConstant_SDFormulas_SDFormulaId",
                table: "SDFormula_SDFormulaConstant");

            migrationBuilder.DropForeignKey(
                name: "FK_SDFormula_SDFormulaInput_SDFormulas_SDFormulaId",
                table: "SDFormula_SDFormulaInput");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SDFormulas",
                table: "SDFormulas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalaryDeltas",
                table: "SalaryDeltas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payrolls",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "ColumnName",
                table: "SDFormulaInput");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SDFormulaInput");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SDFormulaConstant");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "SDFormulaConstant");

            migrationBuilder.DropColumn(
                name: "FormulaDataType",
                table: "SDFormulas");

            migrationBuilder.RenameTable(
                name: "SDFormulas",
                newName: "SDFormula");

            migrationBuilder.RenameTable(
                name: "SalaryDeltas",
                newName: "SalaryDelta");

            migrationBuilder.RenameTable(
                name: "Payrolls",
                newName: "Payroll");

            migrationBuilder.RenameIndex(
                name: "IX_SalaryDeltas_FormulaId",
                table: "SalaryDelta",
                newName: "IX_SalaryDelta_FormulaId");

            migrationBuilder.AlterColumn<string>(
                name: "TableName",
                table: "SDFormulaInput",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SDFormulaInput",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldName",
                table: "SDFormulaInput",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SDFormulaConstant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SDFormula",
                table: "SDFormula",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalaryDelta",
                table: "SalaryDelta",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payroll",
                table: "Payroll",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payslip_Payroll_PayrollId",
                table: "Payslip",
                column: "PayrollId",
                principalTable: "Payroll",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryDelta_SDFormula_FormulaId",
                table: "SalaryDelta",
                column: "FormulaId",
                principalTable: "SDFormula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryDeltaUser_SalaryDelta_SalaryDeltaListId",
                table: "SalaryDeltaUser",
                column: "SalaryDeltaListId",
                principalTable: "SalaryDelta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SDFormula_SDFormulaConstant_SDFormula_SDFormulaId",
                table: "SDFormula_SDFormulaConstant",
                column: "SDFormulaId",
                principalTable: "SDFormula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SDFormula_SDFormulaInput_SDFormula_SDFormulaId",
                table: "SDFormula_SDFormulaInput",
                column: "SDFormulaId",
                principalTable: "SDFormula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
