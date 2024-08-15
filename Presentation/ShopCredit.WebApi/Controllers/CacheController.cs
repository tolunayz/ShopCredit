using Microsoft.AspNetCore.Mvc;
using ShopCredit.Application.CQRS.Results.AdminResults;
using ShopCredit.Application.Interfaces;
using System.Text.Json;

namespace ShopCredit.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IRedisCacheService _redisChanceService;

        public CacheController(IRedisCacheService redisChanceService)
        {
            _redisChanceService = redisChanceService;
        }

        [HttpPost]
        public async Task<IActionResult> RedisCacheSet([FromBody] GetAdminQueryResult admin)
        {
            if (admin == null)
            {
                return BadRequest("Admin verisi eksik.");
            }
            
            var customerJson = JsonSerializer.Serialize(admin);
            await _redisChanceService.SetValueAsync(admin.Id.ToString(), customerJson);
            return Ok();
        }

    }
}
