﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Silver_Pirates.Models;

#nullable disable

namespace Silver_Pirates.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Silver_Pirates_API.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Name = "Emil"
                        },
                        new
                        {
                            EmployeeId = 2,
                            Name = "Theo"
                        },
                        new
                        {
                            EmployeeId = 3,
                            Name = "Lucas"
                        });
                });

            modelBuilder.Entity("Silver_Pirates_API.EmployeeProject", b =>
                {
                    b.Property<int>("EmployeeProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeProjectId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeProjectId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProjects");

                    b.HasData(
                        new
                        {
                            EmployeeProjectId = 1,
                            EmployeeId = 1,
                            ProjectId = 2
                        },
                        new
                        {
                            EmployeeProjectId = 2,
                            EmployeeId = 1,
                            ProjectId = 4
                        },
                        new
                        {
                            EmployeeProjectId = 3,
                            EmployeeId = 2,
                            ProjectId = 2
                        },
                        new
                        {
                            EmployeeProjectId = 4,
                            EmployeeId = 3,
                            ProjectId = 1
                        },
                        new
                        {
                            EmployeeProjectId = 5,
                            EmployeeId = 3,
                            ProjectId = 3
                        });
                });

            modelBuilder.Entity("Silver_Pirates_API.HourReport", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportId"));

                    b.Property<DateTime>("DateWorked")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("ReportId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("HourReports");

                    b.HasData(
                        new
                        {
                            ReportId = 1,
                            DateWorked = new DateTime(2023, 5, 1, 16, 20, 43, 830, DateTimeKind.Local).AddTicks(2526),
                            EmployeeId = 1
                        },
                        new
                        {
                            ReportId = 2,
                            DateWorked = new DateTime(2023, 5, 1, 16, 20, 43, 830, DateTimeKind.Local).AddTicks(2573),
                            EmployeeId = 2
                        },
                        new
                        {
                            ReportId = 3,
                            DateWorked = new DateTime(2023, 5, 1, 16, 20, 43, 830, DateTimeKind.Local).AddTicks(2579),
                            EmployeeId = 3
                        },
                        new
                        {
                            ReportId = 4,
                            DateWorked = new DateTime(2023, 5, 9, 16, 20, 43, 830, DateTimeKind.Local).AddTicks(2585),
                            EmployeeId = 1
                        },
                        new
                        {
                            ReportId = 5,
                            DateWorked = new DateTime(2023, 5, 9, 16, 20, 43, 830, DateTimeKind.Local).AddTicks(2592),
                            EmployeeId = 2
                        },
                        new
                        {
                            ReportId = 6,
                            DateWorked = new DateTime(2023, 5, 9, 16, 20, 43, 830, DateTimeKind.Local).AddTicks(2600),
                            EmployeeId = 3
                        });
                });

            modelBuilder.Entity("Silver_Pirates_API.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            Name = "Astro Alpha"
                        },
                        new
                        {
                            ProjectId = 2,
                            Name = "Apollo Sucide"
                        },
                        new
                        {
                            ProjectId = 3,
                            Name = "Banana Basher"
                        },
                        new
                        {
                            ProjectId = 4,
                            Name = "Granny Monster"
                        });
                });

            modelBuilder.Entity("Silver_Pirates_API.EmployeeProject", b =>
                {
                    b.HasOne("Silver_Pirates_API.Employee", "Employee")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Silver_Pirates_API.Project", "Project")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Silver_Pirates_API.HourReport", b =>
                {
                    b.HasOne("Silver_Pirates_API.Employee", "Employee")
                        .WithMany("Hours")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Silver_Pirates_API.Employee", b =>
                {
                    b.Navigation("EmployeeProjects");

                    b.Navigation("Hours");
                });

            modelBuilder.Entity("Silver_Pirates_API.Project", b =>
                {
                    b.Navigation("EmployeeProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
