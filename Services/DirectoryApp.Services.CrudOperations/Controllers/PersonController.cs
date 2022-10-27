using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectoryApp.Shared.ControllerBases;
using DirectoryApp.BLL.Abstract;
using DirectoryApp.Core.Entities;

namespace DirectoryApp.Services.CrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : CustomBaseController
    {
        private readonly IPersonService _personService;


        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();

            return CreateActionResultInstance(persons);
        }

        
        [HttpGet("{id}")]

        public async Task<IActionResult> GetPersonById(string id)
        {
            var response = await _personService.GetPersonById(id);

            return CreateActionResultInstance(response);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Person personDto)
        {
            var response = await _personService.Add(personDto);

            return CreateActionResultInstance(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update(Person personDto)
        {
            var response = await _personService.Update(personDto);

            return CreateActionResultInstance(response);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {

            var response = await _personService.Delete(id);

            return CreateActionResultInstance(response);
        }


    }
}
