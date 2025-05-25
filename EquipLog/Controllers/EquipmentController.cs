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
        public async Task<IActionResult> Create(AddEquipmentViewModel viewModel) 
        {
            if (!ModelState.IsValid) 
            {
                TempData["WarningMessage"] = "Invalid create form";
                viewModel.Categories = await _categoryService.GetAllCategoriesAsync();
                return View(viewModel);
            }

            _equipmentService.AddEquipment(viewModel);
            TempData["SuccessMessage"] = "You have successfuly added new equipment";
            return RedirectToAction("AllEquipment", "Equipment");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string Id) 
        {                                  
            EditEquipmentViewModel model = await _equipmentService.GetEquipmentForEditAsync(Id);
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
        public async Task<IActionResult> Delete(string id) 
        {
            if (!await _equipmentService.isExistAsync(id))
            {
                TempData["ErrorMessage"] = "Equipment does not exist !";
                return RedirectToAction("AllEquipment", "Equipment");
            }
            _equipmentService.DeleteEquipment(id);
            TempData["SuccessMessage"] = "Successfully deleted the given equipment";

            return RedirectToAction("AllEquipment", "Equipment");   
        }
       
    }
}
