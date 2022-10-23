using DirectoryApp.Web.Models.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Web.Services.Interfaces
{
    public interface IPersonService
    {
        Task<List<PersonViewModel>> GetAllPersonAsync();
        Task<bool> DeletePersonAsync(string personId);
        Task<bool> CreatePersonAsync(PersonCreateInput personCreateInput);
        Task<bool> UpdatePersonAsync(PersonUpdateInput personUpdateInput);
        Task<PersonViewModel> GetPersonById(string personId);
    }
}
