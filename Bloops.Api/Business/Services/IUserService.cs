using Bloops.Business.Entities;
using System.Threading.Tasks;

namespace Bloops.Api.Business.Services
{
    public interface IUserService
    {
        int GetCurrentUserId();

        Task<DbUser> GetCurrentUserAsync();
    }
}
