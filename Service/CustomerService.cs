using Dto.Service.Model;
using Entity.Repository.Models;
using Interface.Repository;
using Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;
		public CustomerService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public bool AddCustomer(CustomerServiceDto customer)
		{
			Customer customerAdd = new Customer()
			{
				CustomerId = Guid.NewGuid(),
				CustomerName = customer.CustomerName,
				Address = customer.Address,
				Age = customer.Age,
				Email = customer.Email,
				Phone = customer.Phone,
				Sex = customer.Sex,
			};
			try
			{
				var check = _customerRepository.Add(customerAdd);
			}
			catch (Exception ex)
			{
				return false;
			}

			return true;
		}

		public bool DeleteCustomer(Guid CustomerId)
		{
			//Employee employeeDelete = new Employee()
			//{
			//    EmployeeId = employee.EmployeeId,
			//};
			var check = _customerRepository.Delete(CustomerId);
			if (check != 1)
			{
				return false;
			}
			return true;
		}

		public IEnumerable<CustomerServiceDto> GetAllCustomer()
		{
			var result = new List<CustomerServiceDto>();
			var listEmployee = _customerRepository.GetAll();
			if (listEmployee.Any())
			{
				foreach (var employee in listEmployee)
				{
					CustomerServiceDto employeeServiceDto = new CustomerServiceDto()
					{
						Email = employee.Email,
						Address = employee.Address,
						CustomerName = employee.CustomerName,
						Age = employee.Age,
						Phone = employee.Phone,
						Sex = employee.Sex
					};
					result.Add(employeeServiceDto);
				}
			}
			return result;
		}

		public CustomerServiceDto GetCustomer(Guid customerId)
		{
			var result = new CustomerServiceDto();
			var listEmployee = _customerRepository.Get(customerId);
			if (listEmployee != null)
			{
				CustomerServiceDto employeeServiceDto = new CustomerServiceDto()
				{
					Email = listEmployee.Email,
					Address = listEmployee.Address,
					Sex = listEmployee.Sex,
					Phone = listEmployee.Phone,
					Age = listEmployee.Age,
					CustomerName = listEmployee.CustomerName,
				};
				result = employeeServiceDto;
			}
			return result;
		}

		public bool UpdateCustomer(CustomerServiceDto customer)
		{
			Customer employeeUpdate = new Customer()
			{
				CustomerId = customer.CustomerId,
				CustomerName= customer.CustomerName,
				Age= customer.Age,
				Phone= customer.Phone,
				Sex= customer.Sex,
				Address = customer.Address,
				Email = customer.Email,
			};
			var check = _customerRepository.Update(employeeUpdate);
			if (check != 1)
			{
				return false;
			}
			return true;
		}
	}
}
