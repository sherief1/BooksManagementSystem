using BooksManagementSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BooksManagementSystem.authorization_for_special_users
{
    public class SpecialAccessHandler : AuthorizationHandler<SpecialAccessRequirement>
    {
        private readonly ISpecialAccessUsersDSL _specialAccessUsersDSL;

        public SpecialAccessHandler(ISpecialAccessUsersDSL specialAccessUsersDSL)
        {
            _specialAccessUsersDSL = specialAccessUsersDSL;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, SpecialAccessRequirement requirement)
        {
            var user = context.User;
            if (!user.Identity.IsAuthenticated) return;

            if (user.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == requirement.RequiredRole))
            {
                context.Succeed(requirement);
                return;
            }

            var usernameClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

            if (usernameClaim != null)
            {
                var specialAccessUsers = await _specialAccessUsersDSL.GetSpecialAccessUsersAsync();
                if (specialAccessUsers != null && specialAccessUsers.Contains(usernameClaim.Value))
                {
                    context.Succeed(requirement);
                    return;
                }
            }
            return;
        }
    }
}
