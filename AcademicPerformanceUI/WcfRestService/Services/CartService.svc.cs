using DataAccess.Interfaces;
using DataAccess.Models;
using System.ServiceModel;
using WcfRestService.ServiceInterfaces;

namespace WcfRestService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CartService : BaseService<Cart>, ICartService 
    {
        public CartService(IRepository<Cart> repository):base(repository)
        {
                
        }

        public CartService()
        {
                
        }
    }
}
