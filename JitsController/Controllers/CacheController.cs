using Interface.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JitsController.Controllers
{
	public class CacheController : Controller
	{
		private readonly ICacheRepository _cacheRepository;
		public CacheController(ICacheRepository cacheRepository)
		{
			_cacheRepository = cacheRepository;
		}

		[HttpGet("api/getAllCache")]
		public List<string> GetAllCache()
		{
			List<string> result = new List<string>();
			result.AddRange(_cacheRepository.GetAll());
			return result;
		}
	}
}
