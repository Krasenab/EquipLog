using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EquipLog.Data.SQL.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Tickets = new List<Tickets>();
            this.UserAppImages = new List<AppImages>();
        }

        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Department { get; set; }
        public string CorporateID { get;set;}
        public List<Tickets> Tickets { get; set; }
        public List<AppImages> UserAppImages { get; set; }

    }
}
