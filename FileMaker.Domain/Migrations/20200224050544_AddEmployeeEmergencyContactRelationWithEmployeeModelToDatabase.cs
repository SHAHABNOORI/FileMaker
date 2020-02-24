using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddEmployeeEmergencyContactRelationWithEmployeeModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeNumber",
                table: "EmployeeEmergencyContacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmergencyContacts_EmployeeNumber",
                table: "EmployeeEmergencyContacts",
                column: "EmployeeNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEmergencyContacts_Employees_EmployeeNumber",
                table: "EmployeeEmergencyContacts",
                column: "EmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEmergencyContacts_Employees_EmployeeNumber",
                table: "EmployeeEmergencyContacts");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeEmergencyContacts_EmployeeNumber",
                table: "EmployeeEmergencyContacts");

            migrationBuilder.DropColumn(
                name: "EmployeeNumber",
                table: "EmployeeEmergencyContacts");
        }
    }
}
