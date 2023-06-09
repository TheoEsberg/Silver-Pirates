﻿using Silver_Pirates_API;

namespace Silver_Pirates.Services 
{
    public interface IHourReport<T> 
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<T> Add(double hoursWorked, int employeeId, DateTime startDate);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<IEnumerable<T>> GetAllHourReportsFromEmployee(int id);
        Task<double> GetAllHourReportsFromEmployeeByWeek(int id, int week);
    }

}
