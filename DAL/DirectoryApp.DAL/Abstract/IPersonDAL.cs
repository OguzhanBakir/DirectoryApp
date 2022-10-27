using DirectoryApp.Core.Entities;
using DirectoryApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.DAL.Abstract
{
    public interface IPersonDAL
    {
        Task<List<Person>> GetAllAsync();
        Task<Person> GetPersonById(string id);
        Task<bool> Save();
        Task<bool> Add(Person person);
        Task<bool> Update(Person person);
        Task<bool> Delete(string id);

    }
}
