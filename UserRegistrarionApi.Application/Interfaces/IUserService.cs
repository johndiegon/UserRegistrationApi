using UserRegistrationApi.Application.Contract.Request;
using UserRegistrationApi.Application.Contract.Response;

namespace UserRegistrationApi.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> CreateUser(UserRequest user);
        Task<UserResponse> UpdateUser(UserRequest user);
        Task<UserResponse> DeleteUser(string document);
        Task<UserResponse> GetUser(string document);
    }
}
