using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipLog.Interfaces
{
    public interface IAppUserService
    {
        Task<string> GetEmailAsync(string corpId);
    }
}
