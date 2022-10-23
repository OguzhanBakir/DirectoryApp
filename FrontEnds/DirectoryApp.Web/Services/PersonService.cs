using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DirectoryApp.Shared.Dtos;
using DirectoryApp.Web.Models.Persons;
using DirectoryApp.Web.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using static DirectoryApp.Web.Definitions.StaticDefinition;

namespace DirectoryApp.Web.Services
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _client;


        public PersonService(HttpClient client)
        {
            _client = client;
         

        }

        public async Task<PersonViewModel> GetPersonById(string personId)
        {
            var response = await _client.GetAsync($"{apiBaseUrl}/api/Person/{personId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<PersonViewModel>>();

            
            return responseSuccess.Data;
        }


        public async Task<bool> DeletePersonAsync(string personId)
        {
            var response = await _client.DeleteAsync($"{apiBaseUrl}/api/Person/{personId}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<PersonViewModel>> GetAllPersonAsync()
        {
            var response = await _client.GetAsync($"{apiBaseUrl}/api/Person");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<PersonViewModel>>>();

            return responseSuccess.Data;
        }

        public async Task<bool> CreatePersonAsync(PersonCreateInput personCreateInput)
        {
          

            var response = await _client.PostAsJsonAsync<PersonCreateInput>($"{apiBaseUrl}/api/Person", personCreateInput);

            return response.IsSuccessStatusCode;
        }


        public async Task<bool> UpdatePersonAsync(PersonUpdateInput personUpdateInput)
        {
            
            var response = await _client.PutAsJsonAsync<PersonUpdateInput>($"{apiBaseUrl}/api/Person", personUpdateInput);

            return response.IsSuccessStatusCode;
        }


    }
}
