﻿using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class StudentRepository : GenericRepository<Student>
    {
        public StudentRepository(string sqlConnection):base(sqlConnection)
        {

        }

        public override Task<Student> CreateAsync(Student entity)
        {
            var sqltext = $"insert into Student (Id, FirstName, LastName, PhoneNumber, GroupId) " +
                $"values({entity.Id}, {entity.FirstName}, {entity.LastName}, {entity.PhoneNumber}, '{entity.GroupId}')";
            var result  = ExecuteNonQuery(sqltext);
            return Task.FromResult(result == 0 ? null : entity);
        }

        public override Task<bool> DeleteAsync(Guid Id)
        {
            var sqlHelper = new SqlDbConnectionHelper();
            var sqltext = sqlHelper.GetDeleteByIdText<Student>(Id);
            var result = ExecuteNonQuery(sqltext);
            return Task.FromResult(result != 0);
        }

        public override Task<Student> GetFirstOrDefaultAsync(Expression<Func<Student, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override void ReplaceCollection(List<Student> entities)
        {
            throw new NotImplementedException();
        }

        public override Task<Student> UpdateAsync(Student entity)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Student>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Student>();
            var reader = ExecuteReader(text);
            var list = new List<Student>();
            while (reader.Read())
            {
                list.Add(new Student()
                {
                    Id = (Guid)reader["Id"],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    GroupId = (Guid)reader["GroupId"]
                });
            }
            reader.Close();
            return Task.FromResult(new List<Student>());
        }
    }
}
