using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRISAPI.Migrations
{
    public partial class AddedSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CivilStatusModels",
                table: "CivilStatusModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BloodTypeModels",
                table: "BloodTypeModels");

            migrationBuilder.EnsureSchema(
                name: "FM");

            migrationBuilder.RenameTable(
                name: "CivilStatusModels",
                newName: "CivilStatus",
                newSchema: "FM");

            migrationBuilder.RenameTable(
                name: "BloodTypeModels",
                newName: "BloodType",
                newSchema: "FM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CivilStatus",
                schema: "FM",
                table: "CivilStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BloodType",
                schema: "FM",
                table: "BloodType",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CivilStatus",
                schema: "FM",
                table: "CivilStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BloodType",
                schema: "FM",
                table: "BloodType");

            migrationBuilder.RenameTable(
                name: "CivilStatus",
                schema: "FM",
                newName: "CivilStatusModels");

            migrationBuilder.RenameTable(
                name: "BloodType",
                schema: "FM",
                newName: "BloodTypeModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CivilStatusModels",
                table: "CivilStatusModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BloodTypeModels",
                table: "BloodTypeModels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PersonModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDel = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserStamp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonModels", x => x.Id);
                });
        }
    }
}
