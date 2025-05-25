using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EquipLog.ViewModels
{
    public class TechnicianViewModel
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string TechCorporateId { get; set; }
        public string PhoneNumber { get; set; }
        public string AppUserId { get; set; }
    }
}
