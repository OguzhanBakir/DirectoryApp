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
    public class ContactInformationService : IContactInformationService
    {
        private readonly PersonContext _dbContext;

        public ContactInformationService(PersonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response<List<ContactInformation>>> GetAllAsync()
        {
            var informations = await _dbContext.ContactInformation.Where(x => x.isDeleted == false).ToListAsync();

            return Response<List<ContactInformation>>.Success(informations, 200);
        }


        public async Task<Response<List<ContactInformation>>> GetContactListInformationByPersonId(Guid id)
        {
            var informations = await _dbContext.ContactInformation.Where(x => x.PersonId ==id).ToListAsync();

            return Response<List<ContactInformation>>.Success(informations, 200);
        }

        public async Task<Response<ContactInformation>> GetContactInformationByPersonId(Guid id)
        {
            var information = await _dbContext.ContactInformation.SingleOrDefaultAsync(x=>x.PersonId==id);



            if (information == null)
            {
                return Response<ContactInformation>.Fail("Information not found", 404);
            }

            return Response<ContactInformation>.Success(information, 200);
        }

        public async Task<Response<NoContent>> Save(ContactInformation contact)
        {

            await _dbContext.AddAsync(contact);

            var saveStatus = await _dbContext.SaveChangesAsync();

            if (saveStatus > 0)
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("An error occurred while adding", 500);
        }


        public async Task<Response<NoContent>> Update(ContactInformation contact)
        {

            if (_dbContext.Entry(contact).State == EntityState.Modified)
                await _dbContext.SaveChangesAsync();

            var saveStatus = await _dbContext.SaveChangesAsync();

            if (saveStatus > 0)
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("Contact not found", 404);
        }


        public async Task<Response<NoContent>> Delete(int id)
        {
            var contact = await _dbContext.ContactInformation.FindAsync(id);
             
            _dbContext.ContactInformation.Remove(contact);


            var deleteStatus = await _dbContext.SaveChangesAsync();

            return deleteStatus > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Contact not found", 404);




        }
    }
}
