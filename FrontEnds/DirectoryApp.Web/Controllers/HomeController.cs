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

namespace DirectoryApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;
        private HttpClient _client;


        public HomeController(IPersonService personService, HttpClient client)
        {
            _personService = personService;
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
            return View(await _personService.GetAllPersonAsync());
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

            await _personService.CreatePersonAsync(personInput);

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Update(string id)
        {
            var person = await _personService.GetPersonById(id);



            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            else
            {

                PersonUpdateInput personUpdateInput = new()
                {
                    PersonId = person.PersonId,
                    Company = person.Company,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    ContactInformations = person.ContactInformation
                };


                return View(personUpdateInput);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Update(PersonUpdateInput personUpdateInput)
        {
            string personId = personUpdateInput.PersonId.ToString();

            var person = await _personService.GetPersonById(personId);


            if (!ModelState.IsValid)
            {
                return View();
            }
            await _personService.UpdatePersonAsync(personUpdateInput);
            personUpdateInput.ContactInformations = person.ContactInformation;

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(string id)
        {
            await _personService.DeletePersonAsync(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
