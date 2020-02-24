using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class UpdateAddBankNameToBankInfoModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "BankInfos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankName",
                table: "BankInfos");
        }
    }
}
