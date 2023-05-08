using Microsoft.EntityFrameworkCore;
using Silver_Pirates_API;

namespace Silver_Pirates.Models {

    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<HourReport> HourReports { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //Employee
            modelBuilder.Entity<Employee>().HasData(new Employee {
                EmployeeId = 1,
                Name = "Emil",
                Projects = new List<Project>(),
                Hours = new List<HourReport>()
            });
            modelBuilder.Entity<Employee>().HasData(new Employee {
                EmployeeId = 2,
                Name = "Theo",
                Projects = new List<Project>(),
                Hours = new List<HourReport>()
            });
            modelBuilder.Entity<Employee>().HasData(new Employee {
                EmployeeId = 3,
                Name = "Emil",
                Projects = new List<Project>(),
                Hours = new List<HourReport>()
            });

            //Projects
            modelBuilder.Entity<Project>().HasData(new Project {
                ProjectId = 1,
                Name = "Astro Alpha",
                Employees = new List<Employee>()
            });
            modelBuilder.Entity<Project>().HasData(new Project {
                ProjectId = 2,
                Name = "Apollo Sucide",
                Employees = new List<Employee>()
            });
            modelBuilder.Entity<Project>().HasData(new Project {
                ProjectId = 3,
                Name = "Banana Basher",
                Employees = new List<Employee>()
            });
            modelBuilder.Entity<Project>().HasData(new Project {
                ProjectId = 4,
                Name = "Granny Monster",
                Employees = new List<Employee>()
            });

            //Hour reports
            // week 1
            modelBuilder.Entity<HourReport>().HasData(new HourReport {
                ReportId = 1,
                EmployeeId = 1,
                DateWorked = DateTime.Now.AddDays(-7),
            });
            modelBuilder.Entity<HourReport>().HasData(new HourReport {
                ReportId = 2,
                EmployeeId = 2,
                DateWorked = DateTime.Now.AddDays(-7),
            });
            modelBuilder.Entity<HourReport>().HasData(new HourReport {
                ReportId = 3,
                EmployeeId = 3,
                DateWorked = DateTime.Now.AddDays(-7),
            });
            // week 2
            modelBuilder.Entity<HourReport>().HasData(new HourReport {
                ReportId = 4,
                EmployeeId = 1,
                DateWorked = DateTime.Now.AddDays(1),
            });
            modelBuilder.Entity<HourReport>().HasData(new HourReport {
                ReportId = 5,
                EmployeeId = 2,
                DateWorked = DateTime.Now.AddDays(1),
            });
            modelBuilder.Entity<HourReport>().HasData(new HourReport {
                ReportId = 6,
                EmployeeId = 3,
                DateWorked = DateTime.Now.AddDays(1),
            });

        }

    }

}
