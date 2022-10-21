using Microsoft.EntityFrameworkCore;
using NotesApp_WebApi.Data;

namespace NotesApp_WebApi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly NotesApiDbContext _context ;
        private readonly DbSet<T> table;
        
        public Repository(NotesApiDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(Guid id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(Guid id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
