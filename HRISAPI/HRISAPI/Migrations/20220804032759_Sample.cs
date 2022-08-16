using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRISAPI.Migrations
{
    public partial class Sample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_BloodType_BloodTypeID",
                schema: "PIM",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_CivilStatus_CivilStatusID",
                schema: "PIM",
                table: "Person");

            migrationBuilder.AlterColumn<int>(
                name: "CivilStatusID",
                schema: "PIM",
                table: "Person",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BloodTypeID",
                schema: "PIM",
                table: "Person",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_BloodType_BloodTypeID",
                schema: "PIM",
                table: "Person",
                column: "BloodTypeID",
                principalSchema: "FM",
                principalTable: "BloodType",
                principalColumn: "BloodTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_CivilStatus_CivilStatusID",
                schema: "PIM",
                table: "Person",
                column: "CivilStatusID",
                principalSchema: "FM",
                principalTable: "CivilStatus",
                principalColumn: "CivilStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_BloodType_BloodTypeID",
                schema: "PIM",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_CivilStatus_CivilStatusID",
                schema: "PIM",
                table: "Person");

            migrationBuilder.AlterColumn<int>(
                name: "CivilStatusID",
                schema: "PIM",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BloodTypeID",
                schema: "PIM",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_BloodType_BloodTypeID",
                schema: "PIM",
                table: "Person",
                column: "BloodTypeID",
                principalSchema: "FM",
                principalTable: "BloodType",
                principalColumn: "BloodTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_CivilStatus_CivilStatusID",
                schema: "PIM",
                table: "Person",
                column: "CivilStatusID",
                principalSchema: "FM",
                principalTable: "CivilStatus",
                principalColumn: "CivilStatusID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
