using EmployeeManagementLibrary.Data;
using EmployeeManagementLibrary.DTO;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.Queries;
using MediatR;


namespace EmployeeManagementLibrary.Handlers
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, IEnumerable<EmployeeModel>>
    {
        private readonly IDataAccess _dataAccess;

        public GetEmployeeListHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<EmployeeModel>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
         => await _dataAccess.GetEmployees();
    }
}
