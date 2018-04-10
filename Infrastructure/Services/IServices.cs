using Infrastructure.DomainModel;

namespace  Infrastructure.Services
{
    public interface IService<TEntity> where TEntity : IEntity
    {
    }
}