using Employee_info.Repositiries;
using Microsoft.AspNetCore.Mvc;

namespace Employee_info.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _employeeRepository.GetEmplyee();
            return View(roles);
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateEmployee()
        //{

        //}
    }
}
