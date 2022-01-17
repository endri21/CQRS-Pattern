using EmployeeManagementLibrary.Commands;
using EmployeeManagementLibrary.Data;
using EmployeeManagementLibrary.Models;
using MediatR;


namespace EmployeeManagementLibrary.Handlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, EmployeeModel>
    {
        private readonly IDataAccess _dataAccess;

        public AddEmployeeHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<EmployeeModel> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
         => await _dataAccess.AddEmployee(request.employeeModel.firstName, request.employeeModel.lastName);
        ///=> Task.FromResult(_dataAccess.AddEmployee(request.employeeModel.firstName, request.employeeModel.lastName));
    }
}
