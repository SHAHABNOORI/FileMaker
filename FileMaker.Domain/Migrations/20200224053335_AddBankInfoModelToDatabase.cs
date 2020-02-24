using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddBankInfoModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankInfos",
                columns: table => new
                {
                    BankInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortCode = table.Column<int>(nullable: false),
                    AccountNo = table.Column<string>(nullable: true),
                    AccountName = table.Column<int>(nullable: false),
                    Iban = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankInfos", x => x.BankInfoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankInfos");
        }
    }
}
