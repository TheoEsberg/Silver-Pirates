using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Silver_Pirates.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeProjectForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.CreateTable(
                name: "EmployeeProjects",
                columns: table => new
                {
                    EmployeeProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjects", x => x.EmployeeProjectId);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_EmployeeId",
                table: "EmployeeProjects",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_ProjectId",
                table: "EmployeeProjects",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProjects");

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    EmployeesEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectsProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.EmployeesEmployeeId, x.ProjectsProjectId });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "DateWorked",
                value: new DateTime(2023, 5, 1, 16, 10, 55, 151, DateTimeKind.Local).AddTicks(2965));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 2,
                column: "DateWorked",
                value: new DateTime(2023, 5, 1, 16, 10, 55, 151, DateTimeKind.Local).AddTicks(3012));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 3,
                column: "DateWorked",
                value: new DateTime(2023, 5, 1, 16, 10, 55, 151, DateTimeKind.Local).AddTicks(3017));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 4,
                column: "DateWorked",
                value: new DateTime(2023, 5, 9, 16, 10, 55, 151, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 5,
                column: "DateWorked",
                value: new DateTime(2023, 5, 9, 16, 10, 55, 151, DateTimeKind.Local).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "HourReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "DateWorked",
                value: new DateTime(2023, 5, 9, 16, 10, 55, 151, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectsProjectId",
                table: "EmployeeProject",
                column: "ProjectsProjectId");
        }
    }
}
