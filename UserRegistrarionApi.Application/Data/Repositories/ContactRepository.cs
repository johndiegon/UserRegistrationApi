using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistrationApi.Application.Interfaces.Repositories;

namespace UserRegistrationApi.Application.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public Task<ContactEntity> CreateContact(ContactEntity contact)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ContactEntity> ReadContact(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ContactEntity> UpdateContact(ContactEntity contact)
        {
            throw new NotImplementedException();
        }
    }
}
