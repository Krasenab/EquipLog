using EquipLog.Data.SQL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EquipLog.Controllers
{
    public class AppUserController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;

        public AppUserController()
        {
                
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        //public IActionResult Register() 
        //{

        //}
       
    }
}
