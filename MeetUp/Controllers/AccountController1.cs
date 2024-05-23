using MeetUp.Models;
using MeetUp.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeetUp.Controllers
{
    public class AccountController1 : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController1(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(!ModelState.IsValid) return View(registerVM);
            AppUser appUser = new AppUser
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.UserName,
                Email = registerVM.Email,
            };
            IdentityResult result=await _userManager.CreateAsync(appUser,registerVM.Password);
            if(!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
                return View(registerVM);
            }
            return RedirectToAction("login","accountcontroller1");
            
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser result = await _userManager.FindByNameAsync(loginVM.UsernameOrEmail);
            if (result == null)
            {
                result = await _userManager.FindByEmailAsync(loginVM.UsernameOrEmail);
                if(result == null)
                {
                    ModelState.AddModelError("", "user ve ya email yanlisdir");
                    return View(loginVM);
                }
            }
            await _signInManager.CheckPasswordSignInAsync(result,loginVM.Password,true);
            return RedirectToAction("Index", "Home");
        }

    }
}
