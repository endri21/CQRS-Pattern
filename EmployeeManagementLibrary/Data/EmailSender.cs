using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.Test;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;
namespace EmployeeManagementLibrary.Data
{
    public class EmailSender : IEmailSender
    {

        private readonly string _host;
        private readonly int _port;
        private readonly bool _enableSSL;
        private readonly string _userName;
        private readonly string _password;
        private readonly SmtpClient _smtpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailSender> _logger;
        public EmailSender(IConfiguration configuration, ILogger<EmailSender> logger)
        {


            _configuration = configuration;
            _host = _configuration["EmailSender:Host"];
            _port = int.Parse(_configuration["EmailSender:Port"]);
            _enableSSL = Convert.ToBoolean(_configuration["EmailSender:EnableSSL"]);
            _userName = _configuration["EmailSender:UserName"];
            _password = _configuration["EmailSender:Password"];
            _smtpClient = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_userName, _password),
                EnableSsl = _enableSSL
            };
            _logger = logger;
        }

        public string Host => _host;

        public int Port => _port;

        public bool EnableSSL => _enableSSL;

        public string UserName => _userName;

        public string Password => _password;

        public IConfiguration Configuration => _configuration;

        public async Task<string> SendEmailAsync(EmailSenderModel emailSender)
        {
            try
            {
#pragma warning disable CS8604 // Possible null reference argument.
                await _smtpClient.SendMailAsync(emailSender?.userName, emailSender?.email, emailSender?.subject, emailSender?.htmlMessage);
#pragma warning restore CS8604 // Possible null reference argument.
                return "200";
            }
            catch (Exception ex)
            {
                _logger.LogDebug("Calling [SendEmailAsync]", ex);
                return "500";
            }

         

        }
    }
}
