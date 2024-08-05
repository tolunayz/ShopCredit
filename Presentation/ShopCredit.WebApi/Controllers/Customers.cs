using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.CQRS.Queries;
using ShopCredit.Application.CQRS.Queries.CustomerQueries;

namespace ShopCredit.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Customers : ControllerBase
    {
        private readonly IMediator _mediator;
        public Customers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {

            var values = await _mediator.Send(new GetCustomerByIdQuery(id));
            //var values = await _getCustomerByIdQueryHandler.Handle(new GetCustomerByIdQuery(id));
            return Ok(values);
        }

        [HttpGet]

        public async Task<IActionResult> CustomerList()
        {
            var values = await _mediator.Send(new GetCustomerQuery());
            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Müşteri Eklendi");
        }

        [HttpDelete]

        public async Task<IActionResult> RemoveCustomer(Guid id)
        {
            await _mediator.Send(new RemoveCustomerCommand(id));
            return Ok("Müşteri Kaldırıldı");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Müşteri Bilgileri Güncellendi");
        }



    }
}
