using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem
{
    public class SessionRequirement : IAuthorizationRequirement
    {
        public SessionRequirement(string requiredRole)
        {
            RequiredRole = requiredRole;
        }
        public string RequiredRole { get; }
    }
}
