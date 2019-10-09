using Bloops.Business.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Threading.Tasks;

namespace Bloops.Api.Business.Repositories.Implementation
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(IConfiguration configuration)
            : base(configuration)
        {
        }

        public async Task<DbUser> GetAsync(int id)
        {
            using DbConnection connection = Connection;
            await connection.OpenAsync();
            return await connection.GetAsync<DbUser>(id);
        }

        public async Task<DbUser> GetBySocialIdAsync(string socialId)
        {
            using DbConnection connection = Connection;
            await connection.OpenAsync();
            return await connection.QueryFirstOrDefaultAsync<DbUser>(@"
                SELECT * 
                FROM User 
                WHERE Email = @Email
            ", new { SocialId = socialId });
        }

        public async Task<DbUser> InsertAsync(DbUser user)
        {
            using DbConnection connection = Connection;
            await connection.OpenAsync();
            await connection.InsertAsync(user);
            return user;
        }
    }
}
