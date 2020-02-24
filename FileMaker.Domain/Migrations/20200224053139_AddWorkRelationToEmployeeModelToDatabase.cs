using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddWorkRelationToEmployeeModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeNumber",
                table: "Works",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Works_EmployeeNumber",
                table: "Works",
                column: "EmployeeNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Employees_EmployeeNumber",
                table: "Works",
                column: "EmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Employees_EmployeeNumber",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_EmployeeNumber",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "EmployeeNumber",
                table: "Works");
        }
    }
}
