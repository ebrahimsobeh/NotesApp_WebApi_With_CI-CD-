using Malak.BLL.Core.Common;
using NotesApp_WebApi.Models;

namespace NotesApp_WebApi.Contracts
{
   
    public interface IService<T> where T : class 
    {
        Task<IEnumerable<T>>  GetAllItems();
        Task<T> Add(T newItem);
        Task<T> GetById(Guid id);
        Task<T> Remove(Guid id);
        Task<T> Update(Guid id,T newItem);


    }
}
