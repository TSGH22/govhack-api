using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovHack22API.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Location",
                type: "double",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Location",
                type: "double",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Longitude",
                table: "Location",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<float>(
                name: "Latitude",
                table: "Location",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
