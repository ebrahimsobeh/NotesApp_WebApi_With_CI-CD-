using Microsoft.EntityFrameworkCore;
using NotesApp_WebApi.Entities;

namespace NotesApp_WebApi.Data
{
    public class NotesApiDbContext : DbContext
    {
         

        public NotesApiDbContext(DbContextOptions options) : base(options){
        }
        public DbSet<Note> Notes { get; set; }

    }
}
