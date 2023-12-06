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
			// Gán chuỗi redis
			var options = ConfigurationOptions.Parse("localhost:6379");
			options.AllowAdmin = true;
			var redis = ConnectionMultiplexer.Connect(options);
			// tạo DB redis
			_cacheDB = redis.GetDatabase();
			//Loại bỏ tất cả cache đã xóa
			//var endPoint = redis.GetEndPoints();
			//var server = redis.GetServer(endPoint[0]);
			//server.FlushAllDatabases();
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

		public List<string> GetKeys()
		{
			var redis = ConnectionMultiplexer.Connect("localhost:6379");
			var key = redis.GetServer("localhost", 6379).Keys();
			List<string> result = new List<string>();
			result.AddRange(key.Select(key => (string)key).ToList());
			return result;
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