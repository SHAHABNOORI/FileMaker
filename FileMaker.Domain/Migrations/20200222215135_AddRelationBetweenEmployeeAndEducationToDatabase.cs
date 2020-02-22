using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddRelationBetweenEmployeeAndEducationToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducationId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EducationId",
                table: "Employees",
                column: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Educations_EducationId",
                table: "Employees",
                column: "EducationId",
                principalTable: "Educations",
                principalColumn: "EducationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Educations_EducationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EducationId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "Employees");
        }
    }
}
