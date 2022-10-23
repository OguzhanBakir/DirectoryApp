using DirectoryApp.Web.Models.ContactInformations;
using DirectoryApp.Web.Services.Interfaces;
using DirectoryApp.Web.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DirectoryApp.Web.Controllers
{
    public class ContactInformationController : Controller
    {
        private readonly IContactInformationService _contactInformationService;

        public ContactInformationController(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
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


            await _contactInformationService.AddContactInformationAsync(model);
            return RedirectToAction("Update", "Home", new { id = model.PersonId });
        }

        public async Task<IActionResult> Remove(int id,string personId)
        {
            await _contactInformationService.DeleteContactInformationAsync(id);
            return RedirectToAction("Update", "Home", new { id = personId });
        }

    }
}
