using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.Migrations
{
    public partial class change_table_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseSet",
                table: "CourseSet");

            migrationBuilder.RenameTable(
                name: "CourseSet",
                newName: "courseset");

            migrationBuilder.AddPrimaryKey(
                name: "PK_courseset",
                table: "courseset",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_courseset",
                table: "courseset");

            migrationBuilder.RenameTable(
                name: "courseset",
                newName: "CourseSet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseSet",
                table: "CourseSet",
                column: "id");
        }
    }
}
