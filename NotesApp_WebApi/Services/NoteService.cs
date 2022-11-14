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

        public async Task DeleteNote(Guid id)
        {
            Note note =await _noteRepository.GetById(id);

            //GetNote(id);
              _noteRepository.Delete(note.Id);
              _noteRepository.Save();

        }

        public async Task<IEnumerable<NoteDto>> GetAllNotes()
        {
            return _mapper.Map<IEnumerable<NoteDto>>(await _noteRepository.GetAll());

        }

        public async Task<NoteDto> GetNote(Guid id)
        {
           
            return _mapper.Map<NoteDto>(_noteRepository.GetById(id));
         
        }

        public async Task InsertNote(NoteDto notedto)
        { 
            await _noteRepository.Insert(_mapper.Map<Note>(notedto));
            await _noteRepository.Save();
            
        }

        public async Task UpdateNote(NoteDto notedto)
        {
            await _noteRepository.Update(_mapper.Map<Note>(notedto));
            await _noteRepository.Save();

        }
    }
}
