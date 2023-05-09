using Microsoft.EntityFrameworkCore;
using Silver_Pirates.Models;
using Silver_Pirates_API;
using System.Collections;

namespace Silver_Pirates.Services {

    public class HourReportRepo : IHourReport<HourReport> {

        private AppDbContext _appDbContext;
        public HourReportRepo(AppDbContext appDbContext) {
            this._appDbContext = appDbContext;
        }

        public async Task<IEnumerable<HourReport>> GetAllHourReportsFromEmployee(int id)
        {
            var result = await _appDbContext.HourReports.Where(e => e.EmployeeId == id).ToListAsync();
            return result ?? null;
        }

        public async Task<IEnumerable<HourReport>> GetAll()
        {
            return await _appDbContext.HourReports.ToListAsync();
        }

        public async Task<HourReport> GetSingle(int id)
        {
            return await _appDbContext.HourReports.FirstOrDefaultAsync(p => p.ReportId == id);
        }

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

        public async Task<HourReport> Update(HourReport entity)
        {
            throw new NotImplementedException();
        }

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
    }

}
