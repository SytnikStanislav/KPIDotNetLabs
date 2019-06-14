using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class PassangerRepository : BaseRepository<Passanger>
    {
        public PassangerRepository(string sqlConnection):base(sqlConnection)
        {
        }

        public override Task<List<Passanger>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Passanger>();
            var reader = ExecuteReader(text);
            var list = new List<Passanger>();
            while (reader.Read())
            {
                list.Add(new Passanger()
                {
                    Id = (Guid)reader["Id"],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }
    }
}
