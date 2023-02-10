using UserRegistrationApi.Application.Data.Repositories;

namespace UserRegistrationApi.Application.Interfaces.Repositories
{
    public interface IContactRepository
    {
        Task<ContactEntity> CreateContact(ContactEntity contact);
        Task<ContactEntity> UpdateContact(ContactEntity contact);
        Task<ContactEntity> ReadContact(int id);
        Task DeleteContact(int id);
    }
}
