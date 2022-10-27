using DirectoryApp.Web.Definitions;
using DirectoryApp.Web.Models.ContactInformations;
using DirectoryApp.Web.Services.Interfaces;
using DirectoryApp.Web.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DirectoryApp.Web.Controllers
{
    public class ContactInformationController : Controller
    {
        private readonly HttpClient _client;


        public ContactInformationController(HttpClient client)
        {
            _client = client;


        }

        public async Task<IActionResult> Add(int informationTypeId, string personId)
        {
            ContactInformationAddViewModel model = new ContactInformationAddViewModel();
            model.PersonId = personId;
            model.InformationTypeId = informationTypeId;

            switch (informationTypeId)
            {
                case 1:
                    model.ContactType = "Konum";
                    model.Cities = Cities.GetCitiesList();
                    break;
                case 2:
                    model.ContactType = "EPosta";
                    break;
                case 3:
                    model.ContactType = "Telefon";
                    break;
            }


            return PartialView("_ContactInformationAddPartial", model);
        }



        [HttpPost]
        public async Task<IActionResult> Add(ContactInformationAddViewModel model)
        {

            model.Cities = Cities.GetCitiesList();
            if (model.InformationTypeId == 1)
            {
                model.ContactValue = model.SelectedCity;
            }
            else
            {

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Update", "Home", new { id = model.PersonId });

                }
            }

            var response = await _client.PostAsJsonAsync($"{StaticDefinition.apiBaseUrl}/api/ContactInformation/Create", model);

            //await _contactInformationService.AddContactInformationAsync(model);
            return RedirectToAction("Update", "Home", new { id = model.PersonId });
        }

        public async Task<IActionResult> Remove(int id,string personId)
        {
            var response = await _client.DeleteAsync($"{StaticDefinition.apiBaseUrl}/api/ContactInformation/Delete/{id}");

            return RedirectToAction("Update", "Home", new { id = personId });
        }

    }
}
