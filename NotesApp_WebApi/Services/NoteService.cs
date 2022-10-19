using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApp_WebApi.Contracts;
using NotesApp_WebApi.Data;
using NotesApp_WebApi.Models;

namespace NotesApp_WebApi.Services
{
    public class NoteService : IService<Note>
    {
        private readonly NotesApiDbContext dbContext;

        public NoteService(NotesApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Note>> GetAllItems()
        {
            return await dbContext.Notes.ToListAsync();
        }
        public async Task<Note> Add(Note newItem)
        {
            var note = new Note()
            {
                Title = newItem.Title,
                Description = newItem.Description
            };

            await dbContext.Notes.AddAsync(note);
            await dbContext.SaveChangesAsync();
            
            return note;
        }

        

        public async Task<Note> GetById(Guid id)
        {
            var note = await dbContext.Notes.FindAsync(id);
            if (note != null)
            {
                return note;
            }
            return null;

        }

        public async Task<Note> Remove(Guid id)
        {
            var note = await dbContext.Notes.FindAsync(id);
            if (note != null)
            {
                 dbContext.Notes.Remove(note);
                await dbContext.SaveChangesAsync();
                return note;
            }
            return null;
        }

        public async Task<Note> Update(Guid id,Note newItem)
        {
            var note = await dbContext.Notes.FindAsync(id);
            if (note != null)
            {
                note.Title = newItem.Title;
                note.Description = newItem.Description;
                
                dbContext.Update(note);
                dbContext.SaveChangesAsync();
                
                return note;
            }
            return null;


        }
    }
}
