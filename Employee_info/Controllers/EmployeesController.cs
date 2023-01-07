using Employee_info.Models.Domain;
using Employee_info.Models.DTO;
using Employee_info.Repositiries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Employee_info.Controllers
{
    
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICityRepository _cityRepository;

        public EmployeesController(IEmployeeRepository employeeRepository
            , ICityRepository cityRepository
            )
        {
            _employeeRepository = employeeRepository;
            _cityRepository = cityRepository;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _employeeRepository.GetEmplyee();
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
            var username = User.Identity.Name;
            var city = await _cityRepository.GetCity();
            ViewBag.UserName = username;
            ViewData["CityId"] = new SelectList(city, "Id", "CityName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeDTO addEmployeeDTO)
        {

            var employee = new Models.Domain.Employee
            {
                Id = addEmployeeDTO.Id,
                UserName = addEmployeeDTO.UserName,
                CityId = addEmployeeDTO.CityId,
                Age= addEmployeeDTO.Age,
                Sex = addEmployeeDTO.Sex,
                JoinedDate= addEmployeeDTO.JoinedDate,
                ContactNo= addEmployeeDTO.ContactNo,
            };

            await _employeeRepository.AddEmployee(employee);
            return RedirectToAction("Index");

        }

        public async Task<JsonResult> GenerateEmployeeID()
        {
            List<Employee> _emp = new List<Employee>();

            _emp = (List<Employee>)await _employeeRepository.GetEmployeeID();

            //var result = _emp[0].Id;

            if(_emp.Count == 0)
            {
                return Json(new
                {

                    Id = 0,
                }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    Id = _emp[0].Id,

                }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
            }

            
            
        }

    }
}
