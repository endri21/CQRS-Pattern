using EmployeeManagementLibrary.Models;

namespace EmployeeManagementLibrary.Data
{
    public interface IEmailSender
    {
        Task<string> SendEmailAsync(EmailSenderModel emailSender);
    }
}
