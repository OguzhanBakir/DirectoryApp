using DirectoryApp.Shared.Dtos;
using DirectoryApp.Web.Dtos;
using DirectoryApp.Web.Models.ContactInformations;
using DirectoryApp.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static DirectoryApp.Web.Definitions.StaticDefinition;

namespace DirectoryApp.Web.Services
{
    public class ContactInformationService: IContactInformationService
    {
        private readonly HttpClient _client;


        public ContactInformationService(HttpClient client)
        {
            _client = client;


        }

        public async Task<List<ContactInformationViewModel>> GetContactInformationByPersonId(string personId)
        {
            var response = await _client.GetAsync($"{apiBaseUrl}/api/ContactInformation/{personId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }


            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ContactInformationViewModel>>>();

            

            return responseSuccess.Data;
        }

        public async Task<List<ContactInformation>> GetContactListInformationByPersonId(string personId)
        {
            var response = await _client.GetAsync($"{apiBaseUrl}/api/ContactInformation/{personId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }


            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ContactInformation>>>();



            return responseSuccess.Data;
        }

        public async Task<bool> AddContactInformationAsync(ContactInformationAddViewModel model)
        {
            var response = await _client.PostAsJsonAsync($"{apiBaseUrl}/api/ContactInformation/Create", model);
            return response.IsSuccessStatusCode;

        }

        public async Task<bool> DeleteContactInformationAsync(int id)
        {
            var response = await _client.DeleteAsync($"{apiBaseUrl}/api/ContactInformation/Delete/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
