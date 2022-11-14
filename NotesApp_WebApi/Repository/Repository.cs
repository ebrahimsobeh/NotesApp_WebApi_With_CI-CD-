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
        public async Task<IEnumerable<T>> GetAll()
        {
            return  await table.ToListAsync();
        }
        public async Task<T> GetById(Guid id)
        {
            return await table.FindAsync(id);
        }
        public async Task Insert(T obj)
        {
            await table.AddAsync(obj);
        }
        public async Task Update(T obj)
        {
             table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public async Task Delete(Guid id)
        {
            T existing =await table.FindAsync(id);
            table.Remove(existing);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }

}
