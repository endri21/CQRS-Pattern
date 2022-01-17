
namespace EmployeeManagement.API.Controllers
{

    public class EmployeeController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await Mediator.Send(new GetEmployeeListQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(await Mediator.Send(new GetEmployeeByIdQuery(id)));

        [HttpGet($"{nameof(GetByName)}/{{fName}}")]
        public async Task<IActionResult> GetByName(string fName)
            => Ok(await Mediator.Send(new GetEmployeeByFNameQuery(fName)));

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeModel employeeModel)
         => Ok(await Mediator.Send(new AddEmployeeCommand(employeeModel)));

        [HttpPost]
        [Route("/SendEmail")]
        public async Task<IActionResult> SendEmail(EmailSenderModel emailSender)
           => Ok(await Mediator.Send(new EmailSenderService(emailSender)));
    }
}
