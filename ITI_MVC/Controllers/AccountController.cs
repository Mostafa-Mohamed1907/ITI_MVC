using ITI_MVC.Models;
using ITI_MVC.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ITI_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        //For_Application_User
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRegister(RegisterUserViewModel RegUserViewModel)
        {
            if (ModelState.IsValid == true)
            {
                ApplicationUser AppUser = new ApplicationUser();
                AppUser.UserName = RegUserViewModel.UserName;
                AppUser.PasswordHash = RegUserViewModel.Password;
                AppUser.Address = RegUserViewModel.Address;
                IdentityResult result = await userManager.CreateAsync(AppUser, RegUserViewModel.Password);
                if (result.Succeeded)
                {
                    //cookie
                    await signInManager.SignInAsync(AppUser, false);
                    return RedirectToAction("Login");
                }
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                
            }
            return View("Register", RegUserViewModel);
        }
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLogin(LoginUserViewModel loginUserViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser AppUser =
                    await userManager.FindByNameAsync(loginUserViewModel.UserName);
                if (AppUser != null)
                {
                    bool found = await userManager.CheckPasswordAsync(AppUser, loginUserViewModel.Password);
                    if (found == true)
                    {
                        List<Claim> Claims = new List<Claim>();
                        Claims.Add(new Claim("UserAddress", AppUser.Address));

                        await signInManager.SignInWithClaimsAsync(AppUser,
                             loginUserViewModel.RememberMe, Claims);
                        //await signInManager.SignInAsync(AppUser, loginUserViewModel.RememberMe);
                        return RedirectToAction("Index", "Department");
                    }
                }
                ModelState.AddModelError("", "User Name or Password is wrong");
            }
            return View("Login", loginUserViewModel);
        }

        public async Task<IActionResult> Logout()
        {
           await signInManager.SignOutAsync();
           return View("Login");
        }
        /* ================================================*/
        
        //For_Application_Admin
        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRegisterAdmin(RegisterAdminViewModel RegAdminViewModel)
        {
            if (ModelState.IsValid == true)
            {
                ApplicationUser AppUser = new ApplicationUser();
                AppUser.UserName = RegAdminViewModel.AdminName;
                AppUser.PasswordHash = RegAdminViewModel.Password;
                AppUser.Address = RegAdminViewModel.Address;
                IdentityResult result = await userManager.CreateAsync(AppUser, RegAdminViewModel.Password);
                if (result.Succeeded)
                {
                    //Add Role to Admin
                    await userManager.AddToRoleAsync(AppUser, "Admin");
                    //cookie
                    await signInManager.SignInAsync(AppUser, false);
                    return RedirectToAction("LoginAdmin");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View("RegisterAdmin", RegAdminViewModel);
        }
        public IActionResult LoginAdmin()
        {
            return View("LoginAdmin");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLoginAdmin(LoginAdminViewModel loginAdminViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser AppUser =
                    await userManager.FindByNameAsync(loginAdminViewModel.AdminName);
                if (AppUser != null)
                {
                    bool found = await userManager.CheckPasswordAsync(AppUser, loginAdminViewModel.Password);
                    if (found == true)
                    {
                        List<Claim> Claims = new List<Claim>();
                        Claims.Add(new Claim("UserAddress", AppUser.Address));

                        await signInManager.SignInWithClaimsAsync(AppUser,
                             loginAdminViewModel.RememberMe, Claims);
                        //await signInManager.SignInAsync(AppUser, loginUserViewModel.RememberMe);
                        return RedirectToAction("Index", "Employee");
                    }
                }
                ModelState.AddModelError("", "User Name or Password is wrong");
            }
            return View("LoginAdmin", loginAdminViewModel);
        }

    }
}
