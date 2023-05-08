using Silver_Pirates.Models;
using Silver_Pirates_API;

namespace Silver_Pirates.Services {

    public class ProjectRepo : IProject<Project> {

        private AppDbContext _appDbContext;
        public ProjectRepo(AppDbContext appDbContext) {
            this._appDbContext = appDbContext;
        }

        public Project Add(Project newEntity) {
            if (newEntity != null)
            {
                _appDbContext.Projects.Add(newEntity);
                _appDbContext.SaveChanges();
                return newEntity;
            }
            return null;          
        }

        public Project Delete(int id) {
            var res = GetSingle(id);
            if (res != null)
            {
                _appDbContext.Projects.Remove(res);
                _appDbContext.SaveChanges();
                return res;
            }
            return null;
        }

        public IEnumerable<Project> GetAll() {
            return _appDbContext.Projects;
        }

        public Project GetSingle(int id) {
            return _appDbContext.Projects.FirstOrDefault(e => e.ProjectId == id);
        }

        public Project Update(Project entity) {
            throw new NotImplementedException();
        }
    }

}
