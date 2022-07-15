using bug_tracker_data.Models;
using BugTrackerData.DTO;
using BugTrackerData.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.ServerAPI.Interfaces;

public interface ITeamMemberService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    Task<AuthenticateResponse> Register(TeamMemberModel model);
    IEnumerable<TeamMember> GetAll();
    TeamMember GetById(int id);
}