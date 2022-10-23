using DirectoryApp.Services.CrudOperations.Data;
using DirectoryApp.Services.CrudOperations.Models;
using DirectoryApp.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Services.CrudOperations.Services
{
    public class PersonService:IPersonService
    {

        private readonly PersonContext _dbContext;

        public PersonService(PersonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response<List<Person>>> GetAllAsync()
        {
            var persons = await _dbContext.Person.Where(x=>x.isDeleted==false).ToListAsync();

            return Response<List<Person>>.Success(persons, 200);
        }


        public async Task<Response<Person>> GetPersonById(string id)
        {
            
            Guid personId = new Guid(id);

            var person = await _dbContext.Person.Include(x=>x.ContactInformation).FirstOrDefaultAsync(item => item.PersonId == personId);



            if (person == null)
            {
                return Response<Person>.Fail("Person not found", 404);
            }

            return Response<Person>.Success(person, 200);
        }

        public async Task<Response<NoContent>> Save(Person person)
        {
            
            await _dbContext.AddAsync(person);

            var saveStatus =await _dbContext.SaveChangesAsync();

            if (saveStatus > 0)
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("An error occurred while adding", 500);
        }


        public async Task<Response<NoContent>> Update(Person person)
        {

            if (_dbContext.Entry(person).State == EntityState.Modified)
               await _dbContext.SaveChangesAsync();

            var saveStatus =await _dbContext.SaveChangesAsync();

            if (saveStatus > 0)
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("Person not found", 404);
        }


        public async Task<Response<NoContent>> Delete(string id)
        {
            var deleteStatus = 0;

            Guid personId = new Guid(id);

            var person = _dbContext.Person.FirstOrDefault(item => item.PersonId == personId);

            if (person != null)
            {
                person.isDeleted = true;
                deleteStatus = await _dbContext.SaveChangesAsync();
            }

            return deleteStatus > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Person not found", 404);


    

        }
    }
}
