using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.LinqToSql.Repositories;
using System;

namespace DataAccess.LinqToSql
{
    public class LinqToSqlUnitOfWork:IUnitOfWork
    {
        protected string ConnectionString;
        public LinqToSqlUnitOfWork(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private IRepository<Cart> cartRepository;
        public IRepository<Cart> CartRepository => cartRepository ?? (cartRepository = new CartRepository(ConnectionString));

        private IRepository<Train> trainRepostitory;
        public IRepository<Train> TrainRepostitory => trainRepostitory ?? (trainRepostitory = new TrainRepository(ConnectionString));

        private IRepository<Passanger> passangerRepository;
        public IRepository<Passanger> PassangerRepository => passangerRepository ?? (passangerRepository = new PassangerRepository(ConnectionString));

        private IRepository<Ticket> ticketRepository;
        public IRepository<Ticket> TicketRepository => ticketRepository ?? (ticketRepository = new TicketRepository(ConnectionString));

        public IRepository<Entity> GetRepositoryByEntityType<Entity>() where Entity : IEntity
        {
            var entityType = typeof(Entity);

            if (entityType == typeof(Cart)) return (IRepository<Entity>)CartRepository;
            if (entityType == typeof(Train)) return (IRepository<Entity>)TrainRepostitory;
            if (entityType == typeof(Passanger)) return (IRepository<Entity>)PassangerRepository;
            if (entityType == typeof(Ticket)) return (IRepository<Entity>)TicketRepository;

            throw new NotSupportedException();
        }
    }
}
