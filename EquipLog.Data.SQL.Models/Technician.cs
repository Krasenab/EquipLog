using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using EquipLog.Constants;

namespace EquipLog.Data.SQL.Models
{
    public class Technician
    {
        public Technician()
        {
            this.Tickets = new List<Tickets>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.TechnicianNameMaxLength)]  
        public string Name { get; set; }
        [Required] 
        [MaxLength(EntityValidationsConstants.TechCorporateIDMaxLength)]
        public string TechCorporateID { get; set; }
        [Required]  
        public string Skill { get; set; }

        [MaxLength(EntityValidationsConstants.ApplicationUserNameMaxLenght)]
        public string? ReportsTo { get; set; }
        [MaxLength(EntityValidationsConstants.PhoneNumberMaxLength)]
        public string? PhoneNumber { get; set; }
        [ForeignKey(nameof(AppUserId))]
        public Guid AppUserId { get; set; }
        public ApplicationUser AppUser { get; set;}
        public List<Tickets> Tickets { get; set; }  
    }
}
