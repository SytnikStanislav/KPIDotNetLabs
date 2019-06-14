using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity 
    {
        protected string ConnectionString;
        protected SqlDbConnectionHelper SqlHelper;

        public BaseRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.SqlHelper = new SqlDbConnectionHelper();
            //CreateTables();
        }

        public virtual Task<TEntity> CreateAsync(TEntity entity)
        {
            var sqltext = SqlHelper.GetInsertText(entity);
            var result = ExecuteNonQuery(sqltext);

            return Task.FromResult(result == 0 ? null : entity);
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            var sqltext = SqlHelper.GetUpdateText(entity);
            var result = ExecuteNonQuery(sqltext);
            return Task.FromResult(result == 0 ? null : entity);
        }

        public abstract Task<List<TEntity>> GetAllEntitiesAsync();
        public virtual Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null) { throw new NotImplementedException(); }
        
        public virtual Task<bool> DeleteAsync(Guid Id)
        {
            var sqlHelper = new SqlDbConnectionHelper();
            var sqltext = sqlHelper.GetDeleteByIdText<TEntity>(Id);
            var result = ExecuteNonQuery(sqltext);
            return Task.FromResult(result != 0);
        }

        public virtual void AddCollection(List<TEntity> entities)
        {
            entities.ForEach(async ent => await CreateAsync(ent));
        }

        public TEntity CreateEmptyObject()
        {
            var type = typeof(TEntity).Name;
            IEntity newObject = null;
            switch (type)
            {
                case "Cart": newObject = new Cart(); break;
                case "Train": newObject = new Train(); break;
                case "Passanger": newObject = new Passanger(); break;
                case "Ticket": newObject = new Ticket(); break;
                default: throw new Exception("No such type");
            }
            return (TEntity)newObject;
        }

        private void CreateTables()
        {
            ExecuteNonQuery(SqlHelper.CreateTableSqlText<Train>());
            ExecuteNonQuery(SqlHelper.CreateTableSqlText<Cart>());
            ExecuteNonQuery(SqlHelper.CreateTableSqlText<Passanger>());
            ExecuteNonQuery(SqlHelper.CreateTableSqlText<Ticket>());
        }

        protected virtual int ExecuteNonQuery(string commandText, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    // StoredProcedure, Text
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    var result = cmd.ExecuteNonQuery();
                    conn.Close();

                    return result;
                }
            }
        }

        protected virtual SqlDataReader ExecuteReader(string commandText, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = commandType;
            cmd.Parameters.AddRange(parameters);

            conn.Open();

            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
