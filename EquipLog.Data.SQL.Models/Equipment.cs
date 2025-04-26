using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EquipLog.Constants;

namespace EquipLog.Data.SQL.Models
{
    public class Equipment
    {
        public Equipment()
        {
            this.Tickets = new List<Tickets>();
            this.EquipmentParts = new List<EquipmentParts>();
            this.EquipmentImages = new List<AppImages>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.EquipmentNameMaxLength)]
        public string EquipmentName { get; set; }

        [Required]
        [MaxLength(EntityValidationsConstants.EquipmentCurrentStatusMaxLength)]
        public string CurrentStatus { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SerialNumber {  get; set; }
        [Required]
        public int EquipmentWarrantyMonths { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.EquipmentManufacturerMaxLength)]
        public string Manufacturer { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.EquipmentModelMaxLength)]
        public string Model { get; set; }
        [MaxLength(EntityValidationsConstants.EquipmentAssetTagMaxLength)]
        public string? AssetTag { get; set; }
        public string? Location { get; set; }
        public string? CustomProperties { get; set; }        
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int LifeSpanYears { get; set; }
        public string Notes { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.TechCorporateIDMaxLength)]
        public string AddedFrom { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } 
        public List<Tickets> Tickets { get; set; }
        public List<EquipmentParts> EquipmentParts { get; set; }
        public List<AppImages> EquipmentImages { get; set; }

    }
}
