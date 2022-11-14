using NotesApp_WebApi.Entities;
using NotesApp_WebApi.Models;
using System.Collections.Generic;

namespace NotesApp_WebApi.Services
{
    public interface INoteService
    {
        Task<IEnumerable<NoteDto>> GetAllNotes();
        Task<NoteDto> GetNote(Guid id);
        Task InsertNote(NoteDto note);
        Task UpdateNote(NoteDto note);
        Task DeleteNote(Guid
            id);


    }
}
