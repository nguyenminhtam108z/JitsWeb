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
        private readonly ICacheServices _cacheServices;
        private readonly IEmployeeService _employeeService;
        public EmployeesController(ILogger<EmployeesController> logger , ICacheServices cacheServices , IEmployeeService employeeService)
        {
            _logger = logger;
            _cacheServices = cacheServices;
            _employeeService = employeeService;
        }

        [HttpGet("api/getall")]
        public IEnumerable<EmployeeOutputDto> GetAllEmployees()
        {
			_logger.LogInformation("Get All Supplier...");
            var cacheData = _cacheServices.GetData<IEnumerable<EmployeeOutputDto>>("employee");
            var list = new List<EmployeeOutputDto>();
			if (cacheData != null && cacheData.Any())
			{
                return cacheData;
			}
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

            cacheData = list;
			// set Expiry Time
			var expiryTime = DateTimeOffset.Now.AddSeconds(30);
			_cacheServices.SetData<IEnumerable<EmployeeOutputDto>>("customer", cacheData, expiryTime);
			return cacheData;
        }
    }
}
