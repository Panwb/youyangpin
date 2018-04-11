using System.Data;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Microsoft.Extensions.Options;

namespace Infrastructure.Data
{
    public abstract class RepositoryBase
    {
        #region Database

        private static IDbConnection _database;

        public static IDbConnection Database => _database ?? (_database = new DefaultDatabaseFactory(new OptionsManager<AppSettings>()).GetConnection());

        protected static void DisposeStaticMember()
        {
            _database = null;
        }

        #endregion
    }
}