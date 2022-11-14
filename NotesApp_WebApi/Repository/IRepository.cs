using System.Collections.Generic;

namespace NotesApp_WebApi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task Insert(T obj);
        Task Update(T obj);
       Task Delete(Guid id);
       Task Save();
    }
}
