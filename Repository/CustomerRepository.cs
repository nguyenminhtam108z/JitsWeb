using Entity.Repository;
using Entity.Repository.Models;
using Interface.RedisCache;
using Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly JitsStoreContext _context;
		private readonly ICacheService _cacheServices;
		public CustomerRepository(JitsStoreContext context, ICacheService cacheService)
		{
			_context = context;
			_cacheServices = cacheService;
		}

		public int Add(Customer customer)
		{
			var addObject = _context.Add(customer);
			var expiryTime = DateTimeOffset.Now.AddDays(2);
			_cacheServices.SetData<Customer>($"customer{customer.CustomerId}", addObject.Entity, expiryTime);
			return _context.SaveChanges();
		}

		public int Delete(Guid CustomerId)
		{
			var exist = _context.Customers.FirstOrDefault(item => item.CustomerId.Equals(CustomerId));
			if (exist != null)
			{
				_cacheServices.RemoveData($"customer{CustomerId}");
				_context.Customers.Remove(exist);
			}

			return _context.SaveChanges();
		}

		public Customer Get(Guid CustomerId)
		{
			var exist = _context.Customers.FirstOrDefault(item => item.CustomerId.Equals(CustomerId));
			if (exist != null)
			{
				return exist;
			}

			return new Customer();
		}

		public IEnumerable<Customer> GetAll()
		{
			var cacheData = _cacheServices.GetData<IEnumerable<Customer>>("customer");
			if (cacheData != null && cacheData.Any())
			{
				return cacheData;
			}

			cacheData = _context.Customers.ToList();
			// set Expiry Time
			var expiryTime = DateTimeOffset.Now.AddDays(2);
			_cacheServices.SetData<IEnumerable<Customer>>("customer", cacheData, expiryTime);
			return cacheData;
		}

		public int Update(Customer customer)
		{
			var exist = _context.Customers.FirstOrDefault(item => item.CustomerId.Equals(customer.CustomerId));
			if (exist != null)
			{
				_cacheServices.RemoveData($"customer{customer.CustomerId}");
				_context.Customers.Remove(exist);
				var updateObject = _context.Add(customer);
				var expiryTime = DateTimeOffset.Now.AddDays(2);
				_cacheServices.SetData<Customer>($"customer{customer.CustomerId}", updateObject.Entity, expiryTime);
			}
			return _context.SaveChanges();
		}
	}
}
