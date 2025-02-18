using Authentication.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authentication.Configurations;
using Authentication.Data;
using Authentication.Helper;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtSettings _jwtSettings;

        public AuthService(ApplicationDbContext context, JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;
        }

        public string GenerateJwtToken(User user)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
                    Console.WriteLine("Key: " + BitConverter.ToString(key));
                    Console.WriteLine("Token handler: " + tokenHandler);
                
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.RoleId.ToString())
                    };
                    foreach (var claim in claims)
                    {
                        Console.WriteLine($"Claim: {claim.Type} - {claim.Value}");
                    }
                
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes),
                        SigningCredentials =
                            new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                    };
                    Console.WriteLine($"Token descriptor: {tokenDescriptor}");
                
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);
                
                    // Log token to check
                    Console.WriteLine("Generated Token: " + tokenString);
                
                    return tokenString;
                }

        public async Task<User> Authenticate(string username, string password)
        {
            var hashedPassword = PasswordEncryption.HashPassword(password);

            return await _context.Users
                .SingleOrDefaultAsync(u => u.Username == username && u.PasswordHash == hashedPassword);
        }
    }
}