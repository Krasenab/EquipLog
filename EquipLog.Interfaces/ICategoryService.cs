using EquipLog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipLog.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<CategoryViewModel>> GetAllCategoriesAsync();
    }
}
