using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class CartRepository:BaseRepository<Cart>
    {
        public CartRepository(string sqlConnection):base(sqlConnection)
        {
        }
    }
}
