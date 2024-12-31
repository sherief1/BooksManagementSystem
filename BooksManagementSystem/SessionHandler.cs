using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem
{
    public class SessionHandler : AuthorizationHandler<SessionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SessionRequirement requirement)
        {
            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                return Task.CompletedTask; // Not authenticated
            }

            if (context.User.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == requirement.RequiredRole))
            {
                context.Succeed(requirement); // User has the required role
            }

            return Task.CompletedTask;
        }
    }
}
