using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddClientExtraInformationModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientExtraInformations",
                columns: table => new
                {
                    ClientExtraInformationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ntk = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    RelationShip = table.Column<string>(nullable: true),
                    ClientCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientExtraInformations", x => x.ClientExtraInformationId);
                    table.ForeignKey(
                        name: "FK_ClientExtraInformations_Clients_ClientCode",
                        column: x => x.ClientCode,
                        principalTable: "Clients",
                        principalColumn: "ClientCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientExtraInformations_ClientCode",
                table: "ClientExtraInformations",
                column: "ClientCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientExtraInformations");
        }
    }
}
