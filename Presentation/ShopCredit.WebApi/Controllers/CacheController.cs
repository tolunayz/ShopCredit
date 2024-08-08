using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;
using ShopCredit.Infrastructure.Repositories;
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
        public async Task<IActionResult> CacheGet(string key)
        {
            return Ok(await _redisChanceService.GetValueAsync(key));
        }

        [HttpPost]
        public async Task<IActionResult> CacheSet([FromBody] Admin admin)
        {
            if (admin == null)
            {
                return BadRequest("Admin verisi eksik.");
            }

            var customerJson = JsonSerializer.Serialize(admin);
            await _redisChanceService.SetValueAsync(admin.Id.ToString(), customerJson);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CacheDelete(string key)
        {
            await _redisChanceService.Clear(key);
            return Ok();
        }

    }
}
