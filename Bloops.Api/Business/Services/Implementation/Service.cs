using Microsoft.Extensions.Configuration;
using System.Data.SQLite;

namespace Bloops.Api.Business.Services.Implementation
{
    internal abstract class Service
    {
        private string ConnectionString { get; }

        protected SQLiteConnection Connection
        {
            get { return new SQLiteConnection(ConnectionString); }
        }

        internal Service(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("Database");
        }
    }
}
