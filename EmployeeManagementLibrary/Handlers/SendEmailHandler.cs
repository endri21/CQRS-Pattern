using EmployeeManagementLibrary.Data;
using EmployeeManagementLibrary.Services;
using MediatR;


namespace EmployeeManagementLibrary.Handlers
{
    public class SendEmailHandler : IRequestHandler<EmailSenderService, string>
    {
        private readonly IEmailSender _emailSnder;

        public SendEmailHandler(IEmailSender emailSnder)
        {
            _emailSnder = emailSnder;
        }

        public async Task<string> Handle(EmailSenderService request, CancellationToken cancellationToken)
            => await _emailSnder.SendEmailAsync(request.EmailSender);
    }
}
