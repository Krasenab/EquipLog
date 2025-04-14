using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EquipLog.Constants;
namespace EquipLog.Data.SQL.Models
{
    public class AppImages
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string UniqueName { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public Guid? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
  
        [ForeignKey(nameof(EquipmentId))]
        public Guid? EquipmentId { get; set; }
        public Equipment? Equipment { get; set; }

        [ForeignKey(nameof(EquipmentPartsId))]
        public Guid? EquipmentPartsId { get; set; }
        public EquipmentParts? EquipmentParts { get; set; }



    }
}
