using System.Collections.Generic;
using Infrastructure.DomainModel;

namespace Infrastructure.Repository
{
    /// <summary>
    /// Provides a standard interface for DAOs which are data-access mechanism agnostic.
    /// </summary>
    public interface IRepository<T> : IRepositoryWithTypedId<T, string> where T: IEntity
    {
        
    }

    public interface IRepositoryWithTypedId<TEntity, in TIdT> where TEntity: IEntity
    {
        void Update(TEntity entity);
        string Add(TEntity entity);
        void Delete(TIdT id);
        TEntity GetById(TIdT id);
        IEnumerable<TEntity> GetAll();
    }
}
