using DirectoryApp.Core.Entities;
using DirectoryApp.DAL.Abstract;
using DirectoryApp.DAL.Concrete.EntityFramework.Context;
using DirectoryApp.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.DAL.Concrete.Managers
{
    public class EfContactInformationDAL : IContactInformationDAL
    {
        private readonly PersonContext _dbContext;

        public EfContactInformationDAL(PersonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ContactInformation>> GetAllAsync()
        {
            try
            {
                return await _dbContext.ContactInformation.Where(x => x.isDeleted == false).ToListAsync();

            }
            catch (Exception ex)
            {
                var result = ex.Message.ToString();
                return null;
            }


        }


        public async Task<List<ContactInformation>> GetContactInformationListByPersonId(Guid id)
        {
            return await _dbContext.ContactInformation.Where(x => x.PersonId == id).ToListAsync();

        }

        public async Task<ContactInformation> GetContactInformationByPersonId(Guid id)
        {
            return await _dbContext.ContactInformation.Where(x => x.PersonId == id).FirstOrDefaultAsync();

        }



        public async Task<bool> Add(ContactInformation contact)
        {
            await _dbContext.ContactInformation.AddAsync(contact);

            return await Save();
        }

        public async Task<bool> Save()
        {
            return await _dbContext.SaveChangesAsync() >= 0 ? true : false;
        }



        public async Task<bool> Update(ContactInformation contact)
        {
            _dbContext.ContactInformation.Update(contact);
            return await Save();
        }




        public async Task<bool> Delete(int id)
        {
            var contact = await _dbContext.ContactInformation.FindAsync(id);
            if (contact != null)
            {
                _dbContext.ContactInformation.Remove(contact);

                return await Save();
            }

            return false;


        }

        public async Task<ContactInformation> GetByInformationValue(string value, string personId)
        {
            return await _dbContext.ContactInformation.FirstOrDefaultAsync(x => x.ContactValue.ToLower() == value.ToLower() && x.PersonId.ToString() == personId);



        }
    }
}
