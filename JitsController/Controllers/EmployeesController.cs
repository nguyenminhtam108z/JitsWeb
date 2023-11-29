using Entity.Repository.Models;
using Interface.Service;
using JitsController.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace JitsController.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeService _employeeService;
        public EmployeesController(ILogger<EmployeesController> logger , IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet("api/getall")]
        public IEnumerable<EmployeeOutputDto> GetAllEmployees()
        {
			_logger.LogInformation("Get All Supplier...");
            var list = new List<EmployeeOutputDto>();
            var listEmployee = _employeeService.GetAllEmployee();
            if(listEmployee.Any())
            {
                foreach(var employee in listEmployee)
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
                        Photo = employee.Photo,
                        Salary = employee.Salary,
                        Status = employee.Status,
                    };
                    list.Add(employeeOutput);
				}
			}

            return list;
        }
    }
}
