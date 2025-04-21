using EquipLog.Interfaces;
using EquipLog.ViewModels;
using EquipLogData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipLog.Services
{
    public class CategoryService : ICategoryService
    {
        private EquipLogDbContext _dbContext;

        public CategoryService(EquipLogDbContext dbContext)
        {
            this._dbContext = dbContext;   
        }
        public async Task<List<CategoryViewModel>> GetAllCategoriesAsync()
        {
            List<CategoryViewModel> categories =await _dbContext.Categories.Select(c => new CategoryViewModel { Id = c.Id, CategoryName = c.CategoryName }).ToListAsync();
            return categories;  
        }
    }
}
