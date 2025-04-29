using EquipLog.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipLog.ViewModels
{
    public class LoginAppUserViewModel
    {

        [Required]
        [MaxLength(EntityValidationsConstants.ApplicationUserCorporateIDMaxLength)]
        [MinLength(EntityValidationsConstants.ApplicationUserCorporateIDMinLength)]
        public string CorporateId { get; set; }
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }

        public bool RemeberMe { get; set; }
    }
}
