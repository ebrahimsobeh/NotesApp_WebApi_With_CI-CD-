namespace NotesApp_WebApi.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(Guid id);
        void Save();
    }
}
