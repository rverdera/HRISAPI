using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRISAPI.Migrations
{
    public partial class CreateTablesssssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_BloodType_BloodTypeID",
                schema: "PDS",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_CivilStatus_CivilStatusID",
                schema: "PDS",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_BloodTypeID",
                schema: "PDS",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_CivilStatusID",
                schema: "PDS",
                table: "Person");

            migrationBuilder.AddColumn<int>(
                name: "BloodTypeModelsBloodTypeID",
                schema: "PDS",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CivilStatusModelsCivilStatusID",
                schema: "PDS",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Person_BloodTypeModelsBloodTypeID",
                schema: "PDS",
                table: "Person",
                column: "BloodTypeModelsBloodTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CivilStatusModelsCivilStatusID",
                schema: "PDS",
                table: "Person",
                column: "CivilStatusModelsCivilStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_BloodType_BloodTypeModelsBloodTypeID",
                schema: "PDS",
                table: "Person",
                column: "BloodTypeModelsBloodTypeID",
                principalSchema: "FM",
                principalTable: "BloodType",
                principalColumn: "BloodTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_CivilStatus_CivilStatusModelsCivilStatusID",
                schema: "PDS",
                table: "Person",
                column: "CivilStatusModelsCivilStatusID",
                principalSchema: "FM",
                principalTable: "CivilStatus",
                principalColumn: "CivilStatusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_BloodType_BloodTypeModelsBloodTypeID",
                schema: "PDS",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_CivilStatus_CivilStatusModelsCivilStatusID",
                schema: "PDS",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_BloodTypeModelsBloodTypeID",
                schema: "PDS",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_CivilStatusModelsCivilStatusID",
                schema: "PDS",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "BloodTypeModelsBloodTypeID",
                schema: "PDS",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CivilStatusModelsCivilStatusID",
                schema: "PDS",
                table: "Person");

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
    }
}
