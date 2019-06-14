using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.LinqToSql.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity 
    {
        protected string ConnectionString;
        protected DataContext DataContext;

        public BaseRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.DataContext = new DataContext(connectionString);
        }

        public virtual Task<TEntity> CreateAsync(TEntity entity)
        {
            DataContext.GetTable<TEntity>().InsertOnSubmit(entity);
            DataContext.SubmitChanges();
            return Task.FromResult<TEntity>(entity);
        }

        public virtual Task<TEntity> UpdateAsync(TEntity newEntity)
        {
            var oldEntity = DataContext.GetTable<TEntity>().Where(entity => entity.Id.Equals(newEntity.Id)).FirstOrDefault();
            oldEntity.MapFrom(newEntity);
            DataContext.SubmitChanges();
            return Task.FromResult<TEntity>(newEntity);
        }

        public virtual Task<List<TEntity>> GetAllEntitiesAsync()
        {
            var table = DataContext.GetTable<TEntity>();

            return Task.FromResult(table.ToList());
        }

        public virtual Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return Task.FromResult(DataContext.GetTable<TEntity>()
                .Where(predicate)
                .FirstOrDefault());
        }
        
        public virtual Task<bool> DeleteAsync(Guid Id)
        {
            var entityToDelete = DataContext.GetTable<TEntity>()
                                            .Where(entity => entity.Id.Equals(Id))
                                            .FirstOrDefault();

            DataContext.GetTable<TEntity>().DeleteOnSubmit(entityToDelete);
            DataContext.SubmitChanges();

            return Task.FromResult(true);
        }

        public virtual void AddCollection(List<TEntity> entities)
        {
            DataContext.GetTable<TEntity>()
                .InsertAllOnSubmit(entities);
            DataContext.SubmitChanges();
        }

        public TEntity CreateEmptyObject()
        {
            var type = typeof(TEntity).Name;
            IEntity newObject = null;
            switch (type)
            {
                case "Cart": newObject = new Cart(); break;
                case "Train": newObject = new Train(); break;
                case "Passanger": newObject = new Passanger(); break;
                case "Ticket": newObject = new Ticket(); break;
                default: throw new Exception("No such type");
            }
            return (TEntity)newObject;
        }
    }
}
