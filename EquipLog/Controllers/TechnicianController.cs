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
        public IActionResult Join()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Join(JoinTechnicianViewModel model) 
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }


            string applicationUserId = ClaimsPrincipalExtensions.currentUserId(this.User);
            model.ApplicationUserId = applicationUserId;
            _technicianService.JoinAsTechnician(model);
            return RedirectToAction("Policy","Home");
            
            
        }

    }
}
