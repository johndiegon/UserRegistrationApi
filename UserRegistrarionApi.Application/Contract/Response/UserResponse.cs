using UserRegistrationApi.Application.Model;

namespace UserRegistrationApi.Application.Contract.Response
{
    public class UserResponse : CommandResponse
    {
        public User User { get; set; } 
    }
}
