using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class UpdateEmployeeContactModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
