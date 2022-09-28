using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class ApplySalaryManagementModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstantFormula");

            migrationBuilder.DropTable(
                name: "DeductionAllowanceBonusUser");

            migrationBuilder.DropTable(
                name: "FormulaInput");

            migrationBuilder.DropTable(
                name: "Constant");

            migrationBuilder.DropTable(
                name: "DeductionAllowanceBonus");

            migrationBuilder.DropTable(
                name: "Input");

            migrationBuilder.DropTable(
                name: "DeductionAllowanceBonusTemplate");

            migrationBuilder.DropTable(
                name: "Formula");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "Payslip");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "Payslip");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BaseSalary",
                table: "Payslip",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "PayrollId",
                table: "Payslip",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payroll",
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
                    table.PrimaryKey("PK_Payroll", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SDFormula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Define = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDFormula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SDFormulaConstant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<int>(type: "int", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDFormulaInput", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryDelta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormulaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryDelta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryDelta_SDFormula_FormulaId",
                        column: x => x.FormulaId,
                        principalTable: "SDFormula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_SDFormula_SDFormulaConstant_SDFormula_SDFormulaId",
                        column: x => x.SDFormulaId,
                        principalTable: "SDFormula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SDFormula_SDFormulaConstant_SDFormulaConstant_SDFormulaConstantId",
                        column: x => x.SDFormulaConstantId,
                        principalTable: "SDFormulaConstant",
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
                        name: "FK_SDFormula_SDFormulaInput_SDFormula_SDFormulaId",
                        column: x => x.SDFormulaId,
                        principalTable: "SDFormula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SDFormula_SDFormulaInput_SDFormulaInput_SDFormulaInputId",
                        column: x => x.SDFormulaInputId,
                        principalTable: "SDFormulaInput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryDeltaUser",
                columns: table => new
                {
                    SalaryDeltaListId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryDeltaUser", x => new { x.SalaryDeltaListId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_SalaryDeltaUser_SalaryDelta_SalaryDeltaListId",
                        column: x => x.SalaryDeltaListId,
                        principalTable: "SalaryDelta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryDeltaUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payslip_PayrollId",
                table: "Payslip",
                column: "PayrollId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryDelta_FormulaId",
                table: "SalaryDelta",
                column: "FormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryDeltaUser_UsersId",
                table: "SalaryDeltaUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_SDFormula_SDFormulaConstant_SDFormulaId",
                table: "SDFormula_SDFormulaConstant",
                column: "SDFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_SDFormula_SDFormulaInput_SDFormulaId",
                table: "SDFormula_SDFormulaInput",
                column: "SDFormulaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payslip_Payroll_PayrollId",
                table: "Payslip",
                column: "PayrollId",
                principalTable: "Payroll",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payslip_Payroll_PayrollId",
                table: "Payslip");

            migrationBuilder.DropTable(
                name: "Payroll");

            migrationBuilder.DropTable(
                name: "SalaryDeltaUser");

            migrationBuilder.DropTable(
                name: "SDFormula_SDFormulaConstant");

            migrationBuilder.DropTable(
                name: "SDFormula_SDFormulaInput");

            migrationBuilder.DropTable(
                name: "SalaryDelta");

            migrationBuilder.DropTable(
                name: "SDFormulaConstant");

            migrationBuilder.DropTable(
                name: "SDFormulaInput");

            migrationBuilder.DropTable(
                name: "SDFormula");

            migrationBuilder.DropIndex(
                name: "IX_Payslip_PayrollId",
                table: "Payslip");

            migrationBuilder.DropColumn(
                name: "PayrollId",
                table: "Payslip");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BaseSalary",
                table: "Payslip",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "Payslip",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "Payslip",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Constant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Define = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    DataType = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Input", x => x.Id);
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
                    ApplyType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
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
                name: "DeductionAllowanceBonus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_DeductionAllowanceBonusUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_FormulaInput_InputsId",
                table: "FormulaInput",
                column: "InputsId");
        }
    }
}
