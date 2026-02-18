using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class auth_Info : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "clinic",
                table: "Patient",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "clinic",
                table: "Doctor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "clinic",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "clinic",
                table: "Doctor");
        }
    }
}
