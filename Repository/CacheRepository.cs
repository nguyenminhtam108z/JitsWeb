using Interface.RedisCache;
using Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class CacheRepository : ICacheRepository
	{
		private readonly ICacheService _cacheService;

		public CacheRepository(ICacheService cacheService)
		{
			_cacheService = cacheService;
		}
		public List<string> GetAll()
		{
			List<string> list = new List<string>();
			list.AddRange(_cacheService.GetKeys());
			return list;
		}
	}
}
