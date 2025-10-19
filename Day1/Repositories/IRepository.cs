namespace Day1.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll(string? includes);
        T? GetByID(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
