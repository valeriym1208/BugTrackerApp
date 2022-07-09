using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using bug_tracker_data;
using bug_tracker_data.Models;
using BugTracker.ServerAPI.Interfaces;
using BugTrackerData.DTO;
using BugTrackerData.Models;
using Microsoft.IdentityModel.Tokens;

namespace BugTracker.ServerAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly DataContext _context;
        public TokenService(IConfiguration config, DataContext context)
        {
            _config = config;
            _context = context;
        }

        public string GenerateToken(string key, int minutesExpires, TeamMember tm)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config[key]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, tm.Email),

            };
            var token = new JwtSecurityToken(
                _config["JWT:Issuer"],
                _config["JWT:Audience"], claims,
                expires: DateTime.Now.AddMinutes(minutesExpires),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public void SaveRefreshToken(string refreshToken, TeamMember tm)
        {
            var tokenData = _context.Tokens.FirstOrDefault(token => token.teamMember.Id == tm.Id);
            if (tokenData != null)
            {
                tokenData.RefreshToken = refreshToken;
                _context.SaveChanges();
            }
            else
            {
                var token = _context.Tokens.Add(
                    new Token { RefreshToken = refreshToken, teamMember = tm });
                _context.SaveChanges();
            }
        }

        
    }
}
