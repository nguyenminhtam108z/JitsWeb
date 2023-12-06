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
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeService _employeeService;
        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<EmployeeOutputDto> Get()
        {
            _logger.LogInformation("Get All Supplier...");
            var list = new List<EmployeeOutputDto>();
            var listEmployee = _employeeService.GetAllEmployee();
            if (listEmployee.Any())
            {
                foreach (var employee in listEmployee)
                {
                    EmployeeOutputDto employeeOutput = new EmployeeOutputDto()
                    {
                        Address = employee.Address,
                        BirthDate = employee.BirthDate,
                        ContactType = employee.ContactType,
                        Email = employee.Email,
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        Phone = employee.Phone,
                        Salary = employee.Salary,
                        Status = employee.Status,
                    };
                    list.Add(employeeOutput);
                }
            }

            return list;
        }

        [HttpGet("{EmployeeId}")]
        public EmployeeOutputDto GetEmployee(Guid EmployeeId)
        {
            _logger.LogInformation("Find Employee..");
            var employee = new EmployeeOutputDto();
            var employees = _employeeService.GetEmployee(EmployeeId);
            if (employees != null)
            {
                employee.EmployeeId = employees.EmployeeId;
                employee.Address = employees.Address;
                employee.BirthDate = employees.BirthDate;
                employee.ContactType = employees.ContactType;
                employee.Email = employees.Email;
                employee.Name = employees.Name;
                employee.Phone = employees.Phone;
                employee.Salary = employees.Salary;
                employee.Status = employees.Status;
                return employee;
            }
            return employee;
        }

        [HttpPost]
        public bool AddEmployee(EmployeeInputDto input)
        {
            _logger.LogInformation("Add Employee..");
            var employeeServiceDto = new EmployeeServiceDto()
            {
                EmployeeId = Guid.NewGuid(),
                Address = input.Address,
                BirthDate = input.BirthDate,
                ContactType = input.ContactType,
                Email = input.Email,
                Name = input.Name,
                Phone = input.Phone,
                Salary = input.Salary,
                Status = input.Status,
            };
            var employeeAdd = _employeeService.AddEmployee(employeeServiceDto);
            if (employeeAdd != true)
            {
                return false;
            }
            return true;
        }

        [HttpPut]
        public bool UpdateEmployee(EmployeeInputDto input)
        {
            _logger.LogInformation("Delete Employee..");
            var employeeServiceDto = new EmployeeServiceDto()
            {
                EmployeeId = input.EmployeeId,
                Address = input.Address,
                BirthDate = input.BirthDate,
                ContactType = input.ContactType,
                Email = input.Email,
                Name = input.Name,
                Phone = input.Phone,
                Salary = input.Salary,
                Status = input.Status,
            };
            var employeeAdd = _employeeService.UpdateEmployee(employeeServiceDto);
            if (employeeAdd != true)
            {
                return false;
            }
            return true;
        }

        [HttpDelete("{EmployeeId}")]
        public bool DeleteEmployee(Guid EmployeeId)
        {
            _logger.LogInformation("Update Employee..");
            //var employeeServiceDto = new EmployeeServiceDto()
            //{
            //    EmployeeId = EmployeeId,
            //};
            var employeeAdd = _employeeService.DeleteEmployee(EmployeeId);
            if (employeeAdd != true)
            {
                return false;
            }
            return true;
        }
    }
}
