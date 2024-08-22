using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopCredit.Application.CQRS.Commands.CostomerAccountCommands;
using ShopCredit.Application.CQRS.Commands.CustomerAccountCommands;
using ShopCredit.Application.CQRS.Queries.CustomerAccountQueries;
using ShopCredit.Application.CQRS.Queries.CustomerQueries;

namespace ShopCredit.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerAccount : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerAccount(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> CustomerAccountList()
        {
            var getCustomerAccount = await _mediator.Send(new GetCustomerAccountQuery());
            return Ok(getCustomerAccount);
        }

        [HttpPost]

        public async Task<IActionResult> CreateCustomerAccount(CreateCustomerAccountCommand command)
        {
            await _mediator.Send(command);
            return Ok("Müşteri Hesabı Oluşturuldu");
        }

        [HttpDelete]

        public async Task<IActionResult> RemoveCustomerAccount(Guid id)
        {
            await _mediator.Send(new RemoveCustomerAccountCommand(id));
            return Ok("Müşteri Hesabı Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAccount(UpdateCustomerAccountCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hesap Bilgileri Güncellendi");
        }

        [HttpPut]
        public async Task<IActionResult> Payment(PaymentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ödeme yapıldı");
        }

        [HttpGet]
        public async Task<IActionResult> GetAccount(Guid Id)
        {
            var getAccount = await _mediator.Send(new GetAccountByIdQuery(Id));
            return Ok(getAccount);
        }

    }
}

