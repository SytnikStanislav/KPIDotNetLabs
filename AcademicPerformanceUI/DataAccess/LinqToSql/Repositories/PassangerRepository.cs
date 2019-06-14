using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class PassangerRepository : BaseRepository<Passanger>
    {
        public PassangerRepository(string sqlConnection):base(sqlConnection)
        {
        }
    }
}
