using LiepaLimitedTest.Domain.Contracts;
using LiepaLimitedTest.Domain.Entities;
using LiepaLimitedTest.Infrastructure.Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace LiepaLimitedTest.Infrastructure.Services
{
    public class DapperRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly string _connectionString;
        private readonly DapperConfiguration _dapperConfiguration;

        public DapperRepository(string connectionString, DapperConfiguration dapperConfiguration)
        {
            _connectionString = connectionString;
            _dapperConfiguration = dapperConfiguration;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<T>(_dapperConfiguration.GetSelectQuery());
            }
        }
               
        public async Task<T> GetByIdAsync(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                IEnumerable<T> collection = await db.QueryAsync<T>(_dapperConfiguration.GetSelectByIdQuery(), new { id });
                return collection.FirstOrDefault();
            }
        }
               
        public async Task<T> CreateAsync(T entity)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync(_dapperConfiguration.GetCreateQuery(), entity);
                return entity;
            }
        }
               
        public async Task<T> UpdateAsync(T entity)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync(_dapperConfiguration.GetUpdateQuery(), entity);
                return entity;
            }
        }

        public async Task DeleteAsync(T entity)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync(_dapperConfiguration.GetDeleteQuery(), new { entity.Id });
            }
        }
    }
}
