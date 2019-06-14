using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.InMemoryDb.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        public Task<TEntity> CreateAsync(TEntity entity)
        {
            switch (entity)
            {
                case Cart group: InMemoryLists.Groups.Add(group); break;
                case Train subject: InMemoryLists.Subjects.Add(subject); break;
                case Passanger teacher: InMemoryLists.Teachers.Add(teacher); break;
                case Ticket testResult: InMemoryLists.TestResults.Add(testResult); break;
                default: throw new Exception("There is no such type");
            }

            return Task.FromResult(entity);
        }

        public Task<bool> DeleteAsync(Guid Id)
        {
            InMemoryLists.Students = InMemoryLists.Students.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.Groups = InMemoryLists.Groups.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.Subjects = InMemoryLists.Subjects.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.Teachers = InMemoryLists.Teachers.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.Tests = InMemoryLists.Tests.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.SubjectInGroups = InMemoryLists.SubjectInGroups.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.TestResults = InMemoryLists.TestResults.Where(x => x.Id != Id)
                               .ToList();

            return Task.FromResult(true);
        }

        public Task<List<TEntity>> GetAllEntitiesAsync()
        {
            var type = typeof(TEntity);
            List<IEntity> list = null;
            if (type == typeof(Cart)) list =  InMemoryLists.Groups.Select(item => (IEntity)item).ToList();
            
            if (type == typeof(Train)) list = InMemoryLists.Subjects.Select(item => (IEntity)item).ToList();
            if (type == typeof(Passanger)) list = InMemoryLists.Teachers.Select(item => (IEntity)item).ToList();
            if (type == typeof(Ticket)) list = InMemoryLists.TestResults.Select(item => (IEntity)item).ToList();

            return Task.FromResult(list.Select(item => (TEntity)item).ToList());
        }

        public Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            switch (entity)
            {
                case Cart group:
                    {
                        var oldEntity = InMemoryLists.Groups.Find(o => o.Id == entity.Id);
                        oldEntity = (Cart)entity.Clone();
                        break;
                    }
                case Train subject:
                    {
                        var oldEntity = InMemoryLists.Subjects.Find(o => o.Id == entity.Id);
                        oldEntity = (Train)entity.Clone();
                        break;
                    }
                case Passanger teacher:
                    {

                        var oldEntity = InMemoryLists.Teachers.Find(o => o.Id == entity.Id);
                        oldEntity = (Passanger)entity.Clone();
                        break;
                    }
                case Ticket testResult:
                    {
                        var oldEntity = InMemoryLists.TestResults.Find(o => o.Id == entity.Id);
                        oldEntity = (Ticket)entity.Clone();
                        break;
                    }
                default: throw new Exception("There is no such type");
            }

            return Task.FromResult(entity);
        }

        public void AddCollection(List<TEntity> entities)
        {
            var type = typeof(TEntity);
            if (type == typeof(Cart))
            {
                InMemoryLists.Groups.Clear();
            }
            if (type == typeof(Train))
            {
                InMemoryLists.Subjects.Clear();
            }
            if (type == typeof(Passanger))
            {
                InMemoryLists.Teachers.Clear();
            }
            if (type == typeof(Ticket))
            {
                InMemoryLists.TestResults.Clear();
            }
            entities.ForEach(item => CreateAsync(item));
            //throw new Exception("No such types");
        }

        public TEntity CreateEmptyObject()
        {
            var type = typeof(TEntity);
            IEntity newObject = null;
            if (type == typeof(Cart)) newObject = new Cart();
            if (type == typeof(Train)) newObject = new Train();
            if (type == typeof(Passanger)) newObject = new Passanger();
            if (type == typeof(Ticket)) newObject = new Ticket();
            return (TEntity)newObject;
        }
    }
}
