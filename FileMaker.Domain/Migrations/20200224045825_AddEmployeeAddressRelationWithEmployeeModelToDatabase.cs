using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddEmployeeAddressRelationWithEmployeeModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeNumber",
                table: "EmployeeAddresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddresses_EmployeeNumber",
                table: "EmployeeAddresses",
                column: "EmployeeNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAddresses_Employees_EmployeeNumber",
                table: "EmployeeAddresses",
                column: "EmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAddresses_Employees_EmployeeNumber",
                table: "EmployeeAddresses");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAddresses_EmployeeNumber",
                table: "EmployeeAddresses");

            migrationBuilder.DropColumn(
                name: "EmployeeNumber",
                table: "EmployeeAddresses");
        }
    }
}
