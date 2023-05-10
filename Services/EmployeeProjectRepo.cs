using Microsoft.EntityFrameworkCore;
using Silver_Pirates.Models;
using Silver_Pirates_API;

namespace Silver_Pirates.Services 
{
    public class EmployeeProjectRepo : IEmployeeProject<EmployeeProject> 
    {

        private AppDbContext _appDbContext;
        public EmployeeProjectRepo(AppDbContext appDbContext) 
        {
            this._appDbContext = appDbContext;
        }

        // Add a new relation between an Employee and Project
        public async Task<EmployeeProject> Add(EmployeeProject newEntity)
        {
            if (newEntity != null)
            {
                await _appDbContext.AddAsync(newEntity);
                await _appDbContext.SaveChangesAsync();
                return newEntity;
            }
            return null;
        }

        // Delete a current relation between Employee and Project 
        public async Task<EmployeeProject> Delete(int id)
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

        // Get all relations between Employee and Projects
        public async Task<IEnumerable<EmployeeProject>> GetAll()
        {
            return await _appDbContext.EmployeeProjects.ToListAsync();
        }

        // Get a single EmployeeProjects relation
        public async Task<EmployeeProject> GetSingle(int id)
        {
            return await _appDbContext.EmployeeProjects.FirstOrDefaultAsync(e => e.EmployeeProjectId == id);
        }

        // Update a current EmployeeProject relation
        public async Task<EmployeeProject> Update(EmployeeProject entity)
        {
            var employeProject = _appDbContext.EmployeeProjects.FirstOrDefault(p => p.EmployeeProjectId == entity.EmployeeId);
            if (employeProject != null) 
            {
                employeProject.EmployeeId = entity.EmployeeId;
                employeProject.ProjectId = entity.ProjectId;

                await _appDbContext.SaveChangesAsync();
                return employeProject;
            }
            return null;
        }
    }
}
