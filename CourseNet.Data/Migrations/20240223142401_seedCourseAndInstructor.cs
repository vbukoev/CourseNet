using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class seedCourseAndInstructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { -3, "harrytailor@email.com", "Harry", "Tailor" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { -2, "kyledoe@gmail.com", "Kyle", "Doe" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { -1, "johndoe@abv.bg", "John", "Doe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
