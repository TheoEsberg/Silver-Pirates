using Silver_Pirates.Models;
using Silver_Pirates_API;

namespace Silver_Pirates.Services {

    public class ProjectRepo : IProject<Project> {

        private AppDbContext _appDbContext;
        public ProjectRepo(AppDbContext appDbContext) {
            this._appDbContext = appDbContext;
        }

        public Project Add(Project newEntity) {
            throw new NotImplementedException();
        }

        public Project Delete(int id) {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAll() {
            throw new NotImplementedException();
        }

        public Project GetSingle(int id) {
            throw new NotImplementedException();
        }

        public Project Update(Project entity) {
            throw new NotImplementedException();
        }
    }

}
