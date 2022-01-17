using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementLibrary.Data;
public class DataWriteConnection<T> : IDataWriteConnection<T>
{
    private readonly ApplicationDbContext _context;

    public DataWriteConnection(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TResult> SaveDataAsync<TResult>(T request)
    {
        var data = request;
        await _context._employees.Add(data)
    }
}

