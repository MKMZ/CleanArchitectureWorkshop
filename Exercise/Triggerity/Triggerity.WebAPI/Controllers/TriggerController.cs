using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Triggerity.App.UseCases;
using Triggerity.Definitions;

namespace Triggerity.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriggerController : ControllerBase
    {
        private readonly ICommandHandler<GiveTriggerCommand> _giveTriggerHandler;
        private readonly ICommandHandler<SetupAllCompanyTriggerOrderCommand> _setupAllCompanyTriggerOrderHandler;

        public TriggerController(ICommandHandler<GiveTriggerCommand> giveTriggerHandler, ICommandHandler<SetupAllCompanyTriggerOrderCommand> setupAllCompanyTriggerOrderHandler)
        {
            _giveTriggerHandler = giveTriggerHandler;
            _setupAllCompanyTriggerOrderHandler = setupAllCompanyTriggerOrderHandler;
        }

        [HttpGet]
        public string Get()
        {
            return "test trigger api";
        }

        [HttpPost("giveTrigger")]
        public async Task Post([FromBody] GiveTriggerCommand command)
        {
            await _giveTriggerHandler.Handle(command);
        }

        [HttpPost("setupCompanyTriggerOrder")]
        public async Task Post([FromBody] SetupAllCompanyTriggerOrderCommand command)
        {
            await _setupAllCompanyTriggerOrderHandler.Handle(command);
        }
    }
}
