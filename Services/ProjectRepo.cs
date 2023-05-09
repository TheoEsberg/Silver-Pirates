using Microsoft.EntityFrameworkCore;
using Silver_Pirates.Models;
using Silver_Pirates_API;

namespace Silver_Pirates.Services {

    public class ProjectRepo : IProject<Project> {

        private AppDbContext _appDbContext;
        public ProjectRepo(AppDbContext appDbContext) {
            this._appDbContext = appDbContext;
        }

        public async Task<Project> Add(Project newEntity)
        {
            if (newEntity != null)
            {
                await _appDbContext.Projects.AddAsync(newEntity);
                await _appDbContext.SaveChangesAsync();
                return newEntity;
            }
            return null;
        }

        public async Task<Project> Delete(int id)
        {
            var result = await GetSingle(id);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _appDbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetSingle(int id)
        {
            return await _appDbContext.Projects.FirstOrDefaultAsync(e => e.ProjectId == id);
        }

        public async Task<Project> Update(Project entity)
        {
            throw new NotImplementedException();
        }
    }

}
