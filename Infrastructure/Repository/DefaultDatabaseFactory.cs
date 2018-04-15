using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Repository
{
    public class DefaultDatabaseFactory : IDatabaseFactory
    {
        public IDbConnection GetConnection()
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["YYPConnection"];
            IDbConnection conn = new SqlConnection(connectionStringSettings.ConnectionString);
            conn.Open();
            return conn;
        }
    }
}