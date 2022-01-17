using EmployeeManagementLibrary.Data;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.Queries;
using MediatR;

namespace EmployeeManagementLibrary.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeModel>
    {
        private readonly IDataAccess _dataAccess;

        public GetEmployeeByIdHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<EmployeeModel> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
           => await _dataAccess.GetEmployeeById(request.id);
        ///=> Task.FromResult(_dataAccess.GetEmployeeById(request.id));

    }
}
