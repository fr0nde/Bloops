using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SQLite;

namespace Bloops.Api.Business.Repositories.Implementation
{
    public abstract class Repository
    {
        private string ConnectionString { get; }

        protected DbConnection Connection
        {
            get { return new SQLiteConnection(ConnectionString); }
        }

        internal Repository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString(nameof(ConnectionString));
        }
    }
}
