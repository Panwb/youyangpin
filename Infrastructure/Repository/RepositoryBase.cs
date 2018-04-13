using System;
using System.Collections.Generic;
using System.Data;
using Architecture.Repository;
using Infrastructure.DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repository
{
    public abstract class RepositoryBase
    {
        #region Database

        private static IDbConnection _database;

        public static IDbConnection Database => _database ?? (_database = null);//HttpContext.RequestServices.GetService<IDatabaseFactory>().GetConnection());
        
        protected static void DisposeStaticMember()
        {
            _database = null;
        }

        #endregion
    }

    public abstract class RepositoryBase<TEntity> : RepositoryBase where TEntity : class, IEntity
    {
        public virtual int Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}