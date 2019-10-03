using System.Threading.Tasks;

namespace Bloops.Api.Business.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string socialId, string username);
    }
}
