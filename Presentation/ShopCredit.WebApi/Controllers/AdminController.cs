using Microsoft.AspNetCore.Mvc;
using ShopCredit.Application.CQRS.Commands.AdminCommands;
using ShopCredit.Application.CQRS.Handlers.AdminHandlers;
using ShopCredit.Application.CQRS.Queries;

namespace ShopCredit.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly CreateAdminCommandHandler _createAdminCommandHandler;
        private readonly GetAdminByIdQueryHandler _getAdminByIdQueryHandler;
        private readonly GetAdminQueryHandler _getAdminQueryHandler;
        private readonly UpdateAdminCommandHandler _updateAdminCommandHandler;
        private readonly RemoveAdminCommandHandler _removeAdminCommandHandler;

        public AdminController
        (
            CreateAdminCommandHandler createAdminCommandHandler,
            GetAdminByIdQueryHandler getAdminByIdQueryHandler,
            GetAdminQueryHandler getAdminQueryHandler,
            UpdateAdminCommandHandler updateAdminCommandHandler,
            RemoveAdminCommandHandler removeAdminCommandHandler)
        {
            _createAdminCommandHandler = createAdminCommandHandler;
            _getAdminByIdQueryHandler = getAdminByIdQueryHandler;
            _getAdminQueryHandler = getAdminQueryHandler;
            _updateAdminCommandHandler = updateAdminCommandHandler;
            _removeAdminCommandHandler = removeAdminCommandHandler;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmin(int id)
        {
            var values = await _getAdminByIdQueryHandler.Handle(new GetAdminByIdQuery(id));
            return Ok(values);
        }

        [HttpGet]

        public async Task<IActionResult> AdminList()
        {
            var values = await _getAdminQueryHandler.Handle();
            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateAdmin(CreateAdminCommand command)
        {
            await _createAdminCommandHandler.Handle(command);
            return Ok("Kullanıcı Oluşturuldu");
        }

        [HttpDelete]

        public async Task<IActionResult> RemoveAdmin(int id)
        {
            await _removeAdminCommandHandler.Handle(new RemoveAdminCommand(id));
            return Ok("Kullanıcı Silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateAdmin(UpdateAdminCommand command)
        {
            await _updateAdminCommandHandler.Handle(command);
            return Ok("Kullanıcı Bilgileri Güncellendi");
        }
    } 
}
