using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRISAPI.Migrations
{
    public partial class CreateTablesssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_BloodType_BloodTypeModelBloodTypeID",
                schema: "PDS",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_CivilStatus_CivilStatusModelCivilStatusID",
                schema: "PDS",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "CivilStatusModelCivilStatusID",
                schema: "PDS",
                table: "Person",
                newName: "CivilStatusID");

            migrationBuilder.RenameColumn(
                name: "BloodTypeModelBloodTypeID",
                schema: "PDS",
                table: "Person",
                newName: "BloodTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Person_CivilStatusModelCivilStatusID",
                schema: "PDS",
                table: "Person",
                newName: "IX_Person_CivilStatusID");

            migrationBuilder.RenameIndex(
                name: "IX_Person_BloodTypeModelBloodTypeID",
                schema: "PDS",
                table: "Person",
                newName: "IX_Person_BloodTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_BloodType_BloodTypeID",
                schema: "PDS",
                table: "Person",
                column: "BloodTypeID",
                principalSchema: "FM",
                principalTable: "BloodType",
                principalColumn: "BloodTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_CivilStatus_CivilStatusID",
                schema: "PDS",
                table: "Person",
                column: "CivilStatusID",
                principalSchema: "FM",
                principalTable: "CivilStatus",
                principalColumn: "CivilStatusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_BloodType_BloodTypeID",
                schema: "PDS",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_CivilStatus_CivilStatusID",
                schema: "PDS",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "CivilStatusID",
                schema: "PDS",
                table: "Person",
                newName: "CivilStatusModelCivilStatusID");

            migrationBuilder.RenameColumn(
                name: "BloodTypeID",
                schema: "PDS",
                table: "Person",
                newName: "BloodTypeModelBloodTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Person_CivilStatusID",
                schema: "PDS",
                table: "Person",
                newName: "IX_Person_CivilStatusModelCivilStatusID");

            migrationBuilder.RenameIndex(
                name: "IX_Person_BloodTypeID",
                schema: "PDS",
                table: "Person",
                newName: "IX_Person_BloodTypeModelBloodTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_BloodType_BloodTypeModelBloodTypeID",
                schema: "PDS",
                table: "Person",
                column: "BloodTypeModelBloodTypeID",
                principalSchema: "FM",
                principalTable: "BloodType",
                principalColumn: "BloodTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_CivilStatus_CivilStatusModelCivilStatusID",
                schema: "PDS",
                table: "Person",
                column: "CivilStatusModelCivilStatusID",
                principalSchema: "FM",
                principalTable: "CivilStatus",
                principalColumn: "CivilStatusID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
