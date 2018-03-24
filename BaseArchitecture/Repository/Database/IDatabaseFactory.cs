using System.Data;

namespace BaseArchitecture.Repository.Database
{
    public interface IDatabaseFactory
    {
        IDbConnection GetConnection();
    }
}