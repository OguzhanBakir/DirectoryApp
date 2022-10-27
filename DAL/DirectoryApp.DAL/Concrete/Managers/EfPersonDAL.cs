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
    public class EfPersonDAL : IPersonDAL
    {

        private readonly PersonContext _dbContext;

        public EfPersonDAL(PersonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _dbContext.Person.Where(x => x.isDeleted == false).ToListAsync();

        }


        public async Task<Person> GetPersonById(string id)
        {

            Guid personId = new Guid(id);

            return await _dbContext.Person.Include(x => x.ContactInformations).FirstOrDefaultAsync(item => item.PersonId == personId);




        }

        public async Task<bool> Add(Person person)
        {
            await _dbContext.Person.AddAsync(person);
            return await Save();
        }


        public async Task<bool> Save()
        {
            return await _dbContext.SaveChangesAsync() >= 0 ? true : false;
        }



        public async Task<bool> Update(Person person)
        {
            _dbContext.Person.Update(person);
            return await Save();
        }

        public async Task<bool> Delete(string id)
        {
            Guid personId = new Guid(id);
            var person = await _dbContext.Person.FindAsync(personId);
            if (person != null)
            {
                person.isDeleted = true;
                return await Update(person);

            }

            return false;




        }
    }
}
