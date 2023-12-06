using JitsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JitsWebAPI.Controllers;
using System.Text;

namespace JitsWebAPI.Controllers
{
    public class EmployeesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7191/api");
        private readonly HttpClient _client;

        public EmployeesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<EmployeeViewModel> employeesList = new List<EmployeeViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Employees/Get").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employeesList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
            }
            return View(employeesList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Employees/AddEmployee", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Employee Created.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

            return View();
        }
    }
}
