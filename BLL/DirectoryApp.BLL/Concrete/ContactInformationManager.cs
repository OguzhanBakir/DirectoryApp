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
    public class ContactInformationManager : IContactInformationService
    {
        private readonly IContactInformationDAL _contactInformationDal;
        public ContactInformationManager(IContactInformationDAL contactInformationDal)
        {
            _contactInformationDal = contactInformationDal;
        }
        public async Task<Response<NoContent>> Add(ContactInformation contactInformation)
        {
            var result = await _contactInformationDal.Add(contactInformation);
            return result == false ? Response<NoContent>.Fail("An error occurred while adding", 500) : Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            var result = await _contactInformationDal.Delete(id);
            return result == false ? Response<NoContent>.Fail("An error occurred while deleting", 500) : Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ContactInformation>>> GetAllAsync()
        {
            var result = await _contactInformationDal.GetAllAsync();
            return Response<List<ContactInformation>>.Success(result, 200);
        }

        public async Task<Response<NoContent>> GetByInformationValue(string value, string personId)
        {
            var result = await _contactInformationDal.GetByInformationValue(value, personId);
            return result != null ? Response<NoContent>.Fail("Information already exists", 500) : Response<NoContent>.Success(204);

        }

        public async Task<Response<ContactInformation>> GetContactInformationByPersonId(Guid id)
        {
            var result = await _contactInformationDal.GetContactInformationByPersonId(id);
            return result != null ? Response<ContactInformation>.Success(result, 200) : Response<ContactInformation>.Fail("Information not found", 404);
        }

        public async Task<Response<List<ContactInformation>>> GetContactInformationListByPersonId(Guid id)
        {
            var result = await _contactInformationDal.GetContactInformationListByPersonId(id);
            return Response<List<ContactInformation>>.Success(result, 200);
        }

        public async Task<Response<NoContent>> Update(ContactInformation contactInformation)
        {
            var result = await _contactInformationDal.Update(contactInformation);
            return result == false ? Response<NoContent>.Fail("An error occurred while updating", 500) : Response<NoContent>.Success(204);
        }
    }
}
