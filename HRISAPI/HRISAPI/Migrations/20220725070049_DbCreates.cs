using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRISAPI.Migrations
{
    public partial class DbCreates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PIM");

            migrationBuilder.RenameTable(
                name: "Person",
                schema: "PDS",
                newName: "Person",
                newSchema: "PIM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PDS");

            migrationBuilder.RenameTable(
                name: "Person",
                schema: "PIM",
                newName: "Person",
                newSchema: "PDS");
        }
    }
}
