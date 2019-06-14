using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class TicketRepository:BaseRepository<Ticket>
    {
        public TicketRepository(string sqlConnection):base(sqlConnection)
        {
        }
    }
}
