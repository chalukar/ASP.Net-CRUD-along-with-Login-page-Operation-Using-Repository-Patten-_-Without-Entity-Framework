using Employee_info.Repositiries;
using Employee_info.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employee_info.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IRoleRepository _roleRepository;
   
        public AccountsController(IRoleRepository roleRepository) {
            _roleRepository = roleRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var roles = await _roleRepository.GetRoles();

            return View();
        }
        [HttpPost]
        public IActionResult Register(Models.DTO.AddRegister addRegister) { 
            //string userExistingQuery = $"Select * from [User] Where UserName ='{addRegister.UserName}'";

            //bool userExists = _helper.UserAlreadyExists(userExistingQuery);
            //if (userExists == true)
            //{
            //    ViewBag.Error = "User Name Already Exists";
            //    return View("Register","LoginPartial");
            //}



            return View(addRegister);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
