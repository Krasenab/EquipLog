using EquipLog.Interfaces;
using EquipLog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using EquipLog.Web.Infrastructure;

namespace EquipLog.Controllers
{
    public class TechnicianController : Controller
    {
        private ITechnicianService _technicianService;
        public TechnicianController(ITechnicianService technicianService)
        {
                this._technicianService = technicianService;
        }

        [HttpGet]
        public async Task<IActionResult> Join()
        {
            string currentUserId = ClaimsPrincipalExtensions.currentUserId(this.User);
            if (await _technicianService.isTechnicianAsync(currentUserId))
            {
                TempData["WarningMessage"] = "You are already a tehnician !";
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }
        
        [HttpPost]
        public IActionResult Join(JoinTechnicianViewModel model) 
        {
            if (!ModelState.IsValid) 
            {
                TempData["WarningMessage"] = "The entered data is invalid or missing.";
                return View(model);
            }
            string applicationUserId = ClaimsPrincipalExtensions.currentUserId(this.User);
            model.ApplicationUserId = applicationUserId;
            _technicianService.JoinAsTechnician(model);
            return RedirectToAction("Policy","Home");
                     
        }

    }
}
