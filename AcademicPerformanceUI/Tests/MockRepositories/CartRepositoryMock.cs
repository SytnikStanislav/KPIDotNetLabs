using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tests.MockRepositories
{
    public class CartRepositoryMock:IRepository<Cart>
    {
        private List<Cart> carts = new List<Cart>();

        public void AddCollection(List<Cart> entities)
        {
            carts.AddRange(entities);
        }

        public Task<Cart> CreateAsync(Cart entity)
        {
            carts.Add(entity);
            return Task.FromResult(entity);
        }

        public Cart CreateEmptyObject() => new Cart();

        public Task<bool> DeleteAsync(Guid id)
        {
            carts = carts.Where(item => item.Id != id).ToList();
            return Task.FromResult(true);
        }

        public Task<List<Cart>> GetAllEntitiesAsync() => Task.FromResult(carts);
        public Task<Cart> GetFirstOrDefaultAsync(Expression<Func<Cart, bool>> predicate = null)
        {
            Cart cart = null;
            if (predicate == null) cart =  carts.FirstOrDefault();
            cart = carts.AsQueryable().FirstOrDefault(predicate);
            return Task.FromResult(cart);
        }
         

        public Task<Cart> UpdateAsync(Cart entity)
        {
            var cart = carts.FirstOrDefault(item => item.Id == entity.Id);
            cart.Name = entity.Name;
            cart.MaxCapacity = entity.MaxCapacity;
            cart.TrainId = entity.TrainId;
            return Task.FromResult(entity);
        }

        public void Clear()
        {
            carts = new List<Cart>();
        }
    }
}
