using ApiCardapio.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace ApiCardapio.Data
{
    public class DbContexto : IDbContext
    {
        readonly IConfiguration _config;
        public IDbConnection Connection { get; set; }

        public DbContexto(IConfiguration config)
        {
            _config = config;
            Connection = new SqlConnection(_config.GetConnectionString("default"));
            Connection.Open();
        }

        public TransactionScope OpenConnectionScopeTransaction()
        {
            TransactionScope scope = new TransactionScope();
            Connection = new SqlConnection(_config.GetConnectionString("default"));
            Connection.Open();
            return scope;
        }

        public TransactionScope OpenConnectionScopeTransactionAsync()
        {
            TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            Connection = new SqlConnection(_config.GetConnectionString("default"));
            Connection.Open();
            return scope;
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
