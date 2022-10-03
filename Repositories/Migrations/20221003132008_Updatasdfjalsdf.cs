using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class Updatasdfjalsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayslipSalaryDelta_Payslips_PayslipId",
                table: "PayslipSalaryDelta");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingShiftTimekeepings_Payslips_PayslipId",
                table: "WorkingShiftTimekeepings");

            migrationBuilder.DropIndex(
                name: "IX_WorkingShiftTimekeepings_PayslipId",
                table: "WorkingShiftTimekeepings");

            migrationBuilder.DropColumn(
                name: "PayslipId",
                table: "WorkingShiftTimekeepings");

            migrationBuilder.CreateTable(
                name: "PayslipWorkingShiftTimekeeping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DidCheckIn = table.Column<bool>(type: "bit", nullable: false),
                    CheckinTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DidCheckout = table.Column<bool>(type: "bit", nullable: false),
                    CheckoutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkingShiftEventId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayslipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayslipWorkingShiftTimekeeping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayslipWorkingShiftTimekeeping_Payslips_PayslipId",
                        column: x => x.PayslipId,
                        principalTable: "Payslips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayslipWorkingShiftTimekeeping_PayslipId",
                table: "PayslipWorkingShiftTimekeeping",
                column: "PayslipId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayslipSalaryDelta_Payslips_PayslipId",
                table: "PayslipSalaryDelta",
                column: "PayslipId",
                principalTable: "Payslips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayslipSalaryDelta_Payslips_PayslipId",
                table: "PayslipSalaryDelta");

            migrationBuilder.DropTable(
                name: "PayslipWorkingShiftTimekeeping");

            migrationBuilder.AddColumn<int>(
                name: "PayslipId",
                table: "WorkingShiftTimekeepings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkingShiftTimekeepings_PayslipId",
                table: "WorkingShiftTimekeepings",
                column: "PayslipId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayslipSalaryDelta_Payslips_PayslipId",
                table: "PayslipSalaryDelta",
                column: "PayslipId",
                principalTable: "Payslips",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingShiftTimekeepings_Payslips_PayslipId",
                table: "WorkingShiftTimekeepings",
                column: "PayslipId",
                principalTable: "Payslips",
                principalColumn: "Id");
        }
    }
}
