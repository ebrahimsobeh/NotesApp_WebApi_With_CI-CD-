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

         public NoteController(INoteService service)
        {
            _service = service;
            
        }

      

        [HttpGet]
        public  async Task<IActionResult> GetNotes()
        {
            return Ok(await _service.GetAllNotes());
        }
        
        [HttpGet]
        [Route("{id:guid}")]
        public  async Task<IActionResult> GetNoteById([FromRoute] Guid id)
        {
            var note =  await _service.GetNote(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddNote([FromBody]NoteDto AddNoteRequest)
        {
            
                
            if(AddNoteRequest.Description!= null  && AddNoteRequest.Title != null)
            {
                await _service.InsertNote(AddNoteRequest);

                return Ok("Data Inserted");

            }
            return BadRequest();
              
            
        }

        
        [HttpPut]
        public  async Task<IActionResult> UpdateNote( [FromBody]NoteDto note)
        {
            await _service.UpdateNote(note);
                return  Ok("updated");
            
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteNoteById([FromRoute] Guid id)
        { 
                

            var note = await _service.GetNote(id);
            if (note == null)
            {
                return NotFound();
            }
            await _service.DeleteNote(id);
            return Ok("data deleted");
        }
        
    }
}
