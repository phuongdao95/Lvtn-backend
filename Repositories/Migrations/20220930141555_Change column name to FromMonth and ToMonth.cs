using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class ChangecolumnnametoFromMonthandToMonth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToDate",
                table: "SalaryDeltas",
                newName: "ToMonth");

            migrationBuilder.RenameColumn(
                name: "FromDate",
                table: "SalaryDeltas",
                newName: "FromMonth");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToMonth",
                table: "SalaryDeltas",
                newName: "ToDate");

            migrationBuilder.RenameColumn(
                name: "FromMonth",
                table: "SalaryDeltas",
                newName: "FromDate");
        }
    }
}
