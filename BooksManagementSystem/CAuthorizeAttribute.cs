using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using BooksManagementSystem.Interfaces;

namespace BooksManagementSystem
{
    public class CAuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string[] _roles;

        private readonly ISpecialAccessUsersDSL _specialAccessUsersDSL;
        // Constructor accepts role(s) to check against the claim
        public CAuthorizeAttribute(ISpecialAccessUsersDSL specialAccessUsersDSL, params string[] roles)
        {
            _specialAccessUsersDSL = specialAccessUsersDSL;
            _roles = roles;
           
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            // Check if user is authenticated
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult(); // Return 401 Unauthorized
                return;
            }

            // Check if any of the provided roles match the user's role(s)
            if (_roles != null && _roles.Length > 0)
            {
                // Retrieve the "Role" claim values from the user's claims
                var userRoles = user.Claims
                    .Where(c => c.Type == ClaimTypes.Role) // Match based on the "Role" claim
                    .Select(c => c.Value);

                // If none of the user's roles match the required roles, forbid the request
                if (!_roles.Any(role => userRoles.Contains(role)))
                {
                    var usernameClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name); // Get username claim

                    if (usernameClaim != null)
                    {
                        var specialAccessUsers = await _specialAccessUsersDSL.GetSpecialAccessUsersAsync(); // Get special access users from DB
                        if (specialAccessUsers != null && specialAccessUsers.Contains(usernameClaim.Value))
                        {
                            return; // Allow access if username is in the special access list
                        }
                    }

                    context.Result = new ForbidResult(); // Return 403 Forbidden
                }
            }
        }
    }
}