using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipLog.ViewModels
{
    public class AddTicketViewModel
    {
        public AddTicketViewModel()
        {
            this.AllTechnicians = new List<TechnicianViewModel>();
        }
        public string Title { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }        
        public string EquipmentId { get; set; }

        public List<>
        public string TechnicianId { get; set; } 
        public List<TechnicianViewModel> AllTechnicians { get; set; }
        public string AppUserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
