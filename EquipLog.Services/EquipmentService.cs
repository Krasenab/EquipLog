using EquipLog.Data.SQL.Models;
using EquipLog.Interfaces;
using EquipLog.ViewModels;
using EquipLogData;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace EquipLog.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly EquipLogDbContext _dbContext;

        public EquipmentService(EquipLogDbContext equipLogDbContext)
        {
            this._dbContext = equipLogDbContext;    
        }
        public void AddEquipment(AddEquipmentViewModel addEquipmentViewModel)
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
                    AddedFrom = addEquipmentViewModel.AddedFrom,
                    CategoryId = addEquipmentViewModel.CategoryId
                };

                this._dbContext.Equipments.Add(equipment);
                this._dbContext.SaveChanges();            
            
        }

        public void Edit(EditEquipmentViewModel eqipmentViewModel)
        {
           Equipment? editedEquipment = _dbContext.Equipments.Where(x=>x.Id== eqipmentViewModel.Id).FirstOrDefault();
            editedEquipment.EquipmentName = eqipmentViewModel.EquipmentName;
            editedEquipment.CurrentStatus = eqipmentViewModel.CurrentStatus;
            editedEquipment.Description = eqipmentViewModel.Description;
            editedEquipment.SerialNumber = eqipmentViewModel.SerialNumber;
            editedEquipment.EquipmentWarrantyMonths = eqipmentViewModel.EquipmentWarrantyMonths;
            editedEquipment.Manufacturer = eqipmentViewModel.Manufacturer;
            editedEquipment.Model = eqipmentViewModel.Model;
            editedEquipment.AssetTag = eqipmentViewModel.AssetTag;
            editedEquipment.Location = eqipmentViewModel.Location;
            editedEquipment.CreatedAt = eqipmentViewModel.CreatedAt;
            editedEquipment.LifeSpanYears = eqipmentViewModel.LifeSpanYears;
            editedEquipment.Notes = eqipmentViewModel.Notes;
            editedEquipment.AddedFrom = eqipmentViewModel.AddedFrom;
            editedEquipment.CategoryId = eqipmentViewModel.CategoryId;
          
            this._dbContext.SaveChanges();
        }

        public async Task<EditEquipmentViewModel> GetEquipmentForEditAsync(string equipmentId)
        {
            EditEquipmentViewModel? editEquipmentViewModel = await _dbContext.Equipments.Where(x => x.Id.ToString() == equipmentId)
                .Select(e => new EditEquipmentViewModel()
                {
                    Id = e.Id,
                    EquipmentName = e.EquipmentName, 
                    CurrentStatus = e.CurrentStatus,
                    Description = e.Description,
                    SerialNumber = e.SerialNumber,
                    EquipmentWarrantyMonths = e.EquipmentWarrantyMonths,
                    Manufacturer = e.Manufacturer,
                    Model = e.Model,
                    AssetTag = e.AssetTag,
                    Location = e.Location,
                    CreatedAt = e.CreatedAt,
                    LifeSpanYears = e.LifeSpanYears,
                    Notes = e.Notes,
                    AddedFrom = e.AddedFrom,
                    CategoryId = e.CategoryId
                  
                }).FirstOrDefaultAsync();
            return editEquipmentViewModel;
        }
       
    }
}
