using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace clinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class doctors_list : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "clinic",
                table: "Speciality",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cardiology" },
                    { 2, "Dermatology" },
                    { 3, "Neurology" },
                    { 4, "Pediatrics" },
                    { 5, "Psychiatry" },
                    { 6, "Family Doctor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
