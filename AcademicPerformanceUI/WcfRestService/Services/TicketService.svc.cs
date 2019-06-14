using DataAccess.Models;
using System.ServiceModel;
using WcfRestService.ServiceInterfaces;

namespace WcfRestService.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class TicketService :BaseService<Ticket>, ITicketService
    {
    }
}
