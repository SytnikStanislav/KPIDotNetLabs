using DataAccess.InMemoryDb.Repository;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;

namespace DataAccess.InMemoryDb
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        private IRepository<Cart> groupRepository;
        public IRepository<Cart> CartRepository => groupRepository ?? (groupRepository = new CartRepository());

        private IRepository<Train> subjectRepostitory;
        public IRepository<Train> TrainRepostitory => subjectRepostitory ?? (subjectRepostitory = new TrainRepository());

        private IRepository<Passanger> teacherRepository;
        public IRepository<Passanger> PassangerRepository => teacherRepository ?? (teacherRepository = new PassangerRepository());

        private IRepository<Ticket> testResultRepository;
        public IRepository<Ticket> TicketRepository => testResultRepository ?? (testResultRepository = new TicketRepository());



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
