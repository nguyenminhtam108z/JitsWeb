using Dto.Service.Model;
using Entity.Repository.Models;
using Interface.Service;
using JitsController.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Net;
using System.Numerics;

namespace JitsController.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<CustomerOutputDto> Get()
        {
            _logger.LogInformation("Get All Customer...");
            var list = new List<CustomerOutputDto>();
            var listEmployee = _customerService.GetAllCustomer();
            if (listEmployee.Any())
            {
                foreach (var employee in listEmployee)
                {
                    CustomerOutputDto employeeOutput = new CustomerOutputDto()
                    {
                        CustomerId = employee.CustomerId,
                        Address = employee.Address,
                        Email = employee.Email,
                        Sex = employee.Sex,
                        Age = employee.Age,
                        CustomerName = employee.CustomerName,
                        Phone = employee.Phone,
                    };
                    list.Add(employeeOutput);
                }
            }

            return list;
        }

        [HttpGet("{CustomerId}")]
        public CustomerOutputDto GetCustomer(Guid CustomerId)
        {
            _logger.LogInformation("Find Customer..");
            var employee = new CustomerOutputDto();
            var employees = _customerService.GetCustomer(CustomerId);
            if (employees != null)
            {
                employee.CustomerId = employees.CustomerId;
                employee.Address = employees.Address;
                employee.Email = employees.Email;
                employee.Phone = employees.Phone;
                employee.CustomerName = employees.CustomerName;
                employee.Age = employees.Age;
                employee.Sex = employees.Sex;
                return employee;
            }
            return employee;
        }

        [HttpPost]
        public bool AddCustomer(CustomerInputDto input)
        {
            _logger.LogInformation("Add Customer..");
            var employeeServiceDto = new CustomerServiceDto()
            {
                CustomerId = Guid.NewGuid(),
                Sex = input.Sex,
                Age = input.Age,
                CustomerName = input.CustomerName,
                Address = input.Address,
                Email = input.Email,
                Phone = input.Phone,
            };
            var employeeAdd = _customerService.AddCustomer(employeeServiceDto);
            if (employeeAdd != true)
            {
                return false;
            }
            return true;
        }

        [HttpPut]
        public bool UpdateCustomer(CustomerInputDto input)
        {
            _logger.LogInformation("Update Employee..");
            var customerServiceDto = new CustomerServiceDto()
            {
                CustomerId = input.CustomerId,
                CustomerName = input.CustomerName,
                Sex = input.Sex,
                Age = input.Age,
                Address = input.Address,
                Email = input.Email,
                Phone = input.Phone,
            };
            var customerAdd = _customerService.UpdateCustomer(customerServiceDto);
            if (customerAdd != true)
            {
                return false;
            }
            return true;
        }

        [HttpDelete("{CustomerId}")]
        public bool DeleteCustomer(Guid CustomerId)
        {
            _logger.LogInformation("Delete Customer..");
            var employeeAdd = _customerService.DeleteCustomer(CustomerId);
            if (employeeAdd != true)
            {
                return false;
            }
            return true;
        }
    }
}
