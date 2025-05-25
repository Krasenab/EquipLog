using EquipLog.Interfaces;
using EquipLog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EquipLog.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITechnicianService _technicianService;
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService,ITechnicianService technicianService) 
        {
            this._ticketService = ticketService;
            this._technicianService = technicianService;
        }   
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            AddTicketViewModel model = new AddTicketViewModel()
            {
                AllTechnicians = await _technicianService.GetAllTechnicansAsync()
            };

            return View(model);
        }
    }
}
