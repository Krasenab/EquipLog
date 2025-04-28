using EquipLog.Constants;
using System.ComponentModel.DataAnnotations;


namespace EquipLog.ViewModels
{
    public class AppUserRegisterViewModel
    {
       
        [Required]
        [MaxLength(EntityValidationsConstants.ApplicationUserNameMaxLenght)]
        [MinLength(EntityValidationsConstants.ApplicationUserCorporateIDMinLength)]
        public string Name { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.ApplicationUserSureNameMaxLength)]
        [MinLength(EntityValidationsConstants.ApplicationUserSureNameMinLength)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.DepartmentMaxLength)]
        public string Department { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password does not match")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        [MaxLength(EntityValidationsConstants.ApplicationUserCorporateIDMaxLength)]
        [MinLength(EntityValidationsConstants.ApplicationUserCorporateIDMinLength)]
        public string CorporateID { get; set; }
    }
}
