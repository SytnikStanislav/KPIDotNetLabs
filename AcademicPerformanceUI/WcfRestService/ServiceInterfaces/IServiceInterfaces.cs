using System.ServiceModel;
using DataAccess.Models;

namespace WcfRestService.ServiceInterfaces
{
    [ServiceContract]
    public interface ICartService : IBaseService<Cart>
    {
    }

    [ServiceContract]
    public interface IPassangerService : IBaseService<Passanger>
    {
    }

    [ServiceContract]
    public interface ITicketService : IBaseService<Ticket>
    {
    }

    [ServiceContract]
    public interface ITrainService : IBaseService<Train>
    {
    }
}
