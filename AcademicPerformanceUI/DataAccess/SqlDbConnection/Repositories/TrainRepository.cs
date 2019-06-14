using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class TrainRepository : BaseRepository<Train>
    {
        public TrainRepository(string sqlConnection):base(sqlConnection)
        {
        }

        public override Task<List<Train>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Train>();
            var reader = ExecuteReader(text);
            var list = new List<Train>();
            while (reader.Read())
            {
                list.Add(new Train()
                {
                    Id = (Guid)reader["Id"],
                    Name = reader["Name"].ToString(),
                    AmountOfCarts = (int)reader["AmountOfCarts"],
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }
    }
}
