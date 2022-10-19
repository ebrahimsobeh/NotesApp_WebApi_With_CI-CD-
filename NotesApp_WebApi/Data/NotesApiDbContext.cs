using Microsoft.EntityFrameworkCore;
using NotesApp_WebApi.Models;

namespace NotesApp_WebApi.Data
{
    public class NotesApiDbContext : DbContext
    {
        public NotesApiDbContext(DbContextOptions options) : base(options){
        }
        public DbSet<Note> Notes { get; set; }

    }
}
