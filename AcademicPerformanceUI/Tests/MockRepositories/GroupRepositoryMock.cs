using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tests.MockRepositories
{
    public class GroupRepositoryMock:IRepository<Cart>
    {
        private List<Cart> groups = new List<Cart>();

        public void AddCollection(List<Cart> entities)
        {
            groups.AddRange(entities);
        }

        public Task<Cart> CreateAsync(Cart entity)
        {
            groups.Add(entity);
            return Task.FromResult(entity);
        }

        public Cart CreateEmptyObject() => new Cart();

        public Task<bool> DeleteAsync(Guid id)
        {
            groups = groups.Where(item => item.Id != id).ToList();
            return Task.FromResult(true);
        }

        public Task<List<Cart>> GetAllEntitiesAsync() => Task.FromResult(groups);
        public Task<Cart> GetFirstOrDefaultAsync(Expression<Func<Cart, bool>> predicate = null)
        {
            Cart cart = null;
            if (predicate == null) cart =  groups.FirstOrDefault();
            cart = groups.AsQueryable().FirstOrDefault(predicate);
            return Task.FromResult(cart);
        }
         

        public Task<Cart> UpdateAsync(Cart entity)
        {
            var group = groups.FirstOrDefault(item => item.Id == entity.Id);
            group.Name = entity.Name;
            group.MaxCapacity = entity.MaxCapacity;
            group.TrainId = entity.TrainId;
            return Task.FromResult(entity);
        }

        public void Clear()
        {
            groups = new List<Cart>();
        }
    }
}
