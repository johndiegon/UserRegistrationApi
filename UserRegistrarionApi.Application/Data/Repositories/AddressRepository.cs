using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistrationApi.Application.Interfaces.Repositories;

namespace UserRegistrationApi.Application.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public Task<AddressEntity> CreateAddress(AddressEntity address)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAddress(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AddressEntity> ReadAddress(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AddressEntity> UpdateAddress(AddressEntity address)
        {
            throw new NotImplementedException();
        }
    }
}
