using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApp_WebApi.Contracts;
using NotesApp_WebApi.Data;
using NotesApp_WebApi.Models;

namespace NotesApp_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class NoteController : ControllerBase
    {
        private readonly IService<Note> _service;
        public NoteController(IService<Note> service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            return Ok(await _service.GetAllItems());
        }
        
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetNoteById([FromRoute] Guid id)
        {
            var note = await _service.GetById(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddNote(Note AddNoteRequest)
        {
            if(AddNoteRequest.Title !=null && AddNoteRequest.Description!=null) {
                var note = new Note()
                {
                    Title = AddNoteRequest.Title,
                    Description = AddNoteRequest.Description

                };

                await _service.Add(note);
                return Ok(note);

            }
            return BadRequest();
            
        }

        
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateNote([FromRoute] Guid id, Note updateNoteRequest)
        {
            var note = await _service.GetById(id);
            if (note != null)
            {

                await _service.Update(id, updateNoteRequest);
                return Ok(note);
            }
            return NotFound();
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteNoteById([FromRoute] Guid id)
        {
            var note = await _service.GetById(id);
            if (note != null)
            {
                await _service.Remove(id);
                return Ok(note);
            }
            return NotFound();
        }
        
    }
}
