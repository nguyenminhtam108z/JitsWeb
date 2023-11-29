using Interface.RedisCache;
using StackExchange.Redis;
using System.Text.Json;

namespace RedisCache
{
	public class CacheService : ICacheService
	{
		IDatabase _cacheDB;

		public CacheService()
		{
			var redis = ConnectionMultiplexer.Connect("localhost:6379");
			_cacheDB = redis.GetDatabase();
		}

		public T GetData<T>(string key)
		{
			var value = _cacheDB.StringGet(key);
			if (!string.IsNullOrEmpty(value))
			{
				return JsonSerializer.Deserialize<T>(value);
			}
			return default;
		}

		public object RemoveData(string key)
		{
			var _exsit = _cacheDB.KeyExists(key);
			if (_exsit)
			{
				return _cacheDB.KeyDelete(key);
			}

			return false;
		}

		public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
		{
			var expireTime = expirationTime.DateTime.Subtract(DateTime.Now);
			return _cacheDB.StringSet(key, JsonSerializer.Serialize<T>(value), expireTime);
		}
	}
}