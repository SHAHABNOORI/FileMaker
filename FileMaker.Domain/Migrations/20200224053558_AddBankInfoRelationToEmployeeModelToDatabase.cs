using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddBankInfoRelationToEmployeeModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeNumber",
                table: "BankInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BankInfos_EmployeeNumber",
                table: "BankInfos",
                column: "EmployeeNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BankInfos_Employees_EmployeeNumber",
                table: "BankInfos",
                column: "EmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankInfos_Employees_EmployeeNumber",
                table: "BankInfos");

            migrationBuilder.DropIndex(
                name: "IX_BankInfos_EmployeeNumber",
                table: "BankInfos");

            migrationBuilder.DropColumn(
                name: "EmployeeNumber",
                table: "BankInfos");
        }
    }
}
