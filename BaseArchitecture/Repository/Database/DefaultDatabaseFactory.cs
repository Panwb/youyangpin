﻿using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace BaseArchitecture.Repository.Database
{
    public class DefaultDatabaseFactory : IDatabaseFactory
    {
        private readonly string _connectionString;
        private readonly string _databaseName;

        public DefaultDatabaseFactory(IOptions<AppSettings> settings)
        {
            _connectionString = settings.Value.ConnectionStrings.ConnectionString;
            _databaseName = settings.Value.ConnectionStrings.DatabaseName;
        }     

        public IDbConnection GetConnection()
        {
            IDbConnection conn = null;
            switch (_databaseName.ToLower())
            {
                case "postgresql":
                    conn = new NpgsqlConnection(_connectionString);
                    break;
            }
            conn.Open();
            return conn;
        }
    }
}