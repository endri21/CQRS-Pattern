using Dapper;
using System.Data;

namespace EmployeeManagementLibrary.Data;

public class DataReadConnection : IDataReadConnection
{
    private readonly ApplicationDbContext _context;

    public DataReadConnection(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> ExecuteAsync(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        => await _context.DbConnection.ExecuteAsync(sql, param, transaction);
    public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        => (await _context.DbConnection.QueryAsync<T>(sql, param, transaction)).AsList();
    public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        => await _context.DbConnection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
    public async Task<T> QuerySingleAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        => await _context.DbConnection.QuerySingleAsync<T>(sql, param, transaction);
}

