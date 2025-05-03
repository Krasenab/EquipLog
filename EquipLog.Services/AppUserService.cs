using EquipLog.Interfaces;
using EquipLogData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipLog.Services
{
    public class AppUserService : IAppUserService
    {
        private EquipLogDbContext _dbContext;
        public AppUserService(EquipLogDbContext dbContext)
        {
                this._dbContext = dbContext;
        }
        public async Task<string> GetEmailAsync(string corpId)
        {
            string? result = await _dbContext.ApplicationUsers.Where(x => x.CorporateID == corpId).Select(x => x.Email).FirstOrDefaultAsync();
            return result;
        }

       
    }
}
