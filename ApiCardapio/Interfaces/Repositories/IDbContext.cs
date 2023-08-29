using System;
using System.Data;
using System.Transactions;

namespace ApiCardapio.Interfaces.Repositories
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Connection { get; }
        TransactionScope OpenConnectionScopeTransaction();
        TransactionScope OpenConnectionScopeTransactionAsync();
    }
}
