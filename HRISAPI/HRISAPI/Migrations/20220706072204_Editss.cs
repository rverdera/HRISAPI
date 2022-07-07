using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRISAPI.Migrations
{
    public partial class Editss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "PDS",
                table: "Person",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "FM",
                table: "CivilStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "FM",
                table: "BloodType",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "PDS",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "FM",
                table: "CivilStatus");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "FM",
                table: "BloodType");
        }
    }
}
