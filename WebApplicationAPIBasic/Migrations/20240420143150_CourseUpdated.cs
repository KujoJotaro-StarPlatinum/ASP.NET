using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNETProdactAndCategory.Migrations
{
    /// <inheritdoc />
    public partial class CourseUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurseName",
                table: "Courses",
                newName: "CourseName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseName",
                table: "Courses",
                newName: "CurseName");
        }
    }
}
