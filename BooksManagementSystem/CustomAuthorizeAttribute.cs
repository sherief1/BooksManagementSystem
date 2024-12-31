using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace BooksManagementSystem
{
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;


        // Constructor accepts role(s) to check against the claim
        public CustomAuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
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
                    context.Result = new ForbidResult(); // Return 403 Forbidden
                }
            }
        }
    }
}