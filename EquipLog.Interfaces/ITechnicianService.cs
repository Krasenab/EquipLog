using EquipLog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipLog.Interfaces
{
    public interface ITechnicianService
    {
        public Task<bool> isTechnicianAsync(string userId);
        public void JoinAsTechnician(JoinTechnicianViewModel joinViewModel);         
    }
}
