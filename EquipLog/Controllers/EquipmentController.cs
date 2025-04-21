using EquipLog.Interfaces;
using EquipLog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EquipLog.Controllers
{
    public class EquipmentController : Controller
    {
        private ICategoryService _categoryService;
        private IEquipmentService _equipmentService;
        public EquipmentController(ICategoryService categoryService,IEquipmentService equipmentService)
        {
                this._categoryService = categoryService;
                this._equipmentService = equipmentService;
        }
        [HttpGet]
        public  async Task<IActionResult> Create()
        {
            AddEquipmentViewModel viewModel = new AddEquipmentViewModel()
            {
                Categories = await _categoryService.GetAllCategoriesAsync()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(AddEquipmentViewModel viewModel) 
        {

            return RedirectToAction("Index", "Home");
        }
       
    }
}
