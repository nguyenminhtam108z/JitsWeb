using Microsoft.AspNetCore.Mvc;

namespace JitsController.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger)
        {
            _logger = logger;
        }

        public IActionResult GetAllEmployees()
        {
            _logger.LogInformation("Get All Supplier...");
            return null;
        }
    }
}
