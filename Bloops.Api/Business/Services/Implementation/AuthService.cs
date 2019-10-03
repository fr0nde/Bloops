using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Bloops.Api.Business.Entities;
using Bloops.Api.Business.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bloops.Business.Entities;

namespace Bloops.Api.Business.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private TokenSettings TokenSettings { get; }

        private IUserRepository UserRepository { get; }

        public AuthService(IOptions<TokenSettings> tokenSettings, IUserRepository userRepository)
        {
            TokenSettings = tokenSettings.Value;
            UserRepository = userRepository;
        }

        public async Task<string> LoginAsync(string socialId, string username)
        {
            DbUser user = await UserRepository.GetBySocialIdAsync(socialId);
            if (user == null)
            {
                user = await UserRepository.InsertAsync(new DbUser() 
                {
                    SocialId = socialId,
                    Name = username
                });
            }

            return GetAccessToken(user);
        }

        private string GetAccessToken(DbUser user)
        {
            Claim[] claims = new Claim[] { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSettings.Secret));
            JwtSecurityToken token = new JwtSecurityToken(
                TokenSettings.Issuer,
                TokenSettings.Audience,
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(TokenSettings.AccessExpiration),
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class TokenSettings
    {
        public string Secret { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int AccessExpiration { get; set; }
    }
}
