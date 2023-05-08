using Silver_Pirates_API;

namespace Silver_Pirates.Services {

    public interface IHourReport<T> {

        public IEnumerable<T> GetAll();
        public T GetSingle(int id);
        public T Add(T newEntity);
        public T Update(T entity);
        public T Delete(int id);
        public IEnumerable<T> GetAllHourReportsFromEmployee(int id);
    }

}
