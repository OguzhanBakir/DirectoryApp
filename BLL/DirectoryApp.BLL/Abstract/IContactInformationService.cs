using DirectoryApp.Core.Entities;
using DirectoryApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirectoryApp.BLL.Abstract
{
    public interface IContactInformationService
    {
        Task<Response<List<ContactInformation>>> GetAllAsync();

        Task<Response<List<ContactInformation>>> GetContactInformationListByPersonId(Guid id);
        Task<Response<ContactInformation>> GetContactInformationByPersonId(Guid id);
        Task<Response<NoContent>> Add(ContactInformation contactInformation);
        
        Task<Response<NoContent>> Update(ContactInformation contactInformation);
        Task<Response<NoContent>> Delete(int id);

        Task<Response<NoContent>> GetByInformationValue(string value, string personId);
    }
}
