using Microsoft.EntityFrameworkCore;
using Silver_Pirates.Models;
using Silver_Pirates_API;

namespace Silver_Pirates.Services 
{
    public class EmployeeRepo : IEmployee<Employee> 
    {

        private AppDbContext _appDbContext;
        public EmployeeRepo(AppDbContext appDbContext) 
        {
            this._appDbContext = appDbContext;
        }

        // Add a new Employee
        public async Task<Employee> Add(string name)
        {
            var newEntity = new Employee();
            newEntity.Name = name;

            if (newEntity != null)
            {
                await _appDbContext.Employees.AddAsync(newEntity);
                await _appDbContext.SaveChangesAsync();
                return newEntity;
            }
            return null;
        }

        // Remove an existing Employee
        public async Task<Employee> Delete(int id)
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

        // Get all Employees
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        // Get a Employee for a specific project
        public async Task<IEnumerable<Employee>> GetEmployeesForProject(int id)
        {
            var result = await _appDbContext.EmployeeProjects.Where(p => p.ProjectId == id).Select(e => e.Employee).ToListAsync();
            if (result.Count()>0)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        // Get an Employee from EmployeeId
        public async Task<Employee> GetSingle(int id)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(p => p.EmployeeId == id);
        }

        // Update a current Employee
        public async Task<Employee> Update(Employee entity)
        {
            var employee = _appDbContext.Employees.FirstOrDefault(p => p.EmployeeId == entity.EmployeeId);
            if (employee != null) 
            {
                employee.Name = entity.Name;
                await _appDbContext.SaveChangesAsync();
                return employee;
            }
            return null;
        }
    }
}
