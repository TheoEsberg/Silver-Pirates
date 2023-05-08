using Microsoft.EntityFrameworkCore;
using Silver_Pirates.Models;
using Silver_Pirates_API;
using System.Text;

namespace Silver_Pirates.Services {

    public class EmployeeRepo : IEmployee<Employee> {

        private AppDbContext _appDbContext;
        public EmployeeRepo(AppDbContext appDbContext) {
            this._appDbContext = appDbContext;
        }

        public Employee Add(Employee newEntity) {
            
            if (newEntity != null) {
                _appDbContext.Employees.Add(newEntity);
                _appDbContext.SaveChanges();
                return newEntity;
            } 
            return null;
        }

        public Employee Delete(int id) {

            //Finds an employeee with the id given
            var res = GetSingle(id);
            if (res != null) {
                _appDbContext.Employees.Remove(res);
                _appDbContext.SaveChanges();
                return res;
            }
            return null;

        }

        public IEnumerable<Employee> GetAll() {
            
            return _appDbContext.Employees;

        }

        public Employee GetSingle(int id) {

            return _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == id);

        }

        public Employee Update(Employee entity) {

            var employee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == entity.EmployeeId);
            if (employee != null) {
                employee.Name = entity.Name;
                return employee;
            } else {
                return null;
            }

        }

    }

}
