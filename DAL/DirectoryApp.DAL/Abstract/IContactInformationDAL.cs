using DirectoryApp.Core.Entities;
using DirectoryApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.DAL.Abstract
{
    public interface IContactInformationDAL
    {
        Task<List<ContactInformation>> GetAllAsync();

        Task<List<ContactInformation>> GetContactInformationListByPersonId(Guid id);
        Task<ContactInformation> GetContactInformationByPersonId(Guid id);
        Task<bool> Add(ContactInformation contact);
        Task<bool> Save();
        Task<bool> Update(ContactInformation information);
        Task<bool> Delete(int id);

        Task<ContactInformation> GetByInformationValue(string value, string personId);
    }
}
