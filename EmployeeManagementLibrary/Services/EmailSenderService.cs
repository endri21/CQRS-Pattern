using EmployeeManagementLibrary.Models;
using MediatR;


namespace EmployeeManagementLibrary.Services
{
  
    public record EmailSenderService(EmailSenderModel EmailSender) : IRequest<string>;
}
