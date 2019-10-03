using Microsoft.AspNetCore.Http;
using Bloops.Api.Business.Entities;
using Bloops.Api.Business.Repositories;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Bloops.Business.Entities;

namespace Bloops.Api.Business.Services.Implementation
{
    public class UserService : IUserService
    {
        private IHttpContextAccessor HttpContextAccessor { get; }

        private IUserRepository UserRepository { get; }

        public UserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            HttpContextAccessor = httpContextAccessor;
            UserRepository = userRepository;
        }

        public int GetCurrentUserId()
        {
            ClaimsPrincipal user = HttpContextAccessor.HttpContext.User;
            if (user is null)
            {
                throw new Exception();
            }
            return Convert.ToInt32(user.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        public async Task<DbUser> GetCurrentUserAsync()
        {
            return await UserRepository.GetAsync(GetCurrentUserId());
        }
    }
}
