using DirectoryApp.Core.Entities;
using DirectoryApp.Shared.Dtos;
using DirectoryApp.Web.Definitions;
using DirectoryApp.Web.Models;
using DirectoryApp.Web.Models.Persons;
using DirectoryApp.Web.Models.Report;
using DirectoryApp.Web.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ReportResult = DirectoryApp.Core.Entities.ReportResult;

namespace DirectoryApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient _client;


        public HomeController(HttpClient client)
        {
            _client = client;

        }

        public async Task<IActionResult> Reports()
        {
            List<ReportResult> lstInformation;

            var response = await _client.GetAsync($"{StaticDefinition.reportApiBaseUrl}/api/ReportResult/GetAllReport");

            if (response.IsSuccessStatusCode)
            {

                var responseReportList = await response.Content.ReadFromJsonAsync<Response<List<ReportResult>>>();

                lstInformation = responseReportList.Data;






            }

            else
            {

                lstInformation = new List<ReportResult>();


            }


            return await Task.Run(() => View(lstInformation));

        }

        public async Task<IActionResult> Index()
        {

            var response = await _client.GetAsync($"{StaticDefinition.apiBaseUrl}/api/Person");

            if (response.IsSuccessStatusCode)
            {
                var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<PersonViewModel>>>();
                return View(responseSuccess.Data);
            }


            return View();
        }




        public async Task<IActionResult> GenerateReport()
        {

            var response = await _client.PostAsync($"{StaticDefinition.reportApiBaseUrl}/api/ReportResult/GenerateReport", null);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Reports));
            }

            else
            {
                return RedirectToAction(nameof(Index));
            }



        }





        public async Task<IActionResult> Create()
        {


            return await Task.Run(() => View());
        }


        [HttpPost]
        public async Task<IActionResult> Create(PersonCreateInput personInput)
        {


            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var response = await _client.PostAsJsonAsync<PersonCreateInput>($"{StaticDefinition.apiBaseUrl}/api/Person", personInput);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }



        }



        public async Task<IActionResult> Update(string id)
        {
            var response = await _client.GetAsync($"{StaticDefinition.apiBaseUrl}/api/Person/{id}");
            if (response.IsSuccessStatusCode)
            {
                var person = await response.Content.ReadFromJsonAsync<Response<Person>>();
                if (person.Data != null)
                {
                    PersonUpdateInput personUpdateInput = new()
                    {
                        PersonId = person.Data.PersonId,
                        Company = person.Data.Company,
                        FirstName = person.Data.FirstName,
                        LastName = person.Data.LastName,
                        ContactInformations = person.Data.ContactInformations
                    };

                    return View(personUpdateInput);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }



        }


        [HttpPost]
        public async Task<IActionResult> Update(PersonUpdateInput model)
        {
            var response = await _client.GetAsync($"{StaticDefinition.apiBaseUrl}/api/Person/{model.PersonId}");
            if (response.IsSuccessStatusCode)
            {
                var person = await response.Content.ReadFromJsonAsync<Response<Person>>();
                

                var updateResponse = await _client.PutAsJsonAsync<PersonUpdateInput>($"{StaticDefinition.apiBaseUrl}/api/Person", model);

                model.ContactInformations = person.Data.ContactInformations;
                if (updateResponse.IsSuccessStatusCode)
                {
                    return View(model);
                }

            }

            return View(model);




        }


        public async Task<IActionResult> Delete(string id)
        {
            var response = await _client.DeleteAsync($"{StaticDefinition.apiBaseUrl}/api/Person/{id}");


            return RedirectToAction(nameof(Index));
        }

    }
}
