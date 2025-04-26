using EquipLog.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipLog.ViewModels
{
    public class EditEquipmentViewModel
    {
        public EditEquipmentViewModel()
        {
            this.Categories = new List<CategoryViewModel>();
        }
        public Guid Id { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.EquipmentNameMaxLength)]
        [MinLength(EntityValidationsConstants.EquipmentNameMinLength)]
        public string EquipmentName { get; set; }

        [Required]
        [MaxLength(EntityValidationsConstants.EquipmentCurrentStatusMaxLength)]
        [MinLength(EntityValidationsConstants.EquipmentCurrentStatusMinLength)]
        public string CurrentStatus { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public int EquipmentWarrantyMonths { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.EquipmentManufacturerMaxLength)]
        public string Manufacturer { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.EquipmentModelMaxLength)]
        [MinLength(EntityValidationsConstants.EquipmentModelMinLength)]
        public string Model { get; set; }
        [MaxLength(EntityValidationsConstants.EquipmentAssetTagMaxLength)]
        [MinLength(EntityValidationsConstants.EquipmentAssetTagMinLength)]
        public string? AssetTag { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.TechCorporateIDMaxLength)]
        public string AddedFrom { get; set; }
        public string? Location { get; set; }
        public string? CustomProperties { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int LifeSpanYears { get; set; }
        public string Notes { get; set; }
        public int CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; } 
    }
}
