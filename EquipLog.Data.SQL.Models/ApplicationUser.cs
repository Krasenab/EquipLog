using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using EquipLog.Constants;
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
        [MaxLength(EntityValidationsConstants.ApplicationUserNameMaxLenght)]
        public string Name { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.ApplicationUserSureNameMaxLength)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.DepartmentMaxLength)]
        public string Department { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.ApplicationUserCorporateIDMaxLength)]
        public string CorporateID { get;set;}
        public List<Tickets> Tickets { get; set; }
        public List<AppImages> UserAppImages { get; set; }

    }
}
