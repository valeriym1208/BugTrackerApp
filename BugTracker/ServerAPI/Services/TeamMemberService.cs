using System.Text;
using bug_tracker_data;
using bug_tracker_data.Models;
using BugTracker.ServerAPI.Interfaces;
using BugTrackerData.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.ServerAPI.Services
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly DataContext _context;
        public TeamMemberService(DataContext context)
        {
            _context = context;
        }
        public TeamMember Registration(TeamMember candidateTeamMember)
        {
            var candidate = _context.TeamMembers.FirstOrDefault(
                tm => tm.Email == candidateTeamMember.Email);
            if (candidate != null)
            {
                return candidate;
            }
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(candidateTeamMember.Password);
            var user = _context.TeamMembers.Add(
                new TeamMember
                {
                    Email = candidateTeamMember.Email,
                    GivenName = candidateTeamMember.GivenName,
                    Surname = candidateTeamMember.Surname,
                    Password = hashPassword,
                    PhoneNumber = candidateTeamMember.PhoneNumber,
                    AuthorizationLevel = candidateTeamMember.AuthorizationLevel,
                });
            _context.SaveChanges();
            return user.Entity;
        }

        //public async Task<ActionResult<TeamMember>> Login([FromBody] TeamMemberDTO)
        //{

        //}

    }
}
