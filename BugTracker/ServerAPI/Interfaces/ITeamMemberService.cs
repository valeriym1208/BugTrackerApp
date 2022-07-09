using bug_tracker_data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.ServerAPI.Interfaces;

public interface ITeamMemberService
{
    TeamMember Registration(TeamMember teamMember);
}