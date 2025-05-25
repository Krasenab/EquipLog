using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipLog.ViewModels
{
    public class AddTicketViewModel
    {
        public string Title { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }        
        public string EquipmentId { get; set; }
        public string TechnicalId { get; set; } 
        public string AppUserId { get; set; }
    }
}
