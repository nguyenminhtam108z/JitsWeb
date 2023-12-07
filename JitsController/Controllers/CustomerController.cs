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
            _logger.LogInformation("Find Employee..");
            var employee = new CustomerOutputDto();
            var employees = _customerService.GetCustomer(CustomerId);
            if (employees != null)
            {
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
            _logger.LogInformation("Add Employee..");
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

        //[HttpPut]
        //public bool UpdateEmployee(EmployeeInputDto input)
        //{
        //    _logger.LogInformation("Delete Employee..");
        //    var employeeServiceDto = new EmployeeServiceDto()
        //    {
        //        EmployeeId = input.EmployeeId,
        //        Address = input.Address,
        //        BirthDate = input.BirthDate,
        //        ContactType = input.ContactType,
        //        Email = input.Email,
        //        Name = input.Name,
        //        Phone = input.Phone,
        //        Salary = input.Salary,
        //        Status = input.Status,
        //    };
        //    var employeeAdd = _employeeService.UpdateEmployee(employeeServiceDto);
        //    if (employeeAdd != true)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //[HttpDelete("{EmployeeId}")]
        //public bool DeleteEmployee(Guid EmployeeId)
        //{
        //    _logger.LogInformation("Update Employee..");
        //    //var employeeServiceDto = new EmployeeServiceDto()
        //    //{
        //    //    EmployeeId = EmployeeId,
        //    //};
        //    var employeeAdd = _employeeService.DeleteEmployee(EmployeeId);
        //    if (employeeAdd != true)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
