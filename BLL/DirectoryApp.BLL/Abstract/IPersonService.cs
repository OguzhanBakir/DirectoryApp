using DirectoryApp.Core.Entities;
using DirectoryApp.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirectoryApp.BLL.Abstract
{
    public interface IPersonService
    {
        Task<Response<List<Person>>> GetAllAsync();
        Task<Response<Person>> GetPersonById(string id);
        Task<Response<NoContent>> Add(Person person);
        Task<Response<NoContent>> Update(Person person);
        Task<Response<NoContent>> Delete(string id);

    }
}
