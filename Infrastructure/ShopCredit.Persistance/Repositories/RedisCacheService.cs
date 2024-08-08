using ShopCredit.Application.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Infrastructure.Repositories
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer, IDatabase database)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _database = database;
        }

        public async Task Clear(string key)
        {
            await _database.KeyDeleteAsync(key);
        }

        public void ClearAll()
        {

            var redisEndpoints = _connectionMultiplexer.GetEndPoints(true);
            foreach (var redisEndpoint in redisEndpoints)
            {
                var redisServer = _connectionMultiplexer.GetServer(redisEndpoint);
                redisServer.FlushAllDatabases();
            }
        }

        public async Task<string> GetValueAsync(string key)
        {
            return await _database.StringGetAsync(key);
        }

        public async Task<bool> SetValueAsync(string key, string value)
        {
            return await _database.StringSetAsync(key, value,TimeSpan.FromHours(1));
        }
    }
}
