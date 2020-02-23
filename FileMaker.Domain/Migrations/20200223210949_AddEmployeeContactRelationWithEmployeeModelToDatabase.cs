using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddEmployeeContactRelationWithEmployeeModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeNumber",
                table: "Contacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_EmployeeNumber",
                table: "Contacts",
                column: "EmployeeNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Employees_EmployeeNumber",
                table: "Contacts",
                column: "EmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Employees_EmployeeNumber",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_EmployeeNumber",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "EmployeeNumber",
                table: "Contacts");
        }
    }
}
