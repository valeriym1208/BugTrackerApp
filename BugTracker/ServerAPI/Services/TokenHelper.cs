using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using bug_tracker_data.Models;
using BugTracker.ServerAPI.Interfaces;
using BugTrackerData.Models;
using Microsoft.IdentityModel.Tokens;

namespace BugTracker.ServerAPI.Helpers
{
    public class TokenHelper : ITokenHelper
    {
        private readonly IConfiguration _config;
        private readonly IEfRepository<Token> _tokenRepository;

        public TokenHelper (IConfiguration config, IEfRepository<Token> tokenRepository)
        {
            _config = config;
            _tokenRepository = tokenRepository;
        }
        public string GenerateJwtToken(TeamMember teamMember)
        {
            var existingToken = _tokenRepository.GetAll().FirstOrDefault(t => t.teamMember.Id == teamMember.Id);
            if (existingToken == null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config["JWT:Secret"]);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(
                        new[] { new Claim("id", teamMember.Id.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(14),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };
                var tokenJwt = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(tokenJwt);
                _tokenRepository.Add(new Token() { TokenJwt = token, teamMember = teamMember });
                return token;
            }

            return existingToken.TokenJwt;
        }

        public async Task<Token> DeleteJwtToken(string token)
        {
            var tokenEntity = _tokenRepository.GetAll()
                .FirstOrDefault(t => t.TokenJwt == token);
            var deletedToken = await _tokenRepository.Delete(tokenEntity);
            return deletedToken;
;       }
    }
}
