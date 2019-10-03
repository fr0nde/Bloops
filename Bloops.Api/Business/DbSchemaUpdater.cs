using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SQLite;

namespace Bloops.Api.Business
{
    internal class DbSchemaUpdater
    {
        private const int Version = 1;

        private string ConnectionString { get; }

        internal DbSchemaUpdater(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("Database");
        }

        internal void Execute()
        {
            using (DbConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                int dbVersion = connection.ExecuteScalar<int>("PRAGMA schema_version");
                if (dbVersion >= Version)
                {
                    return;
                }

                if (dbVersion < 1)
                {
                    connection.Execute(@"CREATE TABLE User (
                        ID INTEGER IDENTITY PRIMARY KEY AUTOINCREMENT,
                        SocialID VARCHAR(100) UNIQUE NOT NULL,
                        Name VARCHAR(100) NOT NULL,
                        LastLevelPlayed INTEGER NOT NULL,
                        CreationDate DATETIME NOT NULL,
                        ModificationDate DATETIME NOT NULL
                    )");
                }

                connection.Execute($"PRAGMA schema_version = {Version}");
            }
        }
    }
}
