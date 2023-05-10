namespace Silver_Pirates.Services 
{

    public interface IEmployee<T> 
    {

        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetEmployeesForProject(int id);
        Task<T> GetSingle(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);

    }

}
