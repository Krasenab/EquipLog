using EquipLog.Data.SQL.Models;
using EquipLog.Interfaces;
using EquipLog.ViewModels;
using EquipLogData;
using Microsoft.Data.SqlClient;

namespace EquipLog.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly EquipLogDbContext _dbContext;

        public EquipmentService(EquipLogDbContext equipLogDbContext)
        {
            this._dbContext = equipLogDbContext;    
        }
        public void AddEquipmentAsync(AddEquipmentViewModel addEquipmentViewModel)
        {
            
            Equipment equipment = new Equipment()
            {
                EquipmentName = addEquipmentViewModel.EquipmentName,
                CurrentStatus = addEquipmentViewModel.CurrentStatus,
                Description = addEquipmentViewModel.Description,
                SerialNumber = addEquipmentViewModel.SerialNumber,
                EquipmentWarrantyMonths = addEquipmentViewModel.EquipmentWarrantyMonths,
                Manufacturer = addEquipmentViewModel.Manufacturer,
                Model = addEquipmentViewModel.Model,
                AssetTag = addEquipmentViewModel.AssetTag,
                Location = addEquipmentViewModel.Location,
                CreatedAt = addEquipmentViewModel.CreatedAt,
                LifeSpanYears = addEquipmentViewModel.LifeSpanYears,
                Notes = addEquipmentViewModel.Notes,
                CategoryId = addEquipmentViewModel.CategoryId
            };

           this._dbContext.Equipments.Add(equipment);
           this._dbContext.SaveChanges();
            
            
        }
    }
}
