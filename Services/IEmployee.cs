namespace Silver_Pirates.Services {

    public interface IEmployee<T> {

        public IEnumerable<T> GetAll();
        public T GetSingle(int id);
        public T Add(T newEntity);
        public T Update(T entity);
        public T Delete(int id);

    }

}
