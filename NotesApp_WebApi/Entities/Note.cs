using System.Text.Json.Serialization;

namespace NotesApp_WebApi.Entities
{
 
    public class Note
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public string Description { get; set; }
    }
}
