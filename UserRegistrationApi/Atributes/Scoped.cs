using UserRegistrationApi.Application.Interfaces;
using UserRegistrationApi.Application.Service;

namespace UserRegistrationApi.Atributes
{
    public static class Scoped
    {
        public static void Add(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
