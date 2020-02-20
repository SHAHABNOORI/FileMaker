using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddClientPaymentModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientPayments",
                columns: table => new
                {
                    ClientPaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DateOfReferral = table.Column<DateTime>(nullable: true),
                    ReferralBy = table.Column<int>(nullable: false),
                    ReferralFor = table.Column<int>(nullable: false),
                    ReferralTel = table.Column<string>(nullable: true),
                    ReasonForRefrral = table.Column<string>(nullable: true),
                    Therapist = table.Column<int>(nullable: false),
                    GpsName = table.Column<int>(nullable: false),
                    GpsNumber = table.Column<string>(nullable: true),
                    GpsAddress = table.Column<string>(nullable: true),
                    OtherReqirments = table.Column<int>(nullable: false),
                    ClientCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPayments", x => x.ClientPaymentId);
                    table.ForeignKey(
                        name: "FK_ClientPayments_Clients_ClientCode",
                        column: x => x.ClientCode,
                        principalTable: "Clients",
                        principalColumn: "ClientCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientPayments_ClientCode",
                table: "ClientPayments",
                column: "ClientCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientPayments");
        }
    }
}
