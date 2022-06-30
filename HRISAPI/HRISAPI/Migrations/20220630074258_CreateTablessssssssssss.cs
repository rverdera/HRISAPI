using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRISAPI.Migrations
{
    public partial class CreateTablessssssssssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateStamp",
                schema: "PDS",
                table: "Person",
                newName: "DateTimeStamp");

            migrationBuilder.RenameColumn(
                name: "DateStamp",
                schema: "FM",
                table: "CivilStatus",
                newName: "DateTimeStamp");

            migrationBuilder.RenameColumn(
                name: "DateStamp",
                schema: "FM",
                table: "BloodType",
                newName: "DateTimeStamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeStamp",
                schema: "PDS",
                table: "Person",
                newName: "DateStamp");

            migrationBuilder.RenameColumn(
                name: "DateTimeStamp",
                schema: "FM",
                table: "CivilStatus",
                newName: "DateStamp");

            migrationBuilder.RenameColumn(
                name: "DateTimeStamp",
                schema: "FM",
                table: "BloodType",
                newName: "DateStamp");
        }
    }
}
