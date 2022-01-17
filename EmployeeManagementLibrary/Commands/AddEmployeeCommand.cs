using EmployeeManagementLibrary.Models;
using MediatR;


namespace EmployeeManagementLibrary.Commands
{

    public record AddEmployeeCommand(EmployeeModel employeeModel) : IRequest<EmployeeModel>;
}
