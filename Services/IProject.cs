﻿namespace Silver_Pirates.Services 
{
    public interface IProject<T> 
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<T> Add(string projectName);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
