using Microsoft.AspNetCore.Authorization;

namespace BooksManagementSystem.authorization_for_special_users
{
    public class SpecialAccessRequirement: IAuthorizationRequirement
    {
        public SpecialAccessRequirement(string requiredRole)
        {
            RequiredRole = requiredRole;
        }
        public string RequiredRole { get; }
    }
}
