using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipLog.ViewModels
{
    public class EquipmentListItemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; } 
        public string CategoryIcon { get; set; } 
        public string Status { get; set; } 
        public string SerialNumber { get; set; } 
        public string Location { get; set; } 
    }
}
