﻿using EquipLog.Data.SQL.Models;
using EquipLog.Interfaces;
using EquipLog.ViewModels;
using EquipLogData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EquipLog.Services
{
    public class TechnicianService : ITechnicianService
    {
        private EquipLogDbContext _dbContext;
        public TechnicianService(EquipLogDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<TechnicianViewModel>> GetAllTechnicansAsync()
        {
            List<TechnicianViewModel> all = await _dbContext.Technicians.Select(t=>new TechnicianViewModel() 
            {
                id = t.Id.ToString(),
                Name = t.Name,
                TechCorporateId = t.TechCorporateID,
                PhoneNumber = t.PhoneNumber,
                AppUserId = t.AppUserId.ToString(),

            }).ToListAsync();

            return all; 
        }

        public Task<bool> isTechnicianAsync(string userId)
        {
            return _dbContext.Technicians.Where(au => au.AppUserId.ToString() == userId).AnyAsync();
        }

        public void JoinAsTechnician(JoinTechnicianViewModel joinViewModel)
        {
            Technician technician = new Technician()
            {
                Name = joinViewModel.Name,
                TechCorporateID = joinViewModel.TechCorporateID,
                Skill = joinViewModel.Skill,
                PhoneNumber = joinViewModel.PhoneNumber,
                ReportsTo = joinViewModel.ReportsTo,
                AppUserId = Guid.Parse(joinViewModel.ApplicationUserId)

            };


            _dbContext.Technicians.Add(technician);
            _dbContext.SaveChanges();
        }
    }
}
