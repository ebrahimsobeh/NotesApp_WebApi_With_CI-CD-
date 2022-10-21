using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApp_WebApi.Contracts;
using NotesApp_WebApi.Data;
using NotesApp_WebApi.Models;
using NotesApp_WebApi.Services;

namespace NotesApp_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class NoteController : ControllerBase
    {
        private readonly INoteService _service;

         public NoteController(INoteService service, IMapper mapper)
        {
            _service = service;
            
        }


        [HttpGet]
        public  IActionResult GetNotes()
        {
            return Ok(_service.GetAllNotes());
        }
        
        [HttpGet]
        [Route("{id:guid}")]
        public  IActionResult GetNoteById([FromRoute] Guid id)
        {
            var note =  _service.GetNote(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }
        
        [HttpPost]
        public IActionResult AddNote([FromBody]NoteDto AddNoteRequest)
        {
            
                

                _service.InsertNote(AddNoteRequest);

                return Ok("Data Inserted");
            
        }

        
        [HttpPut]
        public  IActionResult UpdateNote( [FromBody]NoteDto note)
        {
            _service.UpdateNote(note);
                return Ok("updated");
            
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteNoteById([FromRoute] Guid id)
        { 
                 _service.DeleteNote(id);
                return Ok("data deleted");
           
        }
        
    }
}
