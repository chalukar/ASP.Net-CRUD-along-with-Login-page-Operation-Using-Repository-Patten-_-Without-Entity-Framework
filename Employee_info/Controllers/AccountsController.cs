using Employee_info.Models.DTO;
using Employee_info.Repositiries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employee_info.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AccountsController(IRoleRepository roleRepository,IUserRepository userRepository, IEmployeeRepository employeeRepository) {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var roles = await _roleRepository.GetRoles();
            ViewData["RoleId"] = new SelectList(roles, "Id", "RoleName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Models.DTO.RegisterDTO addRegister) 
        {
            if(addRegister.Password == addRegister.ConfirmPassword)
            {
                var user = new Models.Domain.User
                {
                    UserName = addRegister.UserName,
                    Password = addRegister.Password,
                    RoleId = addRegister.RoleId,
                };

                await _userRepository.RegisterUser(user);
                return View("RegisterSuccessfull");
                
            }

            return View(addRegister);
        }

        [HttpGet]
        public async Task<IActionResult> RegisterSuccessfull()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var user = await _userRepository.GetUser(login.UserName);
            if (user != null) { 

                if(user.Password == login.Password)
                {
                    return RedirectToAction("Index", "Employees");
                }
            }

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
