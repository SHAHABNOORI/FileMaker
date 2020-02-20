using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddClientAddressToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientAddress",
                columns: table => new
                {
                    ClientAddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    BussinesAddress = table.Column<string>(nullable: true),
                    Town = table.Column<int>(nullable: false),
                    City = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(nullable: true),
                    ClientCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAddress", x => x.ClientAddressId);
                    table.ForeignKey(
                        name: "FK_ClientAddress_Clients_ClientCode",
                        column: x => x.ClientCode,
                        principalTable: "Clients",
                        principalColumn: "ClientCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_ClientCode",
                table: "ClientAddress",
                column: "ClientCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientAddress");
        }
    }
}
