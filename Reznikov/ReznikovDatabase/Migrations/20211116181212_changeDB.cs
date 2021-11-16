using Microsoft.EntityFrameworkCore.Migrations;

namespace ReznikovDatabase.Migrations
{
    public partial class changeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_EducationForms_EducationFormId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_EducationFormId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EducationFormId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "EducationFormName",
                table: "Students",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EducationFormName",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "EducationFormId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_EducationFormId",
                table: "Students",
                column: "EducationFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_EducationForms_EducationFormId",
                table: "Students",
                column: "EducationFormId",
                principalTable: "EducationForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
