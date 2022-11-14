using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NotesApp_WebApi.Models
{
 
    public class NoteDto
    {
        public Guid Id { get; set; }
        
        public String Title { get; set; }
   
        public string Description { get; set; }
    }
}
