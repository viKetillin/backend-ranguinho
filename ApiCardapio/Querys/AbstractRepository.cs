using ApiCardapio.Interfaces.Repositories;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCardapio.Repositories
{
    public abstract class AbstractRepository
    {
        readonly IDbContext _context;

        protected AbstractRepository(IDbContext context)
        {
            _context = context;
        }

        protected IEnumerable<T> ExecuteQuery<T>(string sql, object parameters = null, System.Data.CommandType commandType = System.Data.CommandType.Text, int commandTimeout = 0)
        {
            return _context.Connection.Query<T>(sql: sql,param:parameters, commandType:commandType, commandTimeout:commandTimeout);
        } 
        
        protected async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, object parameters = null, System.Data.CommandType commandType = System.Data.CommandType.Text, int commandTimeout = 0)
        {
            return await _context.Connection.QueryAsync<T>(sql: sql,param:parameters, commandType:commandType, commandTimeout:commandTimeout);
        }
    }
}
