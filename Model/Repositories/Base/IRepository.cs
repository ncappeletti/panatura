using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using panatura.Model.Entities;

namespace panatura.Model.Repositories
{
    public interface IRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    {
        TEntity FindById(TKey Id);

        TEntity FindBy(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> FindAll();

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);

        int Count();

        int Count(Expression<Func<TEntity, bool>> predicate);

        void DeleteById(TKey Id);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Save(TEntity entity);

        void Save(IEnumerable<TEntity> entities);
    }
}