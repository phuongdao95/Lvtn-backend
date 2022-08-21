using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lvtn_backend.Migrations
{
    public partial class AddTablesForSalaryFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
