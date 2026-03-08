using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace clinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix_payment_status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "clinic",
                table: "PayStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Created");

            migrationBuilder.UpdateData(
                schema: "clinic",
                table: "PayStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Authorized");

            migrationBuilder.UpdateData(
                schema: "clinic",
                table: "PayStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Paid");

            migrationBuilder.InsertData(
                schema: "clinic",
                table: "PayStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Failed" },
                    { 5, "Refunded" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "PayStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "PayStatus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                schema: "clinic",
                table: "PayStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Paid");

            migrationBuilder.UpdateData(
                schema: "clinic",
                table: "PayStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Unpaid");

            migrationBuilder.UpdateData(
                schema: "clinic",
                table: "PayStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Pending");
        }
    }
}
