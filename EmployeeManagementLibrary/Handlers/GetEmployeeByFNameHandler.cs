using EmployeeManagementLibrary.Data;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.Queries;
using MediatR;

namespace EmployeeManagementLibrary.Handlers
{
    public class GetEmployeeByFNameHandler : IRequestHandler<GetEmployeeByFNameQuery, EmployeeModel>
    {
        private readonly IDataAccess _dataAccess;

        public GetEmployeeByFNameHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<EmployeeModel> Handle(GetEmployeeByFNameQuery request, CancellationToken cancellationToken)
           =>await _dataAccess.GetEmployeeByFName(request.fName);
           ///=> Task.FromResult(_dataAccess.GetEmployeeByFName(request.fName));
    }
}
