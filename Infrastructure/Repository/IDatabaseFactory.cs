using System.Data;

namespace Infrastructure.Repository
{
    public interface IDatabaseFactory
    {
        IDbConnection GetConnection();
    }
}