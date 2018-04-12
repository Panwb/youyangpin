using System.Data;
using System.Data.SqlClient;
using Architecture.Repository;
using Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Infrastructure.Repository
{
    public class DefaultDatabaseFactory : IDatabaseFactory
    {
        private readonly string _connectionString;
        private readonly string _databaseName;

        public DefaultDatabaseFactory(IOptions<ConnectionStrings> settings)
        {
            _connectionString = settings.Value.ConnectionString;
            _databaseName = settings.Value.DatabaseName;
        }     

        public IDbConnection GetConnection()
        {
            IDbConnection conn = null;
            switch (_databaseName.ToLower())
            {
                case "postgresql":
                    conn = new NpgsqlConnection(_connectionString);
                    break;
                case "mssqlserver":
                    conn = new SqlConnection(_connectionString);
                    break;
            }
            conn.Open();
            return conn;
        }
    }
}