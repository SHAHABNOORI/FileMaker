using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddNameAndPhoneNumberFieldToClientDeliveryAddressModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BussinesAddress",
                table: "ClientDeliveryAddresses");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ClientDeliveryAddresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ClientDeliveryAddresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ClientDeliveryAddresses");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ClientDeliveryAddresses");

            migrationBuilder.AddColumn<string>(
                name: "BussinesAddress",
                table: "ClientDeliveryAddresses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
