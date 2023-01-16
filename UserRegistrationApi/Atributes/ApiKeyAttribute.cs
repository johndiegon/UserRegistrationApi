using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UserRegistrationApi.Atributes
{
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _apiKey;
    
        public ApiKeyAttribute()
        {
            
            var configuration = new ConfigurationManager();
            var apikey = configuration.GetSection("apiKey");
            if(apikey !=null)
                _apiKey = apikey.Value;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "ApiKey não encontrada"
                };
                return;
            }

            if (!_apiKey.Equals(extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "Acesso não autorizado"
                };
                return;
            }

            await next();
        }
    }
}
