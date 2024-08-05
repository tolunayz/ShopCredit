using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ShopCredit.Application.CQRS.Commands;
using System.Threading.Tasks;

namespace ShopCredit.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public ReportController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = _publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateReport([FromBody] GenerateReportCommand command)
        {
            await _publishEndpoint.Publish(command);
            return Ok();
        }
    }
}
