using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using panatura.Model.Entities;

namespace panatura.Model.Repositories
{
    public class BaseRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : class, IEntity<TKey>
    {
        readonly PanaturaContext dbContext;
        protected DbSet<TEntity> Entities;

        public BaseRepository(PanaturaContext dbContext)
        {
            this.dbContext = dbContext;
            this.Entities = this.dbContext.Set<TEntity>();
        }

        public TEntity FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Entities.Where(predicate).FirstOrDefault();
        }

        public TEntity FindById(TKey Id)
        {
            return this.Entities.Find(Id);
        }

        public IEnumerable<TEntity> FindAll()
        {
            return this.Entities.AsEnumerable();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Entities.Where(predicate).AsEnumerable();
        }

        public void DeleteById(TKey Id)
        {
            var entity = this.Entities.Find(Id);
            if (entity != null)
                this.Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            if (Exists(entity))
            {
                this.Entities.Remove(entity);
                this.dbContext.SaveChanges();
            }
        }

        public void Insert(TEntity entity)
        {
            this.Entities.Add(entity);
            this.dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            this.Entities.Update(entity);
            this.dbContext.SaveChanges();
        }

        public void Save(TEntity entity)
        {
            if (!Exists(entity))
                MarkToInsert(entity);
            else
                MarkToUpdate(entity);
            this.dbContext.SaveChanges();
        }

        private bool Exists(TEntity entity)
        {
            return (this.Entities.Count(e => e.Id.Equals(entity.Id)) > 0);
        }

        private void MarkToInsert(TEntity entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Added;
        }

        private void MarkToUpdate(TEntity entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            this.Entities.RemoveRange(entities.ToArray());
        }

        public void Save(IEnumerable<TEntity> entities)
        {
            entities.ToList().ForEach(e =>
            {
                if (Exists(e))
                    MarkToInsert(e);
                else
                    MarkToUpdate(e);
            });
            this.dbContext.SaveChanges();
        }

        public int Count()
        {
            return Entities.Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Count(predicate);
        }
    }
}