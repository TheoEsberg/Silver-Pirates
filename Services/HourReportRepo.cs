using Microsoft.EntityFrameworkCore;
using Silver_Pirates.Models;
using Silver_Pirates_API;
using System.Globalization;

namespace Silver_Pirates.Services {

    public class HourReportRepo : IHourReport<HourReport> {

        private AppDbContext _appDbContext;
        public HourReportRepo(AppDbContext appDbContext) {
            this._appDbContext = appDbContext;
        }

        // Get all Hour Reports
        public async Task<IEnumerable<HourReport>> GetAll()
        {
            return await _appDbContext.HourReports.ToListAsync();
        }

        // Get a single Hour Report from HourReportId
        public async Task<HourReport> GetSingle(int id)
        {
            return await _appDbContext.HourReports.FirstOrDefaultAsync(p => p.ReportId == id);
        }

        // Add a new Hour Report 
        public async Task<HourReport> Add(HourReport newEntity)
        {
            if (newEntity != null)
            {
                await _appDbContext.HourReports.AddAsync(newEntity);
                await _appDbContext.SaveChangesAsync();
                return newEntity;
            }
            return null;
        }

        // Update a current Hour Report 
        public async Task<HourReport> Update(HourReport entity)
        {
            var hourReport = _appDbContext.HourReports.FirstOrDefault(p => p.ReportId == entity.ReportId);
            if (hourReport != null) {
                hourReport.ReportId = entity.ReportId;
                hourReport.EmployeeId = entity.EmployeeId;
                hourReport.DateWorked = entity.DateWorked;
                await _appDbContext.SaveChangesAsync();
                return hourReport;
            }
            return null;
        }

        // Delete a current Hour Report
        public async Task<HourReport> Delete(int id)
        {
            var result = await GetSingle(id);
            if (result != null)
            {
                _appDbContext.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        // Get all Hour Reports bind to a Employee by EmployeeId
        public async Task<IEnumerable<HourReport>> GetAllHourReportsFromEmployee(int id)
        {
            var result = await _appDbContext.HourReports.Where(e => e.EmployeeId == id).ToListAsync();
            return result ?? null;
        }

        // Get all the Hours a Employee have worked on a specific week
        public async Task<double> GetAllHourReportsFromEmployeeByWeek(int id, int week)
        {
            var hourReports = await GetAllHourReportsFromEmployee(id);
            double totalHoursWorked = 0;
            foreach(HourReport hr in hourReports)
            {
                DateTime date = hr.DateWorked;
                CultureInfo culture = CultureInfo.CurrentCulture;
                CalendarWeekRule weekRule = culture.DateTimeFormat.CalendarWeekRule;
                DayOfWeek firstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;
                int weekNumber = culture.Calendar.GetWeekOfYear(date, weekRule, firstDayOfWeek);
                if (weekNumber == week)
                {
                    totalHoursWorked += hr.HoursWorked;
                }
            }
            return totalHoursWorked;
        }
    }
}
