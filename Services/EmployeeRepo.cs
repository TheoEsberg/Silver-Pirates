using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Silver_Pirates.Models;
using Silver_Pirates_API;
using System.Text;

namespace Silver_Pirates.Services {

    public class EmployeeRepo : IEmployee<Employee> {

        private AppDbContext _appDbContext;
        public EmployeeRepo(AppDbContext appDbContext) {
            this._appDbContext = appDbContext;
        }

        public async Task<Employee> Add(Employee newEntity)
        {
            if (newEntity != null)
            {
                await _appDbContext.AddAsync(newEntity);
                await _appDbContext.SaveChangesAsync();
                return newEntity;
            }
            return null;
        }

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

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetSingle(int id)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(p => p.EmployeeId == id);
        }

        public async Task<Employee> Update(Employee entity)
        {
            var employee = _appDbContext.Employees.FirstOrDefault(p => p.EmployeeId == entity.EmployeeId);
            if (employee != null) {
                employee.Name = entity.Name;
                await _appDbContext.SaveChangesAsync();
                return employee;
            }
            return null;
        }

        //public Employee Update(Employee entity) {
        //    var employee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == entity.EmployeeId);
        //    if (employee != null) {
        //        employee.Name = entity.Name;
        //        _appDbContext.SaveChangesAsync();
        //        return employee;
        //    } else {
        //        return null;
        //    }
        //}

    }

}
