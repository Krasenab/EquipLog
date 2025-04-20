using Microsoft.AspNetCore.Mvc;

namespace EquipLog.Controllers
{
    public class EquipmentController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
