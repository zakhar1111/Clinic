using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix_appointment_status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "clinic",
                table: "AppointmentStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "InProgress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "clinic",
                table: "AppointmentStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Scheduled");
        }
    }
}
