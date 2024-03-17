using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class NewEntitiesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Lecture Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Lecture Title"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Lecture Description"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Lecture Date"),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Course Identifier"),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Instructor Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lectures_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Lecture Table");

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Material Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Material Name"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Material Description"),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Course Identifier"),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Instructor Identifier"),
                    LectureId = table.Column<int>(type: "int", nullable: false, comment: "Lecture Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_Lectures_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                },
                comment: "Material Table");

            
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Review Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "Review Rating"),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Review Comment"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Review Date"),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Course Identifier"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Students_UserId",
                        column: x => x.UserId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Review Table");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseId",
                table: "Lectures",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_InstructorId",
                table: "Lectures",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CourseId",
                table: "Materials",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_InstructorId",
                table: "Materials",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_LectureId",
                table: "Materials",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CourseId",
                table: "Reviews",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseUser");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "Student Identifier");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Category Identifier");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CourseId", "Name" },
                values: new object[] { 1, null, "Programming" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CourseId", "Name" },
                values: new object[] { 2, null, "Design" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CourseId", "Name" },
                values: new object[] { 3, null, "Business" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("26847e9d-afcf-444d-b632-85032cd4e153"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Научете основите на C# език за програмиране", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 0, new Guid("f2dedb39-40b0-4042-cbe4-08dc3524bc5d"), "C# Fundamentals" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("3170bfd9-a623-434c-9159-3ab77189e714"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Научете напреднали техники на дизайна", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 2, null, "Design Advanced " });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("85b46a3b-8fb7-4b56-a6f9-472d465542a4"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Научете как да управлявате бизнеса си", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 3, null, "Business Management" });
        }
    }
}
