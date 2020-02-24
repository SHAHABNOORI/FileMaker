using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddEmployeeRecruitmentRelationToEmployeeModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeNumber",
                table: "EmployeeRecruitments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRecruitments_EmployeeNumber",
                table: "EmployeeRecruitments",
                column: "EmployeeNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRecruitments_Employees_EmployeeNumber",
                table: "EmployeeRecruitments",
                column: "EmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRecruitments_Employees_EmployeeNumber",
                table: "EmployeeRecruitments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeRecruitments_EmployeeNumber",
                table: "EmployeeRecruitments");

            migrationBuilder.DropColumn(
                name: "EmployeeNumber",
                table: "EmployeeRecruitments");
        }
    }
}
