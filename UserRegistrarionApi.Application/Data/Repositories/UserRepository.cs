using UserRegistrationApi.Application.Interfaces.Repositories;

namespace UserRegistrationApi.Application.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<UserEntity> CreateUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(string document)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> ReadUser(string document)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> UpdateUser(UserEntity user)
        {
            throw new NotImplementedException();
        }
    }
}
