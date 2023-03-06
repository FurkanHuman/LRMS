using System.Security.Claims;

namespace Core.Security.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType) =>
        claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();

    public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal) =>
        claimsPrincipal?.Claims(ClaimTypes.Role);
    

    public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal) =>
        Guid.Parse(claimsPrincipal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault());    
}