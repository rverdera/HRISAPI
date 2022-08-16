using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRISAPI.Migrations
{
    public partial class DbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FM");

            migrationBuilder.EnsureSchema(
                name: "PDS");

            migrationBuilder.EnsureSchema(
                name: "UTILITY");

            migrationBuilder.CreateTable(
                name: "BloodType",
                schema: "FM",
                columns: table => new
                {
                    BloodTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDel = table.Column<bool>(type: "bit", nullable: false),
                    UserStamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDel = table.Column<bool>(type: "bit", nullable: false),
                    UserStamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilStatus", x => x.CivilStatusID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "UTILITY",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedAtTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDel = table.Column<bool>(type: "bit", nullable: false),
                    UserStamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
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
                    CivilStatusID = table.Column<int>(type: "int", nullable: false),
                    BloodTypeID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDel = table.Column<bool>(type: "bit", nullable: false),
                    UserStamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Person_BloodType_BloodTypeID",
                        column: x => x.BloodTypeID,
                        principalSchema: "FM",
                        principalTable: "BloodType",
                        principalColumn: "BloodTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_CivilStatus_CivilStatusID",
                        column: x => x.CivilStatusID,
                        principalSchema: "FM",
                        principalTable: "CivilStatus",
                        principalColumn: "CivilStatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_BloodTypeID",
                schema: "PDS",
                table: "Person",
                column: "BloodTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CivilStatusID",
                schema: "PDS",
                table: "Person",
                column: "CivilStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person",
                schema: "PDS");

            migrationBuilder.DropTable(
                name: "User",
                schema: "UTILITY");

            migrationBuilder.DropTable(
                name: "BloodType",
                schema: "FM");

            migrationBuilder.DropTable(
                name: "CivilStatus",
                schema: "FM");
        }
    }
}
