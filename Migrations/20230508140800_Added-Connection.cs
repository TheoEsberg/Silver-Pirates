using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Silver_Pirates.Migrations
{
    /// <inheritdoc />
    public partial class AddedConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmplyeeProject",
                columns: table => new
                {
                    EmployeeProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmplyeeProject", x => x.EmployeeProjectId);
                    table.ForeignKey(
                        name: "FK_EmplyeeProject_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmplyeeProject_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmplyeeProject",
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
                value: new DateTime(2023, 5, 1, 16, 8, 0, 560, DateTimeKind.Local).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 2,
                column: "DateWorked",
                value: new DateTime(2023, 5, 1, 16, 8, 0, 560, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 3,
                column: "DateWorked",
                value: new DateTime(2023, 5, 1, 16, 8, 0, 560, DateTimeKind.Local).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 4,
                column: "DateWorked",
                value: new DateTime(2023, 5, 9, 16, 8, 0, 560, DateTimeKind.Local).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 5,
                column: "DateWorked",
                value: new DateTime(2023, 5, 9, 16, 8, 0, 560, DateTimeKind.Local).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "DateWorked",
                value: new DateTime(2023, 5, 9, 16, 8, 0, 560, DateTimeKind.Local).AddTicks(9500));

            migrationBuilder.CreateIndex(
                name: "IX_EmplyeeProject_EmployeeId",
                table: "EmplyeeProject",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmplyeeProject_ProjectId",
                table: "EmplyeeProject",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmplyeeProject");

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "DateWorked",
                value: new DateTime(2023, 5, 1, 15, 45, 7, 595, DateTimeKind.Local).AddTicks(1138));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 2,
                column: "DateWorked",
                value: new DateTime(2023, 5, 1, 15, 45, 7, 595, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 3,
                column: "DateWorked",
                value: new DateTime(2023, 5, 1, 15, 45, 7, 595, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 4,
                column: "DateWorked",
                value: new DateTime(2023, 5, 9, 15, 45, 7, 595, DateTimeKind.Local).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 5,
                column: "DateWorked",
                value: new DateTime(2023, 5, 9, 15, 45, 7, 595, DateTimeKind.Local).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "DateWorked",
                value: new DateTime(2023, 5, 9, 15, 45, 7, 595, DateTimeKind.Local).AddTicks(1223));
        }
    }
}
