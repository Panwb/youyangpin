using System.Data;
using Infrastructure.Repository;

namespace Kingston.KCMS.Data
{
    public abstract class RepositoryBase
    {
        #region Database

        private static IDbConnection _database;

        public static IDbConnection Database => _database ?? (_database = new DefaultDatabaseFactory(ConfigManager.ConnectionString));

        protected static void DisposeStaticMember()
        {
            _database = null;
        }

        #endregion
    }
}