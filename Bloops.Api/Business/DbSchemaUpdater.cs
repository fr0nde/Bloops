using Dapper;
using System.Data.Common;
using System.Data.SQLite;

namespace Bloops.Api.Business
{
    internal static class DbSchemaUpdater
    {
        private static readonly int Version = 1;

        private static DbConnection Connection { get; set; }

        internal static void Execute(string connectionString)
        {
            Connection = new SQLiteConnection(connectionString);
            Connection.Open();

            int schemaVersion = GetSchemaVersion();
            if (schemaVersion >= Version)
            {
                return;
            }

            if (schemaVersion < 1)
            {

            }

            UpdateSchemaVersion();

            Connection.Dispose();
        }

        private static int GetSchemaVersion()
        {
            return Connection.ExecuteScalar<int>("PRAGMA schema_version");
        }

        private static void UpdateSchemaVersion()
        {
            Connection.Execute($"PRAGMA schema_version = {Version}");
        }
    }
}
