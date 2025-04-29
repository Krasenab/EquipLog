using EquipLog.Data.SQL.Models;
using EquipLog.Interfaces;
using EquipLog.Services;
using EquipLog.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EquipLog.Controllers
{
    public class AppUserController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private IAppUserService _appUserService;

        public AppUserController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IAppUserService appUserService)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._appUserService = appUserService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            AppUserRegisterViewModel viewModel = new AppUserRegisterViewModel();
            return View(viewModel);
        }
        [HttpPost]
        
        public async Task<IActionResult> Register(AppUserRegisterViewModel regModel) 
        {

            if (!ModelState.IsValid) 
            {
                return View(regModel);
            }

            ApplicationUser appUser = new ApplicationUser()
            {
               UserName = regModel.Email,
               Name = regModel.Name,
               Email = regModel.Email,
               Surname = regModel.Surname,
               CorporateID = regModel.CorporateID,
               Department = regModel.Department
              
            };

            await this._userManager.SetEmailAsync(appUser, regModel.Email);
            IdentityResult result = await this._userManager.CreateAsync(appUser, regModel.Password);
            if (result.Succeeded)
            {
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
            }
            await _signInManager.SignInAsync(appUser, false);
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null) 
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            LoginAppUserViewModel login = new LoginAppUserViewModel()
            {
                ReturnUrl = returnUrl
            };
            
            return View(login);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginAppUserViewModel viewModel) 
        {
            if (!ModelState.IsValid) 
            {
                return View(viewModel); 
            }
            string email = await _appUserService.GetEmailAsync(viewModel.CorporateId);
            if (string.IsNullOrEmpty(email)) 
            {
                this.TempData["WarningMessage"] = "Invalid corporate identity !";
                return View(viewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(email,viewModel.Password,viewModel.RemeberMe,false);
            if (!result.Succeeded)
            {
                this.TempData["ErrorMessage"] = "There was error while logging you ";
                return View(viewModel);
            }
            this.TempData["SuccessMessage"] = "Successfully login in equipment log app";

            return RedirectToAction("Index", "Home");


        }
        
        
       
    }
}
