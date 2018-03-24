using Infrastructure.Entities;

namespace  Infrastructure.Services
{
    public interface IService<TEntity> where TEntity : IEntity
    {
    }
}