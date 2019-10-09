using Bloops.Business.Entities;
using System.Threading.Tasks;

namespace Bloops.Api.Business.Repositories
{
    public interface IUserRepository
    {
        Task<DbUser> GetAsync(int id);

        Task<DbUser> GetBySocialIdAsync(string socialId);

        Task<DbUser> InsertAsync(DbUser user);
    }
}
