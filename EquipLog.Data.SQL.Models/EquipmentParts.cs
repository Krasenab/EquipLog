using EquipLog.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EquipLog.Data.SQL.Models
{
   public class EquipmentParts
    {
        public EquipmentParts()
        {
            this.PartsImages = new List<AppImages>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.PartNameMaxLength)]
        public string PartName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [MaxLength (EntityValidationsConstants.PartAddedFromMaxLenght)]
        public string AddedFrom { get; set; } // Employee who added the part to the equipment
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string SerialNumber { get; set; }  
        public string? PartNumber { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.PartStatusMaxLength)]
        public string Status { get; set; } // like : 'under repair' , 'Faulty', 'Replaced', 'factory part', 'available in stock', 'In exploitation'
        public string? Notes { get; set; }
        public int Quntity { get; set; }
        public DateTime? InstalledDate { get; set;}
        
        [ForeignKey(nameof(EqиipmentId))]
        public Guid? EqиipmentId {  get; set; }
        public Equipment? Equipment { get; set; }        
        public List<AppImages> PartsImages { get; set; }


    }
}
