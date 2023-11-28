using Interface.Repository;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public static class Injection
	{
		public static void Inject(IServiceCollection service)
		{
			service.AddScoped<IEmployeeRepository, EmployeeRepository>();
		}
	}
}
