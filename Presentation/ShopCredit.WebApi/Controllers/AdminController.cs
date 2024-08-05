using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopCredit.Application.CQRS.Commands.AdminCommands;
using ShopCredit.Application.CQRS.Queries.AdminQueries;

namespace ShopCredit.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmin(Guid id)
        {
            var adminById = await _mediator.Send(new GetAdminByIdQuery(id));
            return Ok(adminById);
        }

        [HttpGet]
        public async Task<IActionResult> AdminList()
        {
            
            var getAdmin =await _mediator.Send(new GetAdminQuery());
            return Ok(getAdmin);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(CreateAdminCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kullanıcı Oluşturuldu");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAdmin(Guid id)
        {
           
            await _mediator.Send(new RemoveAdminCommand(id));
            return Ok("Kullanıcı Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdmin(UpdateAdminCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kullanıcı Bilgileri Güncellendi");
        }
    } 
}
