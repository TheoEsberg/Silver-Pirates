using Silver_Pirates.Models;
using Silver_Pirates_API;

namespace Silver_Pirates.Services {
    public class EmployeeProjectRepo : IEmployeeProject<EmployeeProject> {

        private AppDbContext _appDbContext;
        public EmployeeProjectRepo(AppDbContext appDbContext) {
            this._appDbContext = appDbContext;
        }
        
    }
}
