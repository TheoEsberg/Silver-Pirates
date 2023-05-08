using Microsoft.EntityFrameworkCore;
using Silver_Pirates_API;

namespace Silver_Pirates.Models {

    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<HourReport> HourReports { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //Employee
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, Name = "Emil", EmployeeProjects = new List<EmployeeProject>(), Hours = new List<HourReport>() },
                new Employee { EmployeeId = 2, Name = "Theo", EmployeeProjects = new List<EmployeeProject>(), Hours = new List<HourReport>() },
                new Employee { EmployeeId = 3, Name = "Lucas", EmployeeProjects = new List<EmployeeProject>(), Hours = new List<HourReport>() }
            );

            //Projects
            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectId = 1, Name = "Astro Alpha", EmployeeProjects = new List<EmployeeProject>() },
                new Project { ProjectId = 2, Name = "Apollo Sucide", EmployeeProjects = new List<EmployeeProject>() },
                new Project { ProjectId = 3, Name = "Banana Basher", EmployeeProjects = new List<EmployeeProject>() },
                new Project { ProjectId = 4, Name = "Granny Monster", EmployeeProjects = new List<EmployeeProject>() }
            );

            //Hour reports
            modelBuilder.Entity<HourReport>().HasData(
                new HourReport { ReportId = 1, EmployeeId = 1, DateWorked = DateTime.Now.AddDays(-7) },
                new HourReport { ReportId = 2, EmployeeId = 2, DateWorked = DateTime.Now.AddDays(-7) },
                new HourReport { ReportId = 3, EmployeeId = 3, DateWorked = DateTime.Now.AddDays(-7) },
                new HourReport { ReportId = 4, EmployeeId = 1, DateWorked = DateTime.Now.AddMinutes(-30) },
                new HourReport { ReportId = 5, EmployeeId = 2, DateWorked = DateTime.Now.AddMinutes(-30) },
                new HourReport { ReportId = 6, EmployeeId = 3, DateWorked = DateTime.Now.AddMinutes(-30) }
            );
           
            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject { EmployeeProjectId = 1, EmployeeId = 1, ProjectId = 2 },
                new EmployeeProject { EmployeeProjectId = 2, EmployeeId = 1, ProjectId = 4 },
                new EmployeeProject { EmployeeProjectId = 3, EmployeeId = 2, ProjectId = 2 },
                new EmployeeProject { EmployeeProjectId = 4, EmployeeId = 3, ProjectId = 1 },
                new EmployeeProject { EmployeeProjectId = 5, EmployeeId = 3, ProjectId = 3 }
            );


        }
    }
}
