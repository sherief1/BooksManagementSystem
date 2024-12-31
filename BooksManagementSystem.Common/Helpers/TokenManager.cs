using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BooksManagementSystem.Common.Helpers
{
    public static class TokenManager
    {
        public static string secretKey = "this_is_my_super_secret_key_12345";

        //Method to generate JWT token
        public static string GenerateToken(string username, string role)
        {
            // Define the token expiration (e.g., 1 hour)
            var expirationTime = DateTime.UtcNow.AddHours(1);

            // Create claims - you can add more claims as needed
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username), // Add user-specific claim (e.g., username)
            new Claim(ClaimTypes.Role, role) // Add user role claim
        };



            // Create the signing credentials using the symmetric security key (same as your secret key)
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                SecurityAlgorithms.HmacSha256Signature // Use HMAC SHA256 for signing the token
            );

            // Create the JWT token descriptor with claims, expiration, and signing credentials
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expirationTime, // Set expiration
                SigningCredentials = signingCredentials
            };

            // Create a token handler to generate the token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Return the serialized token
            return tokenHandler.WriteToken(token);
        }
    }
}
