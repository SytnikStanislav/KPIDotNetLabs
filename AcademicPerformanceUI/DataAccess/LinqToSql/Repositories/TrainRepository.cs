using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class TrainRepository : BaseRepository<Train>
    {
        public TrainRepository(string sqlConnection):base(sqlConnection)
        {
        }
    }
}
