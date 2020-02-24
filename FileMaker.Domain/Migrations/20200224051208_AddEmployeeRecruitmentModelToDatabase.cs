using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddEmployeeRecruitmentModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeRecruitments",
                columns: table => new
                {
                    EmployeeRecruitmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStarted = table.Column<DateTime>(nullable: true),
                    DateLeft = table.Column<DateTime>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    DatePensionStarted = table.Column<DateTime>(nullable: true),
                    InsuarenceNumber = table.Column<string>(nullable: true),
                    TypeOfEmployment = table.Column<int>(nullable: false),
                    Relationship = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRecruitments", x => x.EmployeeRecruitmentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeRecruitments");
        }
    }
}
