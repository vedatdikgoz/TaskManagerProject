
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagerUI.Identity;
using TaskManagerUI.Models;

namespace TaskManagerUI.Controllers
{
  
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager= userManager;
            _signInManager= signInManager;
        }

        [HttpGet]

        public IActionResult Login()
        {
            return View();
           
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                ModelState.AddModelError("","Kullanıcı bulunamadı.");
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            return View(model);
        }

        [HttpGet]

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                                          
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();          
            return RedirectToAction("Index", "Home");

        }

    }
}

