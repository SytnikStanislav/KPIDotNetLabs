using DataAccess.Interfaces;
using DataAccess.SqlDbConnection;
using System;
using System.Collections.Generic;

namespace WcfRestService
{
    public class BaseService<ModelType> where ModelType: IEntity
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static Lazy<SqlDbConnectionUnitOfWork> UnitOfWork = new Lazy<SqlDbConnectionUnitOfWork>(() => new SqlDbConnectionUnitOfWork(connectionString));

        IRepository<ModelType> Repository = null;
        public BaseService(IRepository<ModelType> repository)
        {
            Repository = repository;
        }

        public BaseService()
        {
        }

        public virtual ModelType CreateEntity(ModelType entity)
        {
            try
            {
                Console.WriteLine(entity);
                IRepository<ModelType> repository = null;
                repository = Repository ?? UnitOfWork.Value.GetRepositoryByEntityType<ModelType>();
                var createdEntity = repository.CreateAsync(entity).Result;
                return createdEntity;
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public virtual bool DeleteEntity(string id)
        {
            try
            {
                IRepository<ModelType> repository = null;
                repository = Repository ?? UnitOfWork.Value.GetRepositoryByEntityType<ModelType>();
                var isDeleted = repository.DeleteAsync(Guid.Parse(id)).Result;
                return isDeleted;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual List<ModelType> GetEntities()
        {
            try
            {
                IRepository<ModelType> repository = null;
                repository = Repository ?? UnitOfWork.Value.GetRepositoryByEntityType<ModelType>();
                var list = repository.GetAllEntitiesAsync().Result;
                var newList = new List<ModelType>();
                list.ForEach(item => newList.Add(item));
                return newList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual bool UpdateEntity(ModelType entity)
        {
            try
            {
                IRepository<ModelType> repository = null;
                repository = Repository ?? UnitOfWork.Value.GetRepositoryByEntityType<ModelType>();
                var updatedEntity = repository.UpdateAsync(entity).Result;
                return updatedEntity != null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}