using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Cart>  CartRepository { get; }
        IRepository<Train>  TrainRepostitory { get; }
        IRepository<Passanger>  PassangerRepository { get; }
        IRepository<Ticket>  TicketRepository { get; }

        IRepository<Entity> GetRepositoryByEntityType<Entity>() where Entity : IEntity;
    }
}
