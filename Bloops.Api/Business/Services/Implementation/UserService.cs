using Microsoft.Extensions.Configuration;

namespace Bloops.Api.Business.Services.Implementation
{
    internal class UserService : Service, IUserService
    {
        public UserService(IConfiguration configuration) 
            : base(configuration)
        {
        }
    }
}
