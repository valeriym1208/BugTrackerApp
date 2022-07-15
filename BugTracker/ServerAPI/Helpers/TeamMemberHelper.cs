using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using bug_tracker_data.Models;
using Microsoft.IdentityModel.Tokens;

namespace BugTracker.ServerAPI.Helpers
{
    public static class TeamMemberHelper
    {
        public static string GenerateJwtToken(this IConfiguration config, TeamMember teamMember)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config["JWT:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new[] { new Claim("id", teamMember.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(14),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
