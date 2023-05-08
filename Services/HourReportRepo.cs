using Silver_Pirates.Models;
using Silver_Pirates_API;

namespace Silver_Pirates.Services {

    public class HourReportRepo : IHourReport<HourReport> {

        private AppDbContext _appDbContext;
        public HourReportRepo(AppDbContext appDbContext) {
            this._appDbContext = appDbContext;
        }

        public HourReport Add(HourReport newEntity) {
            if (newEntity != null)
            {
                _appDbContext.HourReports.Add(newEntity);
                _appDbContext.SaveChanges();
                return newEntity;
            }
            else
            {
                return null;
            }
        }

        public HourReport Delete(int id) {
            var res = GetSingle(id);
            if (res != null)
            {
                _appDbContext.HourReports.Remove(res);
                _appDbContext.SaveChanges();
                return res;
            }
            return null;
        }

        public IEnumerable<HourReport> GetAll() {
            return _appDbContext.HourReports;
        }

        public HourReport GetSingle(int id) {
            return _appDbContext.HourReports.FirstOrDefault(e => e.ReportId == id);
        }

        public HourReport Update(HourReport entity) {
            throw new NotImplementedException();
        }
    }

}
