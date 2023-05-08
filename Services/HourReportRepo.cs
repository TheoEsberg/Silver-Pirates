using Silver_Pirates.Models;
using Silver_Pirates_API;

namespace Silver_Pirates.Services {

    public class HourReportRepo : IHourReport<HourReport> {

        private AppDbContext _appDbContext;
        public HourReportRepo(AppDbContext appDbContext) {
            this._appDbContext = appDbContext;
        }

        public HourReport Add(HourReport newEntity) {
            throw new NotImplementedException();
        }

        public HourReport Delete(int id) {
            throw new NotImplementedException();
        }

        public IEnumerable<HourReport> GetAll() {
            throw new NotImplementedException();
        }

        public HourReport GetSingle(int id) {
            throw new NotImplementedException();
        }

        public HourReport Update(HourReport entity) {
            throw new NotImplementedException();
        }
    }

}
