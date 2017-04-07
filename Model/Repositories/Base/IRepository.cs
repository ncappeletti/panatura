using panatura.Model.Entities;

namespace panatura.Model.Repositories
{
    public interface IRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    {
         
    }
}