﻿namespace Silver_Pirates.Services 
{
    public interface IEmployeeProject<T> 
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<T> Add(int EmployeeId,int ProjectId);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }

}
