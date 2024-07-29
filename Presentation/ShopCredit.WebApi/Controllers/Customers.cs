using Microsoft.AspNetCore.Mvc;
using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.CQRS.Handlers.CustomerHandlers;
using ShopCredit.Application.CQRS.Queries;

namespace ShopCredit.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Customers : ControllerBase
    {
        private readonly CreateCustomerCommandHandler _createCustomerCommandHandler;
        private readonly GetCustomerByIdQueryHandler _getCustomerByIdQueryHandler;
        private readonly GetCustomerQueryHandler _getCustomerQueryHandler;
        private readonly UpdateCustomerCommandHandler _updateCustomerCommandHandler;
        private readonly RemoveCustomerCommandHandler _removeCustomerCommandHandler;

        public Customers
            (CreateCustomerCommandHandler createCustomerCommandHandler,
            GetCustomerByIdQueryHandler getCustomerByIdQueryHandler,
            GetCustomerQueryHandler getCustomerQueryHandler,
            UpdateCustomerCommandHandler updateCustomerCommandHandler, 
            RemoveCustomerCommandHandler removeCustomerCommandHandler
            )
        {
            this._createCustomerCommandHandler = createCustomerCommandHandler;
            this._getCustomerByIdQueryHandler = getCustomerByIdQueryHandler;
            this._getCustomerQueryHandler = getCustomerQueryHandler;
            this._updateCustomerCommandHandler = updateCustomerCommandHandler;
            this._removeCustomerCommandHandler = removeCustomerCommandHandler;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var values = await _getCustomerByIdQueryHandler.Handle(new GetCustomerByIdQuery(id));
            return Ok(values);
        }

        [HttpGet]

        public async Task<IActionResult> CustomerList()
        {
            var values = await _getCustomerQueryHandler.Handle();
            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
        {
            await _createCustomerCommandHandler.Handle(command);
            return Ok("Müşteri Eklendi");
        }

        [HttpDelete]

        public async Task<IActionResult> RemoveCustomer(Guid id)
        {
            await _removeCustomerCommandHandler.Handle(new RemoveCustomerCommand(id));
            return Ok("Müşteri Kaldırıldı");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommand command)
        {
            await _updateCustomerCommandHandler.Handle(command);
            return Ok("Müşteri Bilgileri Güncellendi");
        }


       
    }
}
