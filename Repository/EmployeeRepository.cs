using Entity.Repository;
using Entity.Repository.Models;
using Interface.RedisCache;
using Interface.Repository;
using RedisCache;
using System.Collections.Generic;

namespace Repository
{
	public class EmployeeRepository : IEmployeeRepository
    {
        private readonly JitsStoreContext _context;
        private readonly ICacheService _cacheServices;
        public EmployeeRepository(JitsStoreContext context, ICacheService cacheService) 
        {
            _context = context;
            _cacheServices = cacheService;
        }

		public int Add(Employee employee)
		{
			var addObject = _context.Add(employee);
			var expiryTime = DateTimeOffset.Now.AddSeconds(30);
			_cacheServices.SetData<Employee>($"employee{employee.EmployeeId}", addObject.Entity, expiryTime);
			return _context.SaveChanges();
		}

		public IEnumerable<Employee> GetAll()
        {
			var cacheData = _cacheServices.GetData<IEnumerable<Employee>>("employee");
			if (cacheData != null && cacheData.Any())
			{
				return cacheData;
			}

			cacheData = _context.Employees.ToList();
			// set Expiry Time
			var expiryTime = DateTimeOffset.Now.AddSeconds(30);
			_cacheServices.SetData<IEnumerable<Employee>>("employee", cacheData, expiryTime);
			return cacheData;
        }
    }
}