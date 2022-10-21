using AutoMapper;
using NotesApp_WebApi.Entities;
using NotesApp_WebApi.Models;

namespace NotesApp_WebApi.Helpers
{
    public class AutoMapperProfiles:Profile
    {
       public AutoMapperProfiles()
        {
            CreateMap<Note,NoteDto>().ReverseMap();

        }
    }
}
