using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRISAPI.Migrations
{
    public partial class AddBloodTypeAndCivilStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "PersonModels");

            migrationBuilder.CreateTable(
                name: "BloodTypeModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDel = table.Column<bool>(type: "bit", nullable: false),
                    UserStamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTypeModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CivilStatusModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDel = table.Column<bool>(type: "bit", nullable: false),
                    UserStamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilStatusModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodTypeModels");

            migrationBuilder.DropTable(
                name: "CivilStatusModels");

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "PersonModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
