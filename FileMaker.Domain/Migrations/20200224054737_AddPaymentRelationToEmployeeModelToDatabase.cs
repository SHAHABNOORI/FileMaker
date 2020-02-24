using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddPaymentRelationToEmployeeModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeNumber",
                table: "Payments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_EmployeeNumber",
                table: "Payments",
                column: "EmployeeNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Employees_EmployeeNumber",
                table: "Payments",
                column: "EmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Employees_EmployeeNumber",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_EmployeeNumber",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "EmployeeNumber",
                table: "Payments");
        }
    }
}
