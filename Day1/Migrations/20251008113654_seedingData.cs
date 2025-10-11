using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Day1.Migrations
{
    /// <inheritdoc />
    public partial class seedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Manager", "Name" },
                values: new object[,]
                {
                    { 1, "Ahmed", "CS" },
                    { 2, "Ali", "IS" },
                    { 3, "Amr", "IT" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "DepartmentID", "Hours", "Name", "degree", "minDegree" },
                values: new object[,]
                {
                    { 1, 1, 15, "C#", 100, 50 },
                    { 2, 2, 16, "JS", 100, 50 }
                });

            migrationBuilder.InsertData(
                table: "Trainee",
                columns: new[] { "Id", "Address", "DepartmentID", "Image", "Name", "grade" },
                values: new object[,]
                {
                    { 1, "Assiut", 1, "m.png", "Ali", 78 },
                    { 2, "Assiut", 2, "m.png", "Ahmed", 98 },
                    { 3, "Assiut", 3, "m.png", "Amr", 50 }
                });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "Address", "CourseID", "DepartmentID", "Img", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, "Assiut", 1, 1, "m.png", "Ahmed", 8000 },
                    { 2, "Assiut", 2, 2, "m.png", "Ali", 10000 },
                    { 3, "Cairo", 1, 1, "m.png", "Amr", 20000 },
                    { 4, "Assiut", 2, 2, "m.png", "Sayed", 7000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
