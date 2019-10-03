using Microsoft.AspNetCore.Mvc;

namespace Bloops.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        /// <summary>
        /// POST /api/game/login: Connexion de l'utilisateur
        /// </summary>
        [HttpPost("login")]
        public void Login(LoginArgs args)
        {
            
        }
    }

    public class LoginArgs
    {
        public int SocialID { get; }
    }
}
