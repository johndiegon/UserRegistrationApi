using UserRegistrationApi.Application.Data.Repositories;

namespace UserRegistrationApi.Application.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<AddressEntity> CreateAddress(AddressEntity address);
        Task<AddressEntity> UpdateAddress(AddressEntity address);
        Task<AddressEntity> ReadAddress(int id);
        Task DeleteAddress(int id);
    }
}
