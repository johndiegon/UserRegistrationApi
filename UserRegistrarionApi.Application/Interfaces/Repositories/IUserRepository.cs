using UserRegistrationApi.Application.Data.Repositories;

namespace UserRegistrationApi.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> CreateUser(UserEntity user);
        Task<UserEntity> UpdateUser(UserEntity user);
        Task<UserEntity> ReadUser(string document);
        Task DeleteUser(string document);
    }
}
