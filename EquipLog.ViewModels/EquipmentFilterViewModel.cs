using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipLog.ViewModels
{
    public class EquipmentFilterViewModel
    {
        public string? SearchTerm { get; set; } 
        public string? CategoryFilter { get; set; } 

        public List<CategoryViewModel> Categories { get; set; } 

        public List<EquipmentListItemViewModel>? Equipments { get; set; }

        public int PageNumber { get; set; } = 1;
        public int TotalPages { get; set; } 
    }
}
