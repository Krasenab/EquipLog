using Microsoft.AspNetCore.Mvc;

namespace EquipLog.Controllers
{
    public class TechnicianController : Controller
    {
        [HttpGet]
        public IActionResult Join()
        {
            return View();
        }

    }
}
