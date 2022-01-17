using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementLibrary.Data;
public interface IDataWriteConnection <T>
{
    Task<TResult> SaveDataAsync<TResult>(T request);
}

