using EquipLog.Interfaces;
using EquipLog.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<IActionResult> AllEquipment()
        {
            EquipmentFilterViewModel view = new EquipmentFilterViewModel()
            {
                SearchTerm = "",
                CategoryFilter = "",
                Categories = await _categoryService.GetAllCategoriesAsync(),
                Equipments = await _equipmentService.GetAllEquipmentAsync()
            };
            return View(view);
        }
        [HttpGet]
        public async Task<IActionResult> Filter(string searchTerm, string category)
        {
            
            var filterViewModel = await _equipmentService.GetAllFilteredEquipment(searchTerm, category);
            return PartialView("_EquipmentGridPartial", filterViewModel);
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
            if (!ModelState.IsValid) 
            {
                return View(viewModel);
            }
            _equipmentService.AddEquipment(viewModel);

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string Id) 
        {                      
            
            EditEquipmentViewModel model = await _equipmentService.GetEquipmentForEditAsync(Id);
            if (model==null)
            {
                return BadRequest();
            }
            model.Categories = await _categoryService.GetAllCategoriesAsync();
            
            return View(model);
        }
        [HttpPost]
        
        public  IActionResult Edit(EditEquipmentViewModel equipmentModel) 
        {
          
            if (!ModelState.IsValid)
            {
                return View(equipmentModel);
            }
            _equipmentService.Edit(equipmentModel);
            return RedirectToAction("Index", "Home"); // should be : "Equipment", "Details"

        }
       
    }
}
