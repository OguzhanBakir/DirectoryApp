using DirectoryApp.Web.Dtos;
using DirectoryApp.Web.Models.ContactInformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Web.Services.Interfaces
{
    public interface IContactInformationService
    {
        Task<List<ContactInformationViewModel>> GetContactInformationByPersonId(string id);
        Task<List<ContactInformation>> GetContactListInformationByPersonId(string id);
        Task<bool> AddContactInformationAsync(ContactInformationAddViewModel contactInformationAddViewModel);
        Task<bool> DeleteContactInformationAsync(int id);
    }
}
