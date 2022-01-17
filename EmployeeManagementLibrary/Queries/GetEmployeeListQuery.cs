using EmployeeManagementLibrary.Models;
using MediatR;


namespace EmployeeManagementLibrary.Queries
{
    public record GetEmployeeListQuery() : IRequest<IEnumerable<EmployeeModel>>;

}
