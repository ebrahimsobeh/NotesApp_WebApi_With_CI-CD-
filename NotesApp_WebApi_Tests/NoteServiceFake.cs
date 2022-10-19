using Microsoft.EntityFrameworkCore;
using NotesApp_WebApi.Contracts;
using NotesApp_WebApi.Data;
using NotesApp_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp_WebApi_Tests
{
    public class NoteServiceFake : IService<Note>
    {
        private readonly List<Note> _Notes;

        public NoteServiceFake()
        {
            _Notes = new List<Note>()
            {
                new Note() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Title = "Orange Juice", Description="Orange Tree"},
                new Note() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    Title = "Apple Juice", Description="Apple Tree"},
                new Note() { Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                    Title = "Mango Juice", Description="Mango Tree"},
            };
        }


        public async Task<Note> Add(Note newItem)
        {
            newItem.Id = Guid.NewGuid();
             _Notes.Add(newItem);
            return newItem;

        } 

        public async Task<IEnumerable<Note>> GetAllItems()
        {
            return  _Notes;
        }

        public  async Task<Note> GetById(Guid id)
        {
            return _Notes.Where(a => a.Id == id)
                           .FirstOrDefault();
        }

        public async Task<Note> Remove(Guid id)
        {
            var existing =  _Notes.First(a => a.Id == id);
             _Notes.Remove(existing);
            return existing;
        }

        public Task<Note> Update(Guid id, Note newItem)
        {
            throw new NotImplementedException();
        }
    }
}
