

using System.ComponentModel.DataAnnotations;

namespace EquipLog.Data.SQL.Models
{
    public class Category
    {
        public Category()
        {
            this.Equipments = new List<Equipment>();
            this.EquipmentsParts = new List<EquipmentParts>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public List<Equipment> Equipments { get; set; }
        public List<EquipmentParts> EquipmentsParts { get; set; }

    }
}
