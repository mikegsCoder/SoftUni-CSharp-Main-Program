using System.Security.Claims;
using static HouseRentingSystem.Web.AdminConstants;

namespace HouseRentingSystem.Web.Infrastructure
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;

        public static bool IsAdmin(this ClaimsPrincipal user)
           => user.IsInRole(AdminRoleName);
    }
}