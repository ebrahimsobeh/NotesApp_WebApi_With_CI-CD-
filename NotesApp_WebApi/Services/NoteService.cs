using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApp_WebApi.Contracts;
using NotesApp_WebApi.Data;
using NotesApp_WebApi.Entities;
using NotesApp_WebApi.Models;
using NotesApp_WebApi.Entities;

using NotesApp_WebApi.Repository;

namespace NotesApp_WebApi.Services
{
    public class NoteService : INoteService
    {
        private IRepository<Note> _noteRepository;
        private readonly IMapper _mapper;


        public NoteService(IRepository<Note> noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            this._mapper = mapper;

        }

        public void DeleteNote(Guid id)
        {
            Note note = GetNote(id);

            //GetNote(id);
            _noteRepository.Delete(note.Id);
            _noteRepository.Save();

        }

        public IEnumerable<NoteDto> GetAllNotes()
        {
            return _mapper.Map<IEnumerable<NoteDto>>(_noteRepository.GetAll());

        }

        public Note GetNote(Guid id)
        {
           return _noteRepository.GetById(id);
        }

        public void InsertNote(NoteDto notedto)
        { 
            _noteRepository.Insert(_mapper.Map<Note>(notedto));
            _noteRepository.Save();
            
        }

        public void UpdateNote(NoteDto notedto)
        {
            _noteRepository.Update(_mapper.Map<Note>(notedto));
            _noteRepository.Save();

        }
    }
}
