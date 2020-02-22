using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddRelationBetweenEmployeeAndEducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducationEduacationId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EducationEduacationId",
                table: "Employees",
                column: "EducationEduacationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Education_EducationEduacationId",
                table: "Employees",
                column: "EducationEduacationId",
                principalTable: "Education",
                principalColumn: "EduacationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Education_EducationEduacationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EducationEduacationId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EducationEduacationId",
                table: "Employees");
        }
    }
}
