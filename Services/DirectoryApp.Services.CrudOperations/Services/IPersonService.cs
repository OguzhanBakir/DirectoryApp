using DirectoryApp.Services.CrudOperations.Data;
using DirectoryApp.Services.CrudOperations.Models;
using DirectoryApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Services.CrudOperations.Services
{
    public interface IPersonService
    {
        Task<Response<List<Person>>> GetAllAsync();


        Task<Response<Person>> GetPersonById(string id);
        Task<Response<NoContent>> Save(Person person);
        Task<Response<NoContent>> Update(Person person);
        Task<Response<NoContent>> Delete(string id);

    }
}
