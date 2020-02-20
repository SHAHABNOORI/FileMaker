using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddClientDeliveryAddressToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientAddress_Clients_ClientCode",
                table: "ClientAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientAddress",
                table: "ClientAddress");

            migrationBuilder.RenameTable(
                name: "ClientAddress",
                newName: "ClientAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_ClientAddress_ClientCode",
                table: "ClientAddresses",
                newName: "IX_ClientAddresses_ClientCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientAddresses",
                table: "ClientAddresses",
                column: "ClientAddressId");

            migrationBuilder.CreateTable(
                name: "ClientDeliveryAddresses",
                columns: table => new
                {
                    ClientDeliveryAddressId = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_ClientDeliveryAddresses", x => x.ClientDeliveryAddressId);
                    table.ForeignKey(
                        name: "FK_ClientDeliveryAddresses_Clients_ClientCode",
                        column: x => x.ClientCode,
                        principalTable: "Clients",
                        principalColumn: "ClientCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeliveryAddresses_ClientCode",
                table: "ClientDeliveryAddresses",
                column: "ClientCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAddresses_Clients_ClientCode",
                table: "ClientAddresses",
                column: "ClientCode",
                principalTable: "Clients",
                principalColumn: "ClientCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientAddresses_Clients_ClientCode",
                table: "ClientAddresses");

            migrationBuilder.DropTable(
                name: "ClientDeliveryAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientAddresses",
                table: "ClientAddresses");

            migrationBuilder.RenameTable(
                name: "ClientAddresses",
                newName: "ClientAddress");

            migrationBuilder.RenameIndex(
                name: "IX_ClientAddresses_ClientCode",
                table: "ClientAddress",
                newName: "IX_ClientAddress_ClientCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientAddress",
                table: "ClientAddress",
                column: "ClientAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAddress_Clients_ClientCode",
                table: "ClientAddress",
                column: "ClientCode",
                principalTable: "Clients",
                principalColumn: "ClientCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
