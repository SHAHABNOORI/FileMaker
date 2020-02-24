using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class UpdateEmployeeAdrressModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "EmployeeAddresses");

            migrationBuilder.AddColumn<string>(
                name: "AddressOne",
                table: "EmployeeAddresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressTwo",
                table: "EmployeeAddresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressOne",
                table: "EmployeeAddresses");

            migrationBuilder.DropColumn(
                name: "AddressTwo",
                table: "EmployeeAddresses");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "EmployeeAddresses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
