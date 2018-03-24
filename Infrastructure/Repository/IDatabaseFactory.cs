using System.Data;

namespace Architecture.Repository
{
    public interface IDatabaseFactory
    {
        IDbConnection GetConnection();
    }
}