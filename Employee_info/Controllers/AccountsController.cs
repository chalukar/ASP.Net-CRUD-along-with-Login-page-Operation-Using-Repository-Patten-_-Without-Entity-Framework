using Employee_info.Models.DTO;
using Employee_info.Repositiries;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Employee_info.Models.Domain;
using NuGet.Protocol.Plugins;

namespace Employee_info.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        

        public AccountsController(IRoleRepository roleRepository,IUserRepository userRepository) {
            _roleRepository = roleRepository;
            _userRepository = userRepository;

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
            var ExsitsUser = await _userRepository.GetUser(addRegister.UserName);
            if(ExsitsUser == null)
            {
                if (addRegister.Password == addRegister.ConfirmPassword)
                {
                    var user = new Models.Domain.User
                    {
                        UserName = addRegister.UserName,
                        Password = EncryptPassword(addRegister.Password),
                        RoleId = addRegister.RoleId,
                    };

                    await _userRepository.RegisterUser(user);
                    return View("successfullyRegistration");

                }
                else
                {
                    TempData["errorMessage"] = "Password and Confirm Password does not match";
                    return View(addRegister);
                }
            }
            else
            {
                TempData["errorMessage"] = "User Already Exsits";
                return View(addRegister);
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
            if (user != null)
            {
                bool isValid =(user.UserName == login.UserName && DecryptPassword(user.Password) == login.Password);
                if(isValid)
                {
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, login.UserName) },
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    var principe = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principe);
                    HttpContext.Session.SetString("UserName", login.UserName);
                    if(user.RoleId == 1)
                    {
                        //Admin
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        //User
                        return RedirectToAction("Index", "Employees");
                    }
                   
                }
                else
                {
                    TempData["errorMessage"] = "Invalid User Name or Password";
                }
            }
            else
            {
                TempData["errorMessage"] = "Invalid User Name";
            }

            return View();
        }
        public async Task<ActionResult> LogOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Accounts");

        }

        public IActionResult Index()
        {
            return View();
        }

        public static string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return null;
            }
            else
            {
                byte[] storePassword = ASCIIEncoding.ASCII.GetBytes(password);
                string encriptedpassword = Convert.ToBase64String(storePassword);
                return encriptedpassword;


            }
        }

        public static string DecryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return null;
            }
            else
            {
                byte[] encryptPassword = Convert.FromBase64String(password);
                string Decryptpassword = ASCIIEncoding.ASCII.GetString(encryptPassword);
                return Decryptpassword;


            }
        }
    }
}
