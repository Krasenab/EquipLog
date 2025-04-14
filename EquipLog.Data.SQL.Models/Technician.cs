using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipLog.Data.SQL.Models
{
    public class Technician
    {
        public Technician()
        {
            this.Tickets = new List<Tickets>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TechCorporateID { get; set; }
        public string Skill { get; set; }
        public Guid AppUserId { get; set; }
        public ApplicationUser AppUser { get; set;}
        public List<Tickets> Tickets { get; set; }  
    }
}
