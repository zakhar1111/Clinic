using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace clinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class id_autogeneration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Slot15Min",
                schema: "clinic",
                table: "Booking",
                newName: "DurationIn15MinSlots");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Day",
                schema: "clinic",
                table: "Shift",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.InsertData(
                schema: "clinic",
                table: "AppointmentStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Scheduled" },
                    { 2, "Paid" },
                    { 3, "Cancelled" },
                    { 4, "Completed" }
                });

            migrationBuilder.InsertData(
                schema: "clinic",
                table: "BookingStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Scheduled" },
                    { 2, "Confirmed" },
                    { 3, "Canceled" },
                    { 4, "Completed" }
                });

            migrationBuilder.InsertData(
                schema: "clinic",
                table: "PayStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Paid" },
                    { 2, "Unpaid" },
                    { 3, "Pending" }
                });

            migrationBuilder.InsertData(
                schema: "clinic",
                table: "PayType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cash" },
                    { 2, "Credit Card" },
                    { 3, "Insurance" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "AppointmentStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "AppointmentStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "AppointmentStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "AppointmentStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "BookingStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "BookingStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "BookingStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "BookingStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "PayStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "PayStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "PayStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "PayType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "PayType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "clinic",
                table: "PayType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Day",
                schema: "clinic",
                table: "Shift");

            migrationBuilder.RenameColumn(
                name: "DurationIn15MinSlots",
                schema: "clinic",
                table: "Booking",
                newName: "Slot15Min");
        }
    }
}
