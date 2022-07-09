using System.Security.Claims;
using bug_tracker_data.Models;
using BugTracker.ServerAPI.Interfaces;
using BugTracker.ServerAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly ITeamMemberService _tmService;
        private readonly ITokenService _tokenService;
        public TeamMemberController(ITeamMemberService tmService, ITokenService tokenService)
        {
            _tmService = tmService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public IActionResult Registration([FromBody] TeamMember teamMember)
        {
            var candidate = _tmService.Registration(teamMember);
            var accessToken = _tokenService.GenerateToken(
                "JWT:AccessKey", 15, candidate);
            Response.Cookies.Append("access", accessToken, new CookieOptions() 
                    {Expires = DateTimeOffset.Now.AddMinutes(15)});
            var refreshToken = _tokenService.GenerateToken(
                "JWT:RefreshKey", 43200, candidate);
            _tokenService.SaveRefreshToken(refreshToken, candidate);
            return Ok(candidate);
        }
    }
}
