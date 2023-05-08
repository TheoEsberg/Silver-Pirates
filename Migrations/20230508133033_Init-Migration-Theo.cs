using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Silver_Pirates.Migrations
{
    /// <inheritdoc />
    public partial class InitMigrationTheo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "HourReports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateWorked = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourReports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_HourReports_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Name" },
                values: new object[,]
                {
                    { 1, "Emil" },
                    { 2, "Theo" },
                    { 3, "Emil" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Name" },
                values: new object[,]
                {
                    { 1, "Astro Alpha" },
                    { 2, "Apollo Sucide" },
                    { 3, "Banana Basher" },
                    { 4, "Granny Monster" }
                });

            migrationBuilder.InsertData(
                table: "HourReports",
                columns: new[] { "ReportId", "DateWorked", "EmployeeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 1, 15, 30, 33, 336, DateTimeKind.Local).AddTicks(3404), 1 },
                    { 2, new DateTime(2023, 5, 1, 15, 30, 33, 336, DateTimeKind.Local).AddTicks(3461), 2 },
                    { 3, new DateTime(2023, 5, 1, 15, 30, 33, 336, DateTimeKind.Local).AddTicks(3467), 3 },
                    { 4, new DateTime(2023, 5, 9, 15, 30, 33, 336, DateTimeKind.Local).AddTicks(3473), 1 },
                    { 5, new DateTime(2023, 5, 9, 15, 30, 33, 336, DateTimeKind.Local).AddTicks(3479), 2 },
                    { 6, new DateTime(2023, 5, 9, 15, 30, 33, 336, DateTimeKind.Local).AddTicks(3487), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectsProjectId",
                table: "EmployeeProject",
                column: "ProjectsProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_HourReports_EmployeeId",
                table: "HourReports",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "HourReports");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
