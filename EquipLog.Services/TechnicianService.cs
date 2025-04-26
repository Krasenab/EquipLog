using EquipLog.Data.SQL.Models;
using EquipLog.Interfaces;
using EquipLog.ViewModels;
using EquipLogData;

namespace EquipLog.Services
{
    public class TechnicianService : ITechnicianService
    {
        private EquipLogDbContext _dbContext;
        public TechnicianService(EquipLogDbContext dbContext)
        {
            this._dbContext = dbContext;
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
