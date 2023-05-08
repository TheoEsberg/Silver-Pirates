using Silver_Pirates.Models;
using Silver_Pirates_API;

namespace Silver_Pirates.Services {
    public class EmployeeProjectRepo : IEmployeeProject<EmployeeProject> {

        private AppDbContext _appDbContext;
        public EmployeeProjectRepo(AppDbContext appDbContext) {
            this._appDbContext = appDbContext;
        }

        public EmployeeProject Add(EmployeeProject newEntity)
        {
            if (newEntity != null)
            {
                _appDbContext.EmployeeProjects.Add(newEntity);
                _appDbContext.SaveChanges();
                return newEntity;
            }
            else
            {
                return null;
            }
        }

        public EmployeeProject Delete(int id)
        {
            var res = GetSingle(id);
            if (res != null)
            {
                _appDbContext.EmployeeProjects.Remove(res);
                _appDbContext.SaveChanges();
                return res;
            }
            return null;
        }

        public IEnumerable<EmployeeProject> GetAll()
        {
            return _appDbContext.EmployeeProjects;
        }

        public EmployeeProject GetSingle(int id)
        {
            return _appDbContext.EmployeeProjects.FirstOrDefault(e => e.EmployeeProjectId == id);
        }

        public EmployeeProject Update(EmployeeProject entity)
        {
            throw new NotImplementedException();
        }
    }
}
