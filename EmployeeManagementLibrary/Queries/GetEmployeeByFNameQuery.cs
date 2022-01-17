using EmployeeManagementLibrary.Models;
using MediatR;

namespace EmployeeManagementLibrary.Queries
{
    public record GetEmployeeByFNameQuery(string fName) : IRequest<EmployeeModel>;
}
