using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorAvailability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "availability",
                table: "Doctors",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "availability",
                value: "Lunes a Viernes: 9:00 - 17:00");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "availability",
                value: "Lunes a Viernes: 8:00 - 15:00");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "availability",
                value: "Lunes, Miércoles y Viernes: 10:00 - 14:00");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "availability",
                value: "Martes y Jueves: 8:00 - 12:00");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "availability",
                value: "Lunes a Viernes: 9:00 - 16:00");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 16, 10, 23, 41, 661, DateTimeKind.Local).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 17, 10, 23, 41, 662, DateTimeKind.Local).AddTicks(9));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 18, 10, 23, 41, 662, DateTimeKind.Local).AddTicks(10));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 11, 19, 10, 23, 41, 662, DateTimeKind.Local).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 11, 20, 10, 23, 41, 662, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "history_datings",
                keyColumn: "Id",
                keyValue: 1,
                column: "last_update",
                value: new DateTime(2024, 10, 15, 10, 23, 41, 662, DateTimeKind.Local).AddTicks(65));

            migrationBuilder.UpdateData(
                table: "history_datings",
                keyColumn: "Id",
                keyValue: 2,
                column: "last_update",
                value: new DateTime(2024, 9, 15, 10, 23, 41, 662, DateTimeKind.Local).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "history_datings",
                keyColumn: "Id",
                keyValue: 3,
                column: "last_update",
                value: new DateTime(2024, 8, 15, 10, 23, 41, 662, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "history_datings",
                keyColumn: "Id",
                keyValue: 4,
                column: "last_update",
                value: new DateTime(2024, 7, 15, 10, 23, 41, 662, DateTimeKind.Local).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "history_datings",
                keyColumn: "Id",
                keyValue: 5,
                column: "last_update",
                value: new DateTime(2024, 6, 15, 10, 23, 41, 662, DateTimeKind.Local).AddTicks(79));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "availability",
                table: "Doctors");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 16, 9, 39, 34, 327, DateTimeKind.Local).AddTicks(2069));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 17, 9, 39, 34, 327, DateTimeKind.Local).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 18, 9, 39, 34, 327, DateTimeKind.Local).AddTicks(2097));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 11, 19, 9, 39, 34, 327, DateTimeKind.Local).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 11, 20, 9, 39, 34, 327, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "history_datings",
                keyColumn: "Id",
                keyValue: 1,
                column: "last_update",
                value: new DateTime(2024, 10, 15, 9, 39, 34, 327, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "history_datings",
                keyColumn: "Id",
                keyValue: 2,
                column: "last_update",
                value: new DateTime(2024, 9, 15, 9, 39, 34, 327, DateTimeKind.Local).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "history_datings",
                keyColumn: "Id",
                keyValue: 3,
                column: "last_update",
                value: new DateTime(2024, 8, 15, 9, 39, 34, 327, DateTimeKind.Local).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "history_datings",
                keyColumn: "Id",
                keyValue: 4,
                column: "last_update",
                value: new DateTime(2024, 7, 15, 9, 39, 34, 327, DateTimeKind.Local).AddTicks(2340));

            migrationBuilder.UpdateData(
                table: "history_datings",
                keyColumn: "Id",
                keyValue: 5,
                column: "last_update",
                value: new DateTime(2024, 6, 15, 9, 39, 34, 327, DateTimeKind.Local).AddTicks(2342));
        }
    }
}
