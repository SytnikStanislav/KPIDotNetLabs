using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class TicketRepository:BaseRepository<Ticket>
    {
        public TicketRepository(string sqlConnection):base(sqlConnection)
        {
        }

        public override Task<List<Ticket>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Ticket>();
            var reader = ExecuteReader(text);
            var list = new List<Ticket>();
            while (reader.Read())
            {
                list.Add(new Ticket()
                {
                    Id = (Guid)reader["Id"],
                    PassangerId = (Guid)reader["PassangerId"],
                    CartId = (Guid)reader["CartId"],
                    ArrivalStation = (string)reader["ArrivalStation"],
                    ArrivalDate = (DateTime)reader["ArrivalDate"],
                    DepartureStation = (string)reader["ArrivalStation"],
                    DepartureTime = (DateTime)reader["ArrivalDate"],
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }
    }
}
