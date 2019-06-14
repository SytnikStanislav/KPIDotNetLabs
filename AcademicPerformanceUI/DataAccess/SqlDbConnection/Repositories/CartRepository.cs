using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class CartRepository:BaseRepository<Cart>
    {
        public CartRepository(string sqlConnection):base(sqlConnection)
        {
        }

        public override Task<List<Cart>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Cart>();
            var reader = ExecuteReader(text);
            var list = new List<Cart>();
            while (reader.Read())
            {
                list.Add(new Cart()
                {
                    Id = (Guid)reader["Id"],
                    Name = reader["Name"].ToString(),
                    TrainId = (Guid)reader["TrainId"],
                    MaxCapacity = (int)reader["MaxCapacity"],
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }
    }
}
