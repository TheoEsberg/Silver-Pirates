using Microsoft.EntityFrameworkCore;
using Silver_Pirates.Models;
using Silver_Pirates_API;

namespace Silver_Pirates.Services 
{
    public class ProjectRepo : IProject<Project> 
    {
        private AppDbContext _appDbContext;
        public ProjectRepo(AppDbContext appDbContext) 
        {
            this._appDbContext = appDbContext;
        }

        // Add a new Project
        public async Task<Project> Add(string projectName)
        {
            var newEntity = new Project();
            newEntity.Name = projectName;

            if (newEntity != null)
            {
                await _appDbContext.Projects.AddAsync(newEntity);
                await _appDbContext.SaveChangesAsync();
                return newEntity;
            }
            return null;
        }

        // Delete a current Project
        public async Task<Project> Delete(int id)
        {
            var result = await GetSingle(id);
            if (result != null) {
                _appDbContext.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        // Get all projects
        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _appDbContext.Projects.ToListAsync();
        }

        // Get a single project from ProjectId
        public async Task<Project> GetSingle(int id)
        {
            return await _appDbContext.Projects.FirstOrDefaultAsync(e => e.ProjectId == id);
        }

        // Update a project
        public async Task<Project> Update(Project entity)
        {
            var project = _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == entity.ProjectId);
            if (project != null) 
            {
                project.Name = entity.Name;
                await _appDbContext.SaveChangesAsync();
                return project;
            }
            return null;
        }
    }
}
