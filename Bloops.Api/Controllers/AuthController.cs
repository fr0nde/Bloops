using Bloops.Api.Business.Services;
using Bloops.Shared.Requests;
using Bloops.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bloops.Api.Controllers
{
    [ApiController, Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private IAuthService AuthService { get; }

        public AuthController(IAuthService authService)
        {
            AuthService = authService;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> LoginAsync(AuthRequest args)
        {
            string token = await AuthService.LoginAsync(args.SocialID, args.Username);
            return Ok(new AuthResponse(token));
        }
    }
}
