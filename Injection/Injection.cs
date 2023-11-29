using Entity.Repository;
using Interface.RedisCache;
using Interface.Repository;
using Interface.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RedisCache;
using Repository;
using Service;

namespace Injection
{
	public static class Injection
	{
		public static void Inject(IServiceCollection service, string connectionString)
		{
			service.AddDbContext<JitsStoreContext>(options =>
		options.UseSqlServer(connectionString));
			service.AddTransient<IEmployeeRepository, EmployeeRepository>();
			service.AddTransient<IEmployeeService, EmployeeService>();
			service.AddTransient<ICacheService, CacheService>();
		}
	}
}