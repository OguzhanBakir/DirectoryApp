using DirectoryApp.BLL.Abstract;
using DirectoryApp.Core.Entities;
using DirectoryApp.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Services.CrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationController : CustomBaseController
    {
        private readonly IContactInformationService _contactInformationService;


        public ContactInformationController(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contactInformations = await _contactInformationService.GetAllAsync();

            return CreateActionResultInstance(contactInformations);
        }


        [HttpGet]
        [Route("GetContactInformationListByPersonId/{id}")]
        public async Task<IActionResult> GetContactInformationListByPersonId(Guid id)
        {
            var response = await _contactInformationService.GetContactInformationListByPersonId(id);

            return CreateActionResultInstance(response);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(ContactInformation informationDto)
        {

            var isExistResponse = await _contactInformationService.GetByInformationValue(informationDto.ContactValue, informationDto.PersonId.ToString());
            if (!isExistResponse.IsSuccessful)
            {
                return CreateActionResultInstance(isExistResponse);
            }
            var response = await _contactInformationService.Add(informationDto);

            return CreateActionResultInstance(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update(ContactInformation informationDto)
        {
            var response = await _contactInformationService.Update(informationDto);

            return CreateActionResultInstance(response);
        }


        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _contactInformationService.Delete(id);

            return CreateActionResultInstance(response);
        }
    }
}
