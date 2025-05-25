using Microsoft.AspNetCore.Mvc;

namespace EquipLog.Controllers
{
    public class TicketController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
