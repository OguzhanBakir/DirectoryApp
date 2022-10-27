using DirectoryApp.BLL.Abstract;
using DirectoryApp.Core.Entities;
using DirectoryApp.DAL.Abstract;
using DirectoryApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.BLL.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonDAL _personDal;
        public PersonManager(IPersonDAL personDal)
        {
            _personDal = personDal;
        }
        public async Task<Response<NoContent>> Delete(string id)
        {
            var result = await _personDal.Delete(id);
            return result == false ? Response<NoContent>.Fail("An error occurred while deleting", 500) : Response<NoContent>.Success(204);
        }

        public async Task<Response<List<Person>>> GetAllAsync()
        {
            var result = await _personDal.GetAllAsync();
            return Response<List<Person>>.Success(result, 200);
        }

        public async Task<Response<Person>> GetPersonById(string id)
        {
            var result = await _personDal.GetPersonById(id);
            return result != null ? Response<Person>.Success(result, 200) : Response<Person>.Fail("Person not found", 404);
        }

        public async Task<Response<NoContent>> Add(Person person)
        {
            var result = await _personDal.Add(person);
            return result == false ? Response<NoContent>.Fail("An error occurred while adding", 500) : Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> Update(Person person)
        {
            var result = await _personDal.Update(person);
            return result == false ? Response<NoContent>.Fail("An error occurred while updating", 500) : Response<NoContent>.Success(204);
        }
    }
}
