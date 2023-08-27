namespace HouseRentingSystem.Web.Infrastructure.Extensions
{
    using System.Security.Claims;

    public static class ClaimPrincipalExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
            => user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
