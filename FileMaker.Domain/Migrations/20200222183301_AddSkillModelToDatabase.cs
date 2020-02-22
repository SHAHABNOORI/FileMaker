using Microsoft.EntityFrameworkCore.Migrations;

namespace FileMaker.Domain.Migrations
{
    public partial class AddSkillModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Languages_LanguageId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Origins_OriginId",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_OriginId",
                table: "Employees",
                newName: "IX_Employees_OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_LanguageId",
                table: "Employees",
                newName: "IX_Employees_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeNumber");

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Languages_LanguageId",
                table: "Employees",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Origins_OriginId",
                table: "Employees",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Languages_LanguageId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Origins_OriginId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_OriginId",
                table: "Employee",
                newName: "IX_Employee_OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_LanguageId",
                table: "Employee",
                newName: "IX_Employee_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Languages_LanguageId",
                table: "Employee",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Origins_OriginId",
                table: "Employee",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
