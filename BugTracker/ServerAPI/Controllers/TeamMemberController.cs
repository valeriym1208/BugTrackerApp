using System.Security.Claims;
using bug_tracker_data.Models;
using BugTracker.ServerAPI.Helpers;
using BugTracker.ServerAPI.Interfaces;
using BugTracker.ServerAPI.Services;
using BugTrackerData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly ITeamMemberService _memberService;
        public TeamMemberController(ITeamMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _memberService.Authenticate(model);
            if (response == null)
                return BadRequest(
                    new {message = "Username or password are incorrect"});
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(TeamMemberModel memberModel)
        {
            var response = await _memberService.Register(memberModel);
            if (response == null)
                return BadRequest(
                    new { message = "User already exist" });
            return Ok(response);
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login(AuthenticateRequest)
        //{

        //}


        [HttpGet("getMembers")]
        [Authorize]
        public IActionResult GetAll()
        {
            var members = _memberService.GetAll();
            return Ok(members);
        }

        
    }
}
