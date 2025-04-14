

using EquipLog.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipLog.Data.SQL.Models
{
    public class Tickets
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.TicketTitleMaxLength)]
        public string Title { get; set; }
        [Required]
        [MaxLength(EntityValidationsConstants.TicketPriorityMaxLength)]
        public string Priority { get; set; } // "Low", "Medium" "High"
        [Required]
        [MaxLength(EntityValidationsConstants.TicketStatusMaxLength)]   
        public string Status { get; set; } //  "Open", "In Progress", "Closed"
        [Required]
        public string Description { get; set; }

        [ForeignKey(nameof(EquipmentId))]
        public Guid EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        [ForeignKey(nameof(TechnicianId))]
        public Guid TechnicianId { get; set; } //  Assigned to technician
        public Technician Technician { get; set; }
        [ForeignKey(nameof(AppUserId))]
        public Guid AppUserId { get; set; } // Created by user
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;}
        public DateTime? ClosedAt { get; set; }


    }
}
