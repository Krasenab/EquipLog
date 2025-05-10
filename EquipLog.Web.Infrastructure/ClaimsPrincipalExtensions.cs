using System.Security.Claims;

namespace EquipLog.Web.Infrastructure
{
    public static class ClaimsPrincipalExtensions
    {
        public static string currentUserId(this ClaimsPrincipal appUser) 
        {
            
           
           string result = appUser.FindFirst(ClaimTypes.NameIdentifier).Value;
           
            return result;
        }
    }
}
