using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init_clinic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "clinic");

            migrationBuilder.CreateTable(
                name: "AppointmentStatus",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingStatus",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurance",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provider = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Coverage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GovId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayStatus",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayType",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speciality",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Slot15Min = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shift_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "clinic",
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Slot15Min = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_BookingStatus_BookingStatusId",
                        column: x => x.BookingStatusId,
                        principalSchema: "clinic",
                        principalTable: "BookingStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "clinic",
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "clinic",
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpeciality",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    SpecialityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpeciality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSpeciality_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "clinic",
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorSpeciality_Speciality_SpecialityId",
                        column: x => x.SpecialityId,
                        principalSchema: "clinic",
                        principalTable: "Speciality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    AppointmentStatusId = table.Column<int>(type: "int", nullable: false),
                    InsuranceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_AppointmentStatus_AppointmentStatusId",
                        column: x => x.AppointmentStatusId,
                        principalSchema: "clinic",
                        principalTable: "AppointmentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Booking_BookingId",
                        column: x => x.BookingId,
                        principalSchema: "clinic",
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalSchema: "clinic",
                        principalTable: "Insurance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diagnostic",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TestResults = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnostic_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "clinic",
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "clinic",
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    PayTypeId = table.Column<int>(type: "int", nullable: false),
                    PayStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "clinic",
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_PayStatus_PayStatusId",
                        column: x => x.PayStatusId,
                        principalSchema: "clinic",
                        principalTable: "PayStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_PayType_PayTypeId",
                        column: x => x.PayTypeId,
                        principalSchema: "clinic",
                        principalTable: "PayType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medicine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescription_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "clinic",
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AppointmentStatusId",
                schema: "clinic",
                table: "Appointment",
                column: "AppointmentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_BookingId",
                schema: "clinic",
                table: "Appointment",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_InsuranceId",
                schema: "clinic",
                table: "Appointment",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_BookingStatusId",
                schema: "clinic",
                table: "Booking",
                column: "BookingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_DoctorId",
                schema: "clinic",
                table: "Booking",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PatientId",
                schema: "clinic",
                table: "Booking",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostic_AppointmentId",
                schema: "clinic",
                table: "Diagnostic",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpeciality_DoctorId",
                schema: "clinic",
                table: "DoctorSpeciality",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpeciality_SpecialityId",
                schema: "clinic",
                table: "DoctorSpeciality",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_AppointmentId",
                schema: "clinic",
                table: "Note",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_AppointmentId",
                schema: "clinic",
                table: "Payment",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PayStatusId",
                schema: "clinic",
                table: "Payment",
                column: "PayStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PayTypeId",
                schema: "clinic",
                table: "Payment",
                column: "PayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_AppointmentId",
                schema: "clinic",
                table: "Prescription",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_DoctorId",
                schema: "clinic",
                table: "Shift",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnostic",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "DoctorSpeciality",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "Note",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "Payment",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "Prescription",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "Shift",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "Speciality",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "PayStatus",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "PayType",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "Appointment",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "AppointmentStatus",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "Booking",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "Insurance",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "BookingStatus",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "Doctor",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "Patient",
                schema: "clinic");
        }
    }
}
