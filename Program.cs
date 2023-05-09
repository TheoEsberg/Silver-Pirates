using Microsoft.EntityFrameworkCore;
using Silver_Pirates.Models;
using Silver_Pirates.Services;
using Silver_Pirates_API;

namespace Silver_Pirates
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IEmployee<Employee>, EmployeeRepo>();
            builder.Services.AddScoped<IProject<Project>, ProjectRepo>();
            builder.Services.AddScoped<IEmployeeProject<EmployeeProject>, EmployeeProjectRepo>();
            builder.Services.AddScoped<IHourReport<HourReport>, HourReportRepo>();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Connection-Emil")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}