using EquipLog.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipLog.ViewModels
{
    public class JoinTechnicianViewModel
    {
        [MaxLength(EntityValidationsConstants.TechnicianNameMaxLength)]
        [MinLength(EntityValidationsConstants.TechCorporateIDMinLength)]
        public string Name { get; set; }
    
        [MaxLength(EntityValidationsConstants.TechCorporateIDMaxLength)]
        public string TechCorporateID { get; set; }
        public string Skill { get; set; }

        [MaxLength(EntityValidationsConstants.ApplicationUserNameMaxLenght)]
        [MinLength(EntityValidationsConstants.ApplicationUserNameMinLength)]
        public string? ReportsTo { get; set; }
        [MaxLength(EntityValidationsConstants.PhoneNumberMaxLength)]
        [MinLength(EntityValidationsConstants.PhoneNumberMinLength)]
        public string? PhoneNumber { get; set; }

        public string? ApplicationUserId { get; set; }
    }
}
