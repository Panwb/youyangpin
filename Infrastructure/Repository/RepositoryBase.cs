using System;
using System.Collections.Generic;
using System.Data;
using Architecture.Repository;
using Infrastructure.DomainModel;

namespace Infrastructure.Repository
{
    public abstract class RepositoryBase
    {
        #region Database

        protected RepositoryBase(IDatabaseFactory db)
        {
            Database = db.GetConnection();
        }

        public IDbConnection Database { get; }

        #endregion
    }

    public abstract class RepositoryBase<TEntity> : RepositoryBase where TEntity : class, IEntity
    {
        protected RepositoryBase(IDatabaseFactory db)
            : base(db)
        {

        }

        public virtual string Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(string id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}