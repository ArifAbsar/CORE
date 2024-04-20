using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.Migrations
{
    public partial class changeuppercase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Course_NAME",
                table: "CourseSet",
                newName: "course_name");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CourseSet",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "course_name",
                table: "CourseSet",
                newName: "Course_NAME");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CourseSet",
                newName: "ID");
        }
    }
}
