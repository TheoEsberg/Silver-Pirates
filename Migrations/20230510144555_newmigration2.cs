using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Silver_Pirates.Migrations
{
    /// <inheritdoc />
    public partial class newmigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "DateWorked",
                value: new DateTime(2023, 5, 3, 16, 45, 55, 720, DateTimeKind.Local).AddTicks(925));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 2,
                column: "DateWorked",
                value: new DateTime(2023, 5, 3, 16, 45, 55, 720, DateTimeKind.Local).AddTicks(969));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 3,
                column: "DateWorked",
                value: new DateTime(2023, 5, 3, 16, 45, 55, 720, DateTimeKind.Local).AddTicks(973));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 4,
                column: "DateWorked",
                value: new DateTime(2023, 5, 10, 16, 15, 55, 720, DateTimeKind.Local).AddTicks(977));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 5,
                column: "DateWorked",
                value: new DateTime(2023, 5, 10, 16, 15, 55, 720, DateTimeKind.Local).AddTicks(981));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "DateWorked",
                value: new DateTime(2023, 5, 10, 16, 15, 55, 720, DateTimeKind.Local).AddTicks(985));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "DateWorked",
                value: new DateTime(2023, 5, 3, 16, 42, 17, 815, DateTimeKind.Local).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 2,
                column: "DateWorked",
                value: new DateTime(2023, 5, 3, 16, 42, 17, 815, DateTimeKind.Local).AddTicks(3143));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 3,
                column: "DateWorked",
                value: new DateTime(2023, 5, 3, 16, 42, 17, 815, DateTimeKind.Local).AddTicks(3146));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 4,
                column: "DateWorked",
                value: new DateTime(2023, 5, 10, 16, 12, 17, 815, DateTimeKind.Local).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 5,
                column: "DateWorked",
                value: new DateTime(2023, 5, 10, 16, 12, 17, 815, DateTimeKind.Local).AddTicks(3151));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "DateWorked",
                value: new DateTime(2023, 5, 10, 16, 12, 17, 815, DateTimeKind.Local).AddTicks(3154));
        }
    }
}
