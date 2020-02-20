using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddClientPurchaseModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientPurchases",
                columns: table => new
                {
                    ClientPurchaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<string>(nullable: true),
                    Credit = table.Column<string>(nullable: true),
                    Discount = table.Column<string>(nullable: true),
                    PaymentTerms = table.Column<string>(nullable: true),
                    PaymentMethod = table.Column<string>(nullable: true),
                    Pricing = table.Column<string>(nullable: true),
                    Vat = table.Column<string>(nullable: true),
                    ClientCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPurchases", x => x.ClientPurchaseId);
                    table.ForeignKey(
                        name: "FK_ClientPurchases_Clients_ClientCode",
                        column: x => x.ClientCode,
                        principalTable: "Clients",
                        principalColumn: "ClientCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientPurchases_ClientCode",
                table: "ClientPurchases",
                column: "ClientCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientPurchases");
        }
    }
}
