using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddEmployeeModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    PersonalNumber = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    PassportNumber = table.Column<string>(nullable: true),
                    Title = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    SexualOrientation = table.Column<int>(nullable: false),
                    OriginId = table.Column<int>(nullable: true),
                    LanguageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeNumber);
                    table.ForeignKey(
                        name: "FK_Employee_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Origins_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_LanguageId",
                table: "Employee",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_OriginId",
                table: "Employee",
                column: "OriginId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
