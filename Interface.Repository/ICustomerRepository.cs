using Entity.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Repository
{
	public interface ICustomerRepository
	{
		IEnumerable<Customer> GetAll();

		Customer Get(Guid CustomerId);

		int Add(Customer customer);

		int Delete(Guid CustomerId);

		int Update(Customer customer);
	}
}
