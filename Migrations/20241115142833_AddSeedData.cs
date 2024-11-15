using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    specialty = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password_hash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    motive = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    state = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    doctor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.id);
                    table.ForeignKey(
                        name: "FK_appointments_Doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_Patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "history_datings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_update = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    patient_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_history_datings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_history_datings_Patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "email", "name", "specialty" },
                values: new object[,]
                {
                    { 1, "carlos.gomez@hospital.com", "Dr. Carlos Gómez", "Cardiología" },
                    { 2, "maria.lopez@hospital.com", "Dra. María López", "Neurología" },
                    { 3, "juan.perez@hospital.com", "Dr. Juan Pérez", "Pediatría" },
                    { 4, "laura.martinez@hospital.com", "Dra. Laura Martínez", "Ortopedia" },
                    { 5, "alberto.sanchez@hospital.com", "Dr. Alberto Sánchez", "Ginecología" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "email", "name", "phone" },
                values: new object[,]
                {
                    { 1, "carlos.gonzalez@example.com", "Carlos González", "3012345678" },
                    { 2, "ana.perez@example.com", "Ana Pérez", "3023456789" },
                    { 3, "luis.martinez@example.com", "Luis Martínez", "3034567890" },
                    { 4, "sofia.rodriguez@example.com", "Sofía Rodríguez", "3045678901" },
                    { 5, "juan.perez@example.com", "Juan Pérez", "3056789012" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "name", "password_hash", "role" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", "hashedpassword1", null },
                    { 2, "jane.smith@example.com", "Jane", "hashedpassword2", null },
                    { 3, "jim.brown@example.com", "Jim", "hashedpassword3", null }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "id", "Date", "doctor_id", "motive", "note", "patient_id", "state" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 16, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4003), 1, "Consulta General", "Revisión anual", 1, "Pendiente" },
                    { 2, new DateTime(2024, 11, 17, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4025), 2, "Chequeo de salud", "Chequeo regular", 2, "Confirmada" },
                    { 3, new DateTime(2024, 11, 18, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4026), 3, "Revisión de resultados", "Resultados de análisis", 3, "Completada" },
                    { 4, new DateTime(2024, 11, 19, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4028), 4, "Urgencia médica", "Accidente en el trabajo", 4, "Pendiente" },
                    { 5, new DateTime(2024, 11, 20, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4029), 1, "Control post operatorio", "Revisión después de la cirugía", 5, "Confirmada" }
                });

            migrationBuilder.InsertData(
                table: "history_datings",
                columns: new[] { "Id", "description", "last_update", "patient_id" },
                values: new object[,]
                {
                    { 1, "Paciente con hipertensión diagnosticada.", new DateTime(2024, 10, 15, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4084), 1 },
                    { 2, "Paciente con antecedentes familiares de diabetes.", new DateTime(2024, 9, 15, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4090), 2 },
                    { 3, "Paciente con diagnóstico reciente de asma.", new DateTime(2024, 8, 15, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4091), 3 },
                    { 4, "Paciente con cirugía reciente de rodilla.", new DateTime(2024, 7, 15, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4093), 4 },
                    { 5, "Paciente con alergias estacionales.", new DateTime(2024, 6, 15, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4095), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patient_id",
                table: "appointments",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_history_datings_patient_id",
                table: "history_datings",
                column: "patient_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "history_datings");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
