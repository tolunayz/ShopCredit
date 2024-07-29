using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopCredit.Application.CQRS.Commands.AdminCommands;
using ShopCredit.Application.CQRS.Commands.CostomerAccountCommands;
using ShopCredit.Application.CQRS.Handlers.AdminHandlers;
using ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers;
using ShopCredit.Application.CQRS.Queries;

namespace ShopCredit.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerAccount : ControllerBase
    {
        private readonly CreateCustomerAccountCommandHandler _createCustomerAccountCommandHandler;
        private readonly GetCustomerAccountByIdQueryHandler _getCustomerAccountByIdQueryHandler;
        private readonly GetCustomerAccountQueryHandler _getCustomerAccountQueryHandler;
        private readonly UpdateCustomerAccountCommandHandler _updateCustomerAccountCommandHandler;
        private readonly RemoveCustomerAccountCommandHandler _removeCustomerAccountCommandHandler;

        public CustomerAccount
        (
            CreateCustomerAccountCommandHandler createCustomerAccountCommandHandler, 
            GetCustomerAccountByIdQueryHandler getCustomerAccountByIdQueryHandler,
            GetCustomerAccountQueryHandler getCustomerAccountQueryHandler,
            UpdateCustomerAccountCommandHandler updateCustomerAccountCommandHandler,
            RemoveCustomerAccountCommandHandler removeCustomerAccountCommandHandler
        )
        {
            _createCustomerAccountCommandHandler = createCustomerAccountCommandHandler;
            _getCustomerAccountByIdQueryHandler = getCustomerAccountByIdQueryHandler;
            _getCustomerAccountQueryHandler = getCustomerAccountQueryHandler;
            _updateCustomerAccountCommandHandler = updateCustomerAccountCommandHandler;
            _removeCustomerAccountCommandHandler = removeCustomerAccountCommandHandler;
        }   

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerAccount(Guid customerId)
        {
            var values = await _getCustomerAccountByIdQueryHandler.Handle(new GetCustomerAccountByIdQuery(customerId));
            return Ok(values);
        }

        [HttpGet]

        public async Task<IActionResult> CustomerAccountList()
        {
            var values = await _getCustomerAccountQueryHandler.Handle();
            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateCustomerAccount(CreateCustomerAccountCommand command)
        {
            await _createCustomerAccountCommandHandler.Handle(command);
            return Ok("Müşteri Hesabı Oluşturuldu");
        }

        [HttpDelete]

        public async Task<IActionResult> RemoveCustomerAccount(Guid id)
        {
            await _removeCustomerAccountCommandHandler.Handle(new RemoveCustomerAccountCommand(id));
            return Ok("Müşteri Hesabı Silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCustomerAccount(UpdateCustomerAccountCommand command)
        {
            await _updateCustomerAccountCommandHandler.Handle(command);
            return Ok("Hesap Bilgileri Güncellendi");
        }
    }
}

