using NotesApp_WebApi.Entities;
using NotesApp_WebApi.Models;
using System.Collections.Generic;

namespace NotesApp_WebApi.Services
{
    public interface INoteService
    {
        IEnumerable<NoteDto> GetAllNotes();
        Note GetNote(Guid id);
        void InsertNote(NoteDto note);
        void UpdateNote(NoteDto note);
        void DeleteNote(Guid
            id);

    }
}
