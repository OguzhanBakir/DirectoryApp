using DirectoryApp.Services.CrudOperations.Models;
using DirectoryApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Services.CrudOperations.Services
{
    public interface IContactInformationService
    {
        Task<Response<List<ContactInformation>>> GetAllAsync();

        Task<Response<List<ContactInformation>>> GetContactListInformationByPersonId(Guid id);
        Task<Response<ContactInformation>> GetContactInformationByPersonId(Guid id);
        Task<Response<NoContent>> Save(ContactInformation information);
        Task<Response<NoContent>> Update(ContactInformation information);
        Task<Response<NoContent>> Delete(int id);
    }
}
