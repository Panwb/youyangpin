using System.Collections.Generic;
using Infrastructure.DomainModel;

namespace Infrastructure.Repository
{
    /// <summary>
    /// Provides a standard interface for DAOs which are data-access mechanism agnostic.
    /// </summary>
    public interface IRepository<T> : IRepositoryWithTypedId<T, int> where T: IEntity
    {
        
    }

    public interface IRepositoryWithTypedId<TEntity, in TIdT> where TEntity: IEntity
    {
        int Update(TEntity entity);
        int Add(TEntity entity);
        int Delete(TIdT id);
        TEntity GetById(TIdT id);
        IEnumerable<TEntity> GetAll();
    }
}
