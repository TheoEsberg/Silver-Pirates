using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Silver_Pirates.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeProjectInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeProjects",
                columns: new[] { "EmployeeProjectId", "EmployeeId", "ProjectId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 4 },
                    { 3, 2, 2 },
                    { 4, 3, 1 },
                    { 5, 3, 3 }
                });

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "DateWorked",
                value: new DateTime(2023, 5, 1, 16, 20, 43, 830, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 2,
                column: "DateWorked",
                value: new DateTime(2023, 5, 1, 16, 20, 43, 830, DateTimeKind.Local).AddTicks(2573));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 3,
                column: "DateWorked",
                value: new DateTime(2023, 5, 1, 16, 20, 43, 830, DateTimeKind.Local).AddTicks(2579));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 4,
                column: "DateWorked",
                value: new DateTime(2023, 5, 9, 16, 20, 43, 830, DateTimeKind.Local).AddTicks(2585));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 5,
                column: "DateWorked",
                value: new DateTime(2023, 5, 9, 16, 20, 43, 830, DateTimeKind.Local).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "DateWorked",
                value: new DateTime(2023, 5, 9, 16, 20, 43, 830, DateTimeKind.Local).AddTicks(2600));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumn: "EmployeeProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumn: "EmployeeProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumn: "EmployeeProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumn: "EmployeeProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumn: "EmployeeProjectId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "DateWorked",
                value: new DateTime(2023, 5, 1, 16, 18, 45, 694, DateTimeKind.Local).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 2,
                column: "DateWorked",
                value: new DateTime(2023, 5, 1, 16, 18, 45, 694, DateTimeKind.Local).AddTicks(9455));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 3,
                column: "DateWorked",
                value: new DateTime(2023, 5, 1, 16, 18, 45, 694, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 4,
                column: "DateWorked",
                value: new DateTime(2023, 5, 9, 16, 18, 45, 694, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 5,
                column: "DateWorked",
                value: new DateTime(2023, 5, 9, 16, 18, 45, 694, DateTimeKind.Local).AddTicks(9473));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "DateWorked",
                value: new DateTime(2023, 5, 9, 16, 18, 45, 694, DateTimeKind.Local).AddTicks(9480));
        }
    }
}
