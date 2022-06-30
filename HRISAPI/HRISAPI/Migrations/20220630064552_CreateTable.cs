using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRISAPI.Migrations
{
    public partial class CreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FM");

            migrationBuilder.EnsureSchema(
                name: "PDS");

            migrationBuilder.CreateTable(
                name: "BloodType",
                schema: "FM",
                columns: table => new
                {
                    BloodTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDel = table.Column<bool>(type: "bit", nullable: false),
                    UserStamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodType", x => x.BloodTypeID);
                });

            migrationBuilder.CreateTable(
                name: "CivilStatus",
                schema: "FM",
                columns: table => new
                {
                    CivilStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDel = table.Column<bool>(type: "bit", nullable: false),
                    UserStamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilStatus", x => x.CivilStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "PDS",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ExtensionName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CivilStatusModelCivilStatusID = table.Column<int>(type: "int", nullable: false),
                    BloodTypeModelBloodTypeID = table.Column<int>(type: "int", nullable: false),
                    IsDel = table.Column<bool>(type: "bit", nullable: false),
                    UserStamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Person_BloodType_BloodTypeModelBloodTypeID",
                        column: x => x.BloodTypeModelBloodTypeID,
                        principalSchema: "FM",
                        principalTable: "BloodType",
                        principalColumn: "BloodTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_CivilStatus_CivilStatusModelCivilStatusID",
                        column: x => x.CivilStatusModelCivilStatusID,
                        principalSchema: "FM",
                        principalTable: "CivilStatus",
                        principalColumn: "CivilStatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_BloodTypeModelBloodTypeID",
                schema: "PDS",
                table: "Person",
                column: "BloodTypeModelBloodTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CivilStatusModelCivilStatusID",
                schema: "PDS",
                table: "Person",
                column: "CivilStatusModelCivilStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person",
                schema: "PDS");

            migrationBuilder.DropTable(
                name: "BloodType",
                schema: "FM");

            migrationBuilder.DropTable(
                name: "CivilStatus",
                schema: "FM");
        }
    }
}
