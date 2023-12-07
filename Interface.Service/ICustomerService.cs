using Dto.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Service
{
	public interface ICustomerService
	{
		IEnumerable<CustomerServiceDto> GetAllCustomer();

		CustomerServiceDto GetCustomer(Guid customerId);

		bool AddCustomer(CustomerServiceDto customer);

		bool DeleteCustomer(Guid customerId);

		bool UpdateCustomer(CustomerServiceDto customer);
	}
}
