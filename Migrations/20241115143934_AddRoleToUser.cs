using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "role",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "role",
                value: "Doctor");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "role",
                value: "Patient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 16, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 17, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4025));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 18, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 11, 19, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4028));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 11, 20, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4029));

            migrationBuilder.UpdateData(
                table: "history_datings",
                keyColumn: "Id",
                keyValue: 1,
                column: "last_update",
                value: new DateTime(2024, 10, 15, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4084));

            migrationBuilder.UpdateData(
                table: "history_datings",
                keyColumn: "Id",
                keyValue: 2,
                column: "last_update",
                value: new DateTime(2024, 9, 15, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "history_datings",
                keyColumn: "Id",
                keyValue: 3,
                column: "last_update",
                value: new DateTime(2024, 8, 15, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4091));

            migrationBuilder.UpdateData(
                table: "history_datings",
                keyColumn: "Id",
                keyValue: 4,
                column: "last_update",
                value: new DateTime(2024, 7, 15, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4093));

            migrationBuilder.UpdateData(
                table: "history_datings",
                keyColumn: "Id",
                keyValue: 5,
                column: "last_update",
                value: new DateTime(2024, 6, 15, 9, 28, 33, 247, DateTimeKind.Local).AddTicks(4095));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "role",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "role",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "role",
                value: null);
        }
    }
}
